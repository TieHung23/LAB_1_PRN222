using Microsoft.AspNetCore.Mvc;
using System;
using System.ComponentModel.DataAnnotations;

namespace EVDMS.Presentation.Models.ViewModels
{
    public class CreateTestDriveViewModel
    {
        [Required(ErrorMessage = "Vui lòng chọn khách hàng")]
        [Display(Name = "Khách hàng")]
        public Guid CustomerId { get; set; }

        [Required(ErrorMessage = "Vui lòng chọn mẫu xe")]
        [Display(Name = "Mẫu xe")]
        public Guid VehicleModelId { get; set; }

        [Required(ErrorMessage = "Vui lòng chọn ngày giờ")]
        [Display(Name = "Ngày giờ hẹn")]
        public DateTime ScheduledDateTime { get; set; }
    }
}