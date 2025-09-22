using System;
using System.ComponentModel.DataAnnotations;

namespace EVDMS.Core.Entities;

public class Feedback
{
    [Key]
    public Guid Id { get; set; } = Guid.NewGuid();

    public Guid CustomerId { get; set; }

    public Customer? Customer { get; set; }

    public string Detail { get; set; } = string.Empty;
}
