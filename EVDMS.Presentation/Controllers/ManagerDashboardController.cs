using EVDMS.BLL.Services.Abstractions;
using EVDMS.Core.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace EVDMS.Presentation.Controllers
{
    [Authorize(Roles = "Dealer Manager")]
    public class ManagerDashboardController : Controller
    {
        private readonly IAccountService _accountService;
        private readonly IOrderService _orderService;

        public ManagerDashboardController(IAccountService accountService, IOrderService orderService)
        {
            _accountService = accountService;
            _orderService = orderService;
        }
        public async Task<IActionResult> Index()
        {
            var accountIdStr = User.FindFirstValue("AccountId");
            var dealerIdStr = User.FindFirstValue("DealerId");

            if (Guid.TryParse(accountIdStr, out Guid staffId))
            {
                var staffRevenue = await _orderService.GetTotalRevenueByStaffIdAsync(staffId);
                ViewData["StaffRevenue"] = staffRevenue;
            }
            else
            {
                ViewData["StaffRevenue"] = 0m;
            }

            if (Guid.TryParse(dealerIdStr, out Guid dealerId))
            {
                var dealerRevenue = await _orderService.GetTotalRevenueByDealerIdAsync(dealerId);
                ViewData["DealerRevenue"] = dealerRevenue;
            }
            else
            {
                ViewData["DealerRevenue"] = 0m;
            }

            return View();
        }
        public async Task<IActionResult> Accounts()
        {
            var dealerIdStr = User.Claims.FirstOrDefault(c => c.Type == "DealerId")?.Value;
            if (Guid.TryParse(dealerIdStr, out Guid dealerId))
            {
                var accounts = await _accountService.GetAccountsByDealerAsync(dealerId);

                var staffAccounts = accounts.Where(a => a.Role != null && a.Role.Name == "Dealer Staff");

                return View(staffAccounts);
            }
            return View(new List<Account>());
        }
        public async Task<IActionResult> Revenue()
        {
            var dealerIdStr = User.FindFirstValue("DealerId");
            if (Guid.TryParse(dealerIdStr, out Guid dealerId))
            {
                var revenue = await _orderService.GetTotalRevenueByDealerIdAsync(dealerId);
                ViewData["TotalRevenue"] = revenue;

                var orders = await _orderService.GetOrdersByDealerIdAsync(dealerId);
                return View(orders);
            }
            return View(new List<object>());
        }
        public async Task<IActionResult> StaffRevenueDetails()
        {
            var dealerIdStr = User.FindFirstValue("DealerId");
            if (Guid.TryParse(dealerIdStr, out Guid dealerId))
            {
                var staffRevenues = await _orderService.GetStaffRevenuesByDealerAsync(dealerId);
                return View(staffRevenues);
            }

            return View(new List<(Account, decimal)>());
        }
    }
}
