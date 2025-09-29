using System;
using EVDMS.BLL.DTOs.Response;

namespace EVDMS.BLL.Services.Abstractions;

public interface IAIService
{
    Task<string> GenerateSql(string systemPrompt, string userPrompt);

    Task<List<EmployeeRevenueDTO>> GetEmployeeRevenue(string sql);

    Task<List<BranchRevenueDTO>> GetBranchRevenue(string sql);
}
