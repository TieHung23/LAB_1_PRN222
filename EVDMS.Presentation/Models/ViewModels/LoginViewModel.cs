using System.ComponentModel.DataAnnotations;

namespace EVDMS.Presentation.Models.ViewModels
{
    public class LoginViewModel
    {
        // --- BỔ SUNG THUỘC TÍNH [Display] ---
        [Required(ErrorMessage = "Vui lòng nhập Tên đăng nhập")]
        [Display(Name = "Tên đăng nhập")]
        public string UserName { get; set; }

        // --- BỔ SUNG THUỘC TÍNH [Display] ---
        [Required(ErrorMessage = "Vui lòng nhập mật khẩu")]
        [DataType(DataType.Password)]
        [Display(Name = "Mật khẩu")]
        public string Password { get; set; }
    }
}