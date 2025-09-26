using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using EVDMS.BLL.Services.Abstractions;
using System.Security.Claims;

namespace EVDMS.Presentation.Controllers
{
    [Authorize(Roles = "Dealer Manager,Dealer Staff")]
    public class SalesDashboardController : Controller
    {
        private readonly IOrderService _orderService;

        public SalesDashboardController(IOrderService orderService)
        {
            _orderService = orderService;
        }

        public async Task<IActionResult> Index()
        {
            var staffIdString = User.FindFirstValue("AccountId");
            if (Guid.TryParse(staffIdString, out Guid staffId))
            {
                var totalRevenue = await _orderService.GetTotalRevenueByStaffIdAsync(staffId);
                ViewData["TotalRevenue"] = totalRevenue;
            }
            else
            {
                ViewData["TotalRevenue"] = 0m;
            }
            return View();
        }
    }
}