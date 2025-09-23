using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using EVDMS.Core.Entities;

public class CreatedCommon
{
    public long CreatedAtTick { get; set; } = DateTime.Now.Ticks;

    public DateTime CreatedAt { get; set; } = DateTime.Now;

    public Guid? CreatedById { get; set; }

    [NotMapped]
    public Account? CreatedBy { get; set; }
}