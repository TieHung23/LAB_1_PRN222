using System;

namespace EVDMS.DAL.Response;

public class RevenueDataDTOs
{
    public string DealerName { get; set; } = string.Empty;
    public string AccountName { get; set; } = string.Empty;
    public decimal Revenue { get; set; }
}
