using System;
using System.ComponentModel.DataAnnotations;

namespace EVDMS.Core.Entities;

public class Role : CreatedCommon
{
    [Key]
    public Guid Id { get; set; } = Guid.NewGuid();

    public string Name { get; set; } = string.Empty;

    public string Description { get; set; } = string.Empty;

    public ICollection<Account> Accounts { get; set; } = new List<Account>();
}
