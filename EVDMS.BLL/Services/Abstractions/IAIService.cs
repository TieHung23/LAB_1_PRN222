using System;
using EVDMS.DAL.Response;

namespace EVDMS.BLL.Services.Abstractions;

public interface IAIService
{
    Task<string> GenerateSql(string systemPrompt, string userPrompt);

    Task<List<RevenueDataDTOs>> ExecuteSql(string sql);
}
