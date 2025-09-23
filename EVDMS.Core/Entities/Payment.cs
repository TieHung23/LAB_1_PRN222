using System;
using System.ComponentModel.DataAnnotations;
using EVDMS.Core.CommonEntities;

namespace EVDMS.Core.Entities;

public class Payment : UpdatedCommon
{
    [Key]
    public Guid Id { get; set; } = Guid.NewGuid();

    public Guid OrderId { get; set; }

    public Order? Order { get; set; }

    public decimal BasePrice { get; set; }

    public decimal DiscountPrice { get; set; }

    public decimal FinalPrice { get; set; }

    public decimal Payed { get; set; }

    public DateTime StartDate { get; set; } = DateTime.Now;

    public DateTime EndDate { get; set; } = DateTime.Now;

    public string PaymentMethod { get; set; } = string.Empty;

    public bool IsSuccess { get; set; } = false;
}
