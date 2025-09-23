using System;
using System.ComponentModel.DataAnnotations;
using EVDMS.Core.CommonEntities;

namespace EVDMS.Core.Entities;

public class Dealer : UpdatedCommon
{
    [Key]
    public Guid Id { get; set; } = Guid.NewGuid();

    public string Code { get; set; } = string.Empty;

    public string Name { get; set; } = string.Empty;

    public string Address { get; set; } = string.Empty;

    public string PhoneNumber { get; set; } = string.Empty;

    public string Email { get; set; } = string.Empty;

    public string Region { get; set; } = string.Empty;

    public bool IsActive { get; set; } = true;

    public bool IsDeleted { get; set; } = false;

    public ICollection<Account> Accounts { get; set; } = new List<Account>();
}
