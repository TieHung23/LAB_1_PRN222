using System;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using System.Text.RegularExpressions;
using EVDMS.BLL.Services.Abstractions;
using EVDMS.Core.Entities;
using EVDMS.DAL.Database;
using EVDMS.DAL.Repositories.Abstractions;
using EVDMS.DAL.Response;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace EVDMS.BLL.Services.Implementations;

public class AIService : IAIService
{
    private readonly HttpClient _client;
    private readonly string ERROR_MSG;
    private readonly string END_SYSTEM_PROMPT;
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
    }

    public async Task<List<RevenueDataDTOs>> ExecuteSql(string sql)
    {
        var result = await _rawSQL.ExecRawSQLAsync(sql);

        return result;
    }

    public async Task<string> GenerateSql(string userPrompt, string expectedResult)
    {
        var ordersTable = nameof(_context.Orders);
        var ordersPk = nameof(Order.Id);
        var ordersAccountFk = nameof(Order.AccountId);

        var paymentsTable = nameof(_context.Payments);
        var paymentsPk = nameof(Payment.Id);
        var paymentsOrderFk = nameof(Payment.OrderId);
        var paymentsAmountCol = nameof(Payment.FinalPrice);

        var accountsTable = nameof(_context.Accounts);
        var accountsPk = nameof(Account.Id);
        var accountsDealerFk = nameof(Account.DealerId);
        var accountsName = nameof(Account.FullName);

        var dealersTable = nameof(_context.Dealers);
        var dealersPk = nameof(Dealer.Id);
        var dealersNameCol = nameof(Dealer.Name);

        var systemPrompt = $@"
            You are an AI specialized in generating SQL queries for Microsoft SQL Server.

            Database Schema:
            - Table: {ordersTable}
            - {ordersPk} (PK)
            - {ordersAccountFk} (FK → {accountsTable}.{accountsPk})
            - other columns…

            - Table: {paymentsTable}
            - {paymentsPk} (PK)
            - {paymentsOrderFk} (FK → {ordersTable}.{ordersPk})
            - {paymentsAmountCol}
            - other columns…

            - Table: {accountsTable}
            - {accountsPk} (PK)
            - {accountsDealerFk} (FK → {dealersTable}.{dealersPk})
            - {accountsName}
            - other columns…

            - Table: {dealersTable}
            - {dealersPk} (PK)
            - {dealersNameCol}
            - other columns…

            Relationships:
            1. {ordersTable} → {accountsTable} ({ordersTable}.{ordersAccountFk} = {accountsTable}.{accountsPk})
            2. {ordersTable} → {paymentsTable} ({paymentsTable}.{paymentsOrderFk} = {ordersTable}.{ordersPk})
            3. {accountsTable} → {dealersTable} ({accountsTable}.{accountsDealerFk} = {dealersTable}.{dealersPk})

            Guidelines:
            - Always use proper JOINs based on the relationships above.
            - Use table aliases (o = {ordersTable}, p = {paymentsTable}, a = {accountsTable}, d = {dealersTable}).
            - Always generate SQL in Microsoft SQL Server syntax (T-SQL).
            - Do not add `NULLS LAST` or PostgreSQL-specific syntax.
            - The output must shape correctly into the requested ViewModel (using aliases that match the property names).
            - For aggregation queries, group by all non-aggregated columns.

            Strict Rules:
            - Use ONLY ONE SQL script for the answer (no multiple scripts).
            - Use ONLY the provided tables ({ordersTable}, {paymentsTable}, {accountsTable}, {dealersTable}) 
            — do not reference any other tables or objects.
            - Do not generate explanations, comments, or extra text. Return ONLY the SQL query.

            Special Rules for interpretation of user requests:
            - If the user asks for ""top dealer(s)"":
                1. First, find the dealer(s) with the highest total revenue (using SUM of {paymentsTable}.{paymentsAmountCol}).
                2. If the user also wants employee-level details, then:
                    - Return ALL accounts (employees) belonging to that dealer(s).
                    - Show their individual revenue inside that dealer(s).
                3. To implement this:
                    - Use a CTE or subquery to calculate dealer revenue.
                    - Pick TOP N dealer(s) based on revenue.
                    - Join back to Accounts and Orders to get per-employee totals.

            - If the user asks for ""top employees"":
                - Return employees with the highest revenue directly, regardless of dealer.

            - If the user asks for ""top N dealers"":
                - Return N dealers with the highest revenue, using the same CTE/subquery approach.

            - Always ensure that when both dealer(s) and employees are requested:
                - Dealer(s) are ranked first, then employee details are returned for those dealers.
        ";
        var finalSystemPrompt = systemPrompt + END_SYSTEM_PROMPT + expectedResult;

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
}
