using System;
using EVDMS.BLL.DTOs.Response;

namespace EVDMS.DAL.Repositories.Abstractions;

public interface IRawSQL
{
    Task<List<EmployeeRevenueDTO>> GetEmployeeRevenueRawSQL(string sql);

    Task<List<BranchRevenueDTO>> GetBranchRevenueRawSQL(string sql);
}
