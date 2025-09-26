using System;
using System.ComponentModel.DataAnnotations;

namespace EVDMS.Core.Entities;

public class Order : CreatedCommon
{
    [Key]
    public Guid Id { get; set; } = Guid.NewGuid();

    public Guid CustomerId { get; set; }

    public Guid AccountId { get; set; }

    public Guid InventoryId { get; set; }

    public Guid? PromotionId { get; set; }

    public Customer? Customer { get; set; }

    public Account? Account { get; set; }

    public Inventory? Inventory { get; set; }

    public Promotion? Promotion { get; set; }

    public Payment? Payment { get; set; }
}
