using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using EVDMS.Core.CommonEntities;

namespace EVDMS.Core.Entities;

public class Account : UpdatedCommon
{
    [Key]
    public Guid Id { get; set; } = Guid.NewGuid();

    public string UserName { get; set; } = string.Empty;

    public string HashedPassword { get; set; } = string.Empty;

    public string FullName { get; set; } = string.Empty;

    public bool IsActive { get; set; } = true;

    public bool IsDeleted { get; set; } = false;

    public Guid DealerId { get; set; }

    public Guid RoleId { get; set; }

    public Dealer? Dealer { get; set; }

    public Role? Role { get; set; }
}
