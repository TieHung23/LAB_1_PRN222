using Microsoft.AspNetCore.Mvc;
using System;
using System.ComponentModel.DataAnnotations;

namespace EVDMS.Presentation.Models.ViewModels
{
    public class CreateOrderViewModel
    {
        [Required(ErrorMessage = "Vui lòng chọn khách hàng")]
        [Display(Name = "Khách hàng")]
        public Guid CustomerId { get; set; }

        [Required(ErrorMessage = "Vui lòng chọn xe trong kho")]
        [Display(Name = "Xe trong kho")]
        public Guid InventoryId { get; set; }

        [Display(Name = "Chương trình khuyến mãi (nếu có)")]
        public Guid? PromotionId { get; set; }
    }
}
