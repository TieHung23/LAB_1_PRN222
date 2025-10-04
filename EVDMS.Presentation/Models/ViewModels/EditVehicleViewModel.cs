// File: EVDMS.Presentation/Models/ViewModels/EditVehicleViewModel.cs

using System;
using System.ComponentModel.DataAnnotations;

namespace EVDMS.Presentation.Models.ViewModels
{
    public class EditVehicleViewModel
    {
        // Các trường ẩn để xác định đúng bản ghi cần cập nhật
        public Guid Id { get; set; }
        public Guid VehicleConfigId { get; set; }

        // --- Các trường thuộc về VehicleModel ---
        [Required(ErrorMessage = "Tên mẫu xe là bắt buộc")]
        [Display(Name = "Tên mẫu xe")]
        public string ModelName { get; set; }

        [Required(ErrorMessage = "Thương hiệu là bắt buộc")]
        [Display(Name = "Thương hiệu")]
        public string Brand { get; set; }

        [Required(ErrorMessage = "Loại xe là bắt buộc")]
        [Display(Name = "Loại xe (Sedan, SUV,...)")]
        public string VehicleType { get; set; }

        [Display(Name = "Mô tả")]
        public string Description { get; set; }

        [Display(Name = "URL Hình ảnh")]
        [Url(ErrorMessage = "URL hình ảnh không hợp lệ")]
        public string ImgUrl { get; set; }

        [Required(ErrorMessage = "Năm sản xuất là bắt buộc")]
        [Display(Name = "Năm sản xuất")]
        [Range(2000, 2100, ErrorMessage = "Năm sản xuất không hợp lệ")]
        public int ReleaseYear { get; set; }

        [Display(Name = "Kích hoạt?")]
        public bool IsActive { get; set; }

        // --- Các trường thuộc về VehicleConfig ---
        [Required(ErrorMessage = "Giá bán là bắt buộc")]
        [Display(Name = "Giá cơ bản (VND)")]
        [Range(1000000, 10000000000, ErrorMessage = "Giá bán phải là một số hợp lệ")]
        public decimal BasePrice { get; set; }

        [Required(ErrorMessage = "Thời hạn bảo hành là bắt buộc")]
        [Display(Name = "Thời hạn bảo hành (tháng)")]
        [Range(0, 120, ErrorMessage = "Thời hạn bảo hành không hợp lệ")]
        public int WarrantyPeriod { get; set; }
    }
}