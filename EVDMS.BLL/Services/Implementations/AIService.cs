using System;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using System.Text.RegularExpressions;
using EVDMS.BLL.DTOs.Response;
using EVDMS.BLL.Services.Abstractions;
using EVDMS.Core.Entities;
using EVDMS.DAL.Database;
using EVDMS.DAL.Repositories.Abstractions;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace EVDMS.BLL.Services.Implementations;

public class AIService : IAIService
{
    private readonly HttpClient _client;
    private readonly string ERROR_MSG;
    private readonly string END_SYSTEM_PROMPT;
    private readonly string PRE_SYSTEM_PROMPT;
    private readonly ILogger<AIService> _logger;
    private readonly IRawSQL _rawSQL;
    private readonly ApplicationDbContext _context;


    public AIService(ILogger<AIService> logger, IRawSQL rawSQL, ApplicationDbContext context)
    {
        _client = new HttpClient();
        ERROR_MSG = "Cannot create sql";
        END_SYSTEM_PROMPT = $"\n If the user prompt have field not match you must answer {ERROR_MSG}";
        _logger = logger;
        _rawSQL = rawSQL;
        _context = context;
        PRE_SYSTEM_PROMPT = "You are an SQL generator. " +
                "Use only SQL Server syntax.Do not use backticks (`). " +
                "Use square brackets ([]) only if needed. " +
                "Do not use MySQL or PostgreSQL specific functions. " +
                "Only respond with the SQL script inside triple backticks, no explanation.\n" +
                "- If you need to reference DealerId, you must go through the Accounts table (i.e., do not join directly from Orders/  Payments to Dealers without passing through Accounts).\n" +
                "- If aggregation is needed, use SUM, COUNT, AVG, MAX, or MIN properly.\n" +
                "- Only generate SELECT statements; do not use CREATE, UPDATE, DELETE, or other SQL types.\n" +
                "- Use T-SQL syntax compatible with Microsoft SQL Server.\n" +
                "- Use TOP N instead of LIMIT.\n" +
                "- Do not use NULLS FIRST or NULLS LAST; handle NULLs using ISNULL, COALESCE, or CASE expressions if needed.\n" +
                "- When ordering by an aggregate, reference the aggregate function directly in ORDER BY.\n" +
                "- Always ensure that the output query will run in Microsoft SQL Server without syntax errors.";
    }

    public async Task<string> GenerateSql(string userPrompt, string expectedResult)
    {
        var entities = new[]
        {
            new { Name = nameof(_context.Accounts), Columns = typeof(Account).GetProperties().Select(p => p.Name).ToList() },
            new { Name = nameof(_context.Orders), Columns = typeof(Order).GetProperties().Select(p => p.Name).ToList() },
            new { Name = nameof(_context.Dealers), Columns = typeof(Dealer).GetProperties().Select(p => p.Name).ToList() },
            new { Name = nameof(_context.Payments), Columns = typeof(Payment).GetProperties().Select(p => p.Name).ToList() }
        };

        // var systemPrompt =
        //     "You are an AI specialized in generating SQL queries specifically for Microsoft SQL Server (T-SQL).\n" +
        //     "Rules:\n" +
        //     "- Always output only valid T-SQL SELECT statements (no explanations, no comments, no other SQL types).\n" +
        //     "- You can only use the following tables and their columns:\n\n" +
        //     string.Join("\n", entities.Select(e =>
        //         $"- Table [{e.Name}] with columns: {string.Join(", ", e.Columns)}")) +
        //     "\n\n" +
        //     "- Always use proper JOINs based on logical relations.\n" +
        //     "- Use table aliases (short, like a, o, d, p).\n" +
        //     "- If you need to reference DealerId, you must go through the Accounts table (i.e., do not join directly from Orders/Payments to Dealers without passing through Accounts).\n" +
        //     "- If aggregation is needed, use SUM, COUNT, AVG, MAX, or MIN properly.\n" +
        //     "- Only generate SELECT statements; do not use CREATE, UPDATE, DELETE, or other SQL types.\n" +
        //     "- Use T-SQL syntax compatible with Microsoft SQL Server.\n" +
        //     "- Use TOP N instead of LIMIT.\n" +
        //     "- Do not use NULLS FIRST or NULLS LAST; handle NULLs using ISNULL, COALESCE, or CASE expressions if needed.\n" +
        //     "- When ordering by an aggregate, reference the aggregate function directly in ORDER BY.\n" +
        //     "- Always ensure that the output query will run in Microsoft SQL Server without syntax errors.";

        var systemPrompt = "- You can only use the following tables and their columns:\n\n" +
            string.Join("\n", entities.Select(e =>
                $"- Table [{e.Name}] with columns: {string.Join(", ", e.Columns)}")) +
            "\n\n";

        var finalSystemPrompt = PRE_SYSTEM_PROMPT + systemPrompt + END_SYSTEM_PROMPT + expectedResult;

        var requestBody = new
        {
            model = "gpt-4",
            messages = new[]
            {
                new { role = "system", content = finalSystemPrompt },
                new { role = "user", content = userPrompt }
            }
        };

        var request = new HttpRequestMessage(HttpMethod.Post, "https://api.openai.com/v1/chat/completions");
        request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", "");
        request.Content = new StringContent(JsonSerializer.Serialize(requestBody), Encoding.UTF8, "application/json");

        var response = await _client.SendAsync(request);

        response.EnsureSuccessStatusCode();

        var responseContent = await response.Content.ReadAsStringAsync();

        using var doc = JsonDocument.Parse(responseContent);
        var reply = doc.RootElement
            .GetProperty("choices")[0]
            .GetProperty("message")
            .GetProperty("content")
            .GetString();

        if (string.IsNullOrWhiteSpace(reply))
            throw new Exception("AI response is empty");
        var match = Regex.Match(reply, "```\\s*(.*?)\\s*```", RegexOptions.Singleline);
        string sql;

        if (match.Success)
        {
            sql = match.Groups[1].Value.Replace("`", "").Replace("sql", "", StringComparison.OrdinalIgnoreCase).Trim();
        }
        else
        {
            sql = reply.Trim();
        }

        _logger.LogInformation($"Result SQL : {sql}");

        return sql;
    }

    public async Task<List<BranchRevenueDTO>> GetBranchRevenue(string sql)
    {
        return await _rawSQL.GetBranchRevenueRawSQL(sql);
    }

    public async Task<List<EmployeeRevenueDTO>> GetEmployeeRevenue(string sql)
    {
        return await _rawSQL.GetEmployeeRevenueRawSQL(sql);
    }
}
