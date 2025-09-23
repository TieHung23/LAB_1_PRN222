using EVDMS.BLL.Services.Abstractions;
using EVDMS.Presentation.Models.ViewModels;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using System.Threading.Tasks;

namespace EVDMS.Presentation.Controllers
{
    public class AccountController : Controller
    {
        private readonly IAccountService _accountService;

        public AccountController(IAccountService accountService)
        {
            _accountService = accountService;
        }

        // Action để hiển thị trang đăng nhập
        [HttpGet]
        public IActionResult Login()
        {
            // Nếu người dùng đã đăng nhập, chuyển hướng họ về trang chủ
            if (User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Index", "Home");
            }
            return View();
        }

        // Action để xử lý dữ liệu từ form đăng nhập
        [HttpPost]
        [ValidateAntiForgeryToken] // Thêm attribute để chống tấn công CSRF
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            // Gọi service để kiểm tra thông tin đăng nhập
            var account = await _accountService.Login(model.UserName, model.Password);

            if (account != null)
            {
                // Tạo các "Claims" - thông tin định danh cho người dùng
                // Các thông tin này sẽ được mã hóa và lưu trong cookie
                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, account.FullName),
                    new Claim("UserName", account.UserName),
                    new Claim(ClaimTypes.Role, account.Role.Name), // Lấy tên Role từ navigation property
                    new Claim("AccountId", account.Id.ToString()),
                    // Nếu DealerId có thể null, cần kiểm tra trước khi thêm claim
                    new Claim("DealerId", account.DealerId?.ToString() ?? "")
                };

                var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);

                var authProperties = new AuthenticationProperties
                {
                    // Tùy chọn: Ghi nhớ đăng nhập
                    // IsPersistent = true, 
                    // RedirectUri = "/some-local-url"
                };

                // Thực hiện đăng nhập, tạo cookie xác thực
                await HttpContext.SignInAsync(
                    CookieAuthenticationDefaults.AuthenticationScheme,
                    new ClaimsPrincipal(claimsIdentity),
                    authProperties);

                // Chuyển hướng đến trang chủ sau khi đăng nhập thành công
                return RedirectToAction("Index", "Home");
            }

            // Nếu đăng nhập thất bại, thêm lỗi vào ModelState để hiển thị trên View
            ModelState.AddModelError(string.Empty, "Tên đăng nhập hoặc mật khẩu không chính xác.");
            return View(model);
        }

        // Action để đăng xuất
        [HttpPost] // Nên dùng [HttpPost] cho Logout để tăng tính bảo mật
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Logout()
        {
            // Xóa cookie xác thực
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            // Chuyển hướng về trang đăng nhập
            return RedirectToAction("Login", "Account");
        }
    }
}