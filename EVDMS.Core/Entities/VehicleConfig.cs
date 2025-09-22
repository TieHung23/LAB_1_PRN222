using System;
using System.ComponentModel.DataAnnotations;

namespace EVDMS.Core.Entities;

public class VehicleConfig
{
    [Key]
    public Guid Id { get; set; } = Guid.NewGuid();

    public string VersionName { get; set; } = string.Empty;

    public string Color { get; set; } = string.Empty;

    public string InteriorType { get; set; } = string.Empty;

    public decimal BasePrice { get; set; }

    public int WarrantyPeriod { get; set; }
}
