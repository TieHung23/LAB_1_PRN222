using System;

namespace EVDMS.Presentation.Models.ViewModels;

public class BranchRevenueViewModel
{
    public string DealerName { get; set; } = string.Empty;
    public decimal TotalRevenue { get; set; }
    public List<EmployeeRevenueViewModel> Employees { get; set; } = new();
}

public class EmployeeRevenueViewModel
{
    public string EmployeeName { get; set; } = string.Empty;
    public decimal Revenue { get; set; }
}

public class RevenueReportViewModel
{
    public bool ViewByEmployee { get; set; }
    public List<BranchRevenueViewModel> Branches { get; set; } = new();
    public List<EmployeeRevenueViewModel> Employees { get; set; } = new();
}

