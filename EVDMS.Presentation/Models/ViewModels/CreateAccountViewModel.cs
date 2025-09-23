using System;
using System.ComponentModel.DataAnnotations;

namespace EVDMS.Presentation.Models.ViewModels
{
    public class CreateAccountViewModel
    {
        [Required(ErrorMessage = "Tên đăng nhập là bắt buộc")]
        [Display(Name = "Tên đăng nhập")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Mật khẩu là bắt buộc")]
        [DataType(DataType.Password)]
        [Display(Name = "Mật khẩu")]
        public string Password { get; set; }

        [Required(ErrorMessage = "Họ và tên là bắt buộc")]
        [Display(Name = "Họ và tên")]
        public string FullName { get; set; }

        [Required(ErrorMessage = "Vui lòng chọn vai trò")]
        [Display(Name = "Vai trò")]
        public Guid RoleId { get; set; }

        [Display(Name = "Đại lý (nếu có)")]
        public Guid? DealerId { get; set; }
    }
}