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

        // Trong file: EVDMS.Presentation/Controllers/AccountController.cs

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var account = await _accountService.Login(model.UserName, model.Password);

            if (account != null)
            {
                var claims = new List<Claim>
        {
            new Claim(ClaimTypes.Name, account.FullName),
            new Claim("UserName", account.UserName),
            new Claim(ClaimTypes.Role, account.Role.Name),
            new Claim("AccountId", account.Id.ToString()),
            new Claim("DealerId", account.DealerId?.ToString() ?? "")
        };

                var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                var authProperties = new AuthenticationProperties { };

                await HttpContext.SignInAsync(
                    CookieAuthenticationDefaults.AuthenticationScheme,
                    new ClaimsPrincipal(claimsIdentity),
                    authProperties);


                switch (account.Role.Name)
                {
                    case "Admin":
                    case "EVM Staff": 
                        return RedirectToAction("Index", "AdminDashboard");

                    case "Dealer Manager": 
                    case "Dealer Staff":   
                        return RedirectToAction("Index", "SalesDashboard");

                    default:
                        // Mặc định, chuyển về trang chủ
                        return RedirectToAction("Index", "Home");
                }
            }

            ModelState.AddModelError(string.Empty, "Tên đăng nhập hoặc mật khẩu không chính xác.");
            return View(model);
        }

        // Action để đăng xuất
        [HttpPost] 
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