using System;

namespace EVDMS.BLL.DTOs.Response;

public class BranchRevenueDTO
{
    public string DealerName { get; set; } = string.Empty;
    public decimal TotalRevenue { get; set; }
    public List<EmployeeRevenueDTO> Employees { get; set; } = new();
}
