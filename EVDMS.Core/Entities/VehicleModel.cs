using System;
using System.ComponentModel.DataAnnotations;

namespace EVDMS.Core.Entities;

public class VehicleModel : CreatedCommon
{
    [Key]
    public Guid Id { get; set; } = Guid.NewGuid();

    public string ModelName { get; set; } = string.Empty;

    public string Brand { get; set; } = string.Empty;

    public string VehicleType { get; set; } = string.Empty;

    public string Description { get; set; } = string.Empty;

    public string ImgUrl { get; set; } = string.Empty;

    public int ReleaseYear { get; set; }

    public bool IsActive { get; set; } = true;

    public bool IsDeleted { get; set; } = false;

    public Guid VehicleConfigId { get; set; }

    public VehicleConfig? VehicleConfig { get; set; }

    public ICollection<Guid>? FeatureIds { get; set; }

    public ICollection<Feature>? Features { get; set; }
}
