using System;
using System.ComponentModel.DataAnnotations.Schema;
using EVDMS.Core.Entities;

namespace EVDMS.Core.CommonEntities;

public class UpdatedCommon : CreatedCommon
{
    public long UpdatedAtTick { get; set; } = DateTime.Now.Ticks;

    public DateTime UpdatedAt { get; set; } = DateTime.Now;

    public Guid UpdatedById { get; set; }

    [NotMapped]
    public Account UpdatedBy { get; set; } = new();
}
