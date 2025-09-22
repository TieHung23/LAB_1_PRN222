using System.ComponentModel.DataAnnotations;
using EVDMS.Core.Entities;

public class CreatedCommon
{
    public long CreatedAtTick { get; set; } = DateTime.Now.Ticks;

    public DateTime CreatedAt { get; set; } = DateTime.Now;

    public Guid CreatedById { get; set; }

    public Account CreatedBy { get; set; } = new();
}