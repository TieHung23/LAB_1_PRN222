using System;
using EVDMS.Core.Entities;

namespace EVDMS.Core.CommonEntities;

public class UpdatedCommon
{
    public long UpdatedAtTick { get; set; } = DateTime.Now.Ticks;

    public DateTime UpdatedAt { get; set; } = DateTime.Now;

    public Guid UpdatedById { get; set; }

    public Account UpdatedBy { get; set; } = new();
}
