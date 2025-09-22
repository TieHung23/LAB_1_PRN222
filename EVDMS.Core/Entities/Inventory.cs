using System;
using System.ComponentModel.DataAnnotations;

namespace EVDMS.Core.Entities;

public class Inventory
{
    [Key]
    public Guid Id { get; set; } = Guid.NewGuid();

    public Guid VehicleModelId { get; set; }

    public VehicleModel? VehicleModel { get; set; }

    public Guid DealerId { get; set; }

    public Dealer? Dealer { get; set; }

    public bool IsSale { get; set; } = true;

    public string Description { get; set; } = string.Empty;
}
