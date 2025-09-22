using System;
using System.ComponentModel.DataAnnotations;

namespace EVDMS.Core.Entities;

public class TestDrive
{
    [Key]
    public Guid Id { get; set; } = Guid.NewGuid();

    public Guid VehicleModelId { get; set; }

    public VehicleModel? VehicleModel { get; set; }

    public Guid CustomerId { get; set; }

    public Customer? Customer { get; set; }

    public DateTime? ScheduledDateTime { get; set; }

    public bool IsSuccess { get; set; } = false;

    public bool IsActive { get; set; } = true;

    public bool IsDeleted { get; set; } = false;
}
