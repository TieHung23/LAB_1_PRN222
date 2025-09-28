using System;

namespace EVDMS.BLL.DTOs.Response;

public class EmployeeRevenueDTO
{
    public string EmployeeName { get; set; } = string.Empty;
    public decimal Revenue { get; set; }
}
