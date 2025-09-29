using System;

namespace EVDMS.Presentation.Models.ViewModels;

public class RevenueDataViewModel
{
    public string DealerName { get; set; } = string.Empty;
    public string AccountName { get; set; } = string.Empty;
    public decimal Revenue { get; set; }
}
