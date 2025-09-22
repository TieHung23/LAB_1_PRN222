using System;
using System.ComponentModel.DataAnnotations;
using EVDMS.Core.CommonEntities;

namespace EVDMS.Core.Entities;

public class VehicleConfig : UpdatedCommon
{
    [Key]
    public Guid Id { get; set; } = Guid.NewGuid();

    public string VersionName { get; set; } = string.Empty;

    public string Color { get; set; } = string.Empty;

    public string InteriorType { get; set; } = string.Empty;

    public bool IsDeleted { get; set; } = false;

    public decimal BasePrice { get; set; }

    public int WarrantyPeriod { get; set; }
}
