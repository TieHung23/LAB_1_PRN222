using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using EVDMS.Core.CommonEntities;

namespace EVDMS.Core.Entities;

public class Role : UpdatedCommon
{
    [Key]
    public Guid Id { get; set; }

    public string Name { get; set; } = string.Empty;

    public string Description { get; set; } = string.Empty;

    public ICollection<Account> Accounts { get; set; } = new List<Account>();
}
