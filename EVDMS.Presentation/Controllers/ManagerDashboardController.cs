using EVDMS.BLL.Services.Abstractions;
using EVDMS.BLL.Services.Implementations;
using EVDMS.Core.Entities;
using EVDMS.Presentation.Models.ViewModels;
using EVDMS.Presentation.Models.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Security.Claims;

namespace EVDMS.Presentation.Controllers
{
    [Authorize(Roles = "Dealer Manager")]
    public class ManagerDashboardController : Controller
    {
        private readonly IAccountService _accountService;
        private readonly IOrderService _orderService;
        private readonly IRoleService _roleService;
        private readonly IDealerService _dealerService;

        public ManagerDashboardController(IAccountService accountService, IOrderService orderService, IRoleService roleService, IDealerService dealerService)
        {
            _accountService = accountService;
            _orderService = orderService;
            _roleService = roleService;
            _dealerService = dealerService;
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
        public async Task<IActionResult> Edit(Guid id)
        {
            var account = await _accountService.GetAccountByIdAsync(id);
            if (account == null) return NotFound();

            var viewModel = new EditAccountViewModel
            {
                Id = account.Id,
                UserName = account.UserName,
                FullName = account.FullName,
                RoleId = account.RoleId,
                DealerId = account.DealerId,
                IsActive = account.IsActive
            };

            ViewBag.Roles = new SelectList(await _roleService.GetAllAsync(), "Id", "Name", account.RoleId);
            ViewBag.Dealers = new SelectList(await _dealerService.GetAllAsync(), "Id", "Name", account.DealerId);

            return View(viewModel);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, EditAccountViewModel model)
        {
            if (id != model.Id) return NotFound();

            if (ModelState.IsValid)
            {
                var accountToUpdate = await _accountService.GetAccountByIdAsync(id);
                if (accountToUpdate == null) return NotFound();

                accountToUpdate.UserName = model.UserName;
                accountToUpdate.FullName = model.FullName;
                accountToUpdate.RoleId = model.RoleId;
                accountToUpdate.DealerId = model.DealerId;
                accountToUpdate.IsActive = model.IsActive;

                await _accountService.UpdateAccountAsync(accountToUpdate);
                return RedirectToAction("Index", "StaffManagement");
            }

            ViewBag.Roles = new SelectList(await _roleService.GetAllAsync(), "Id", "Name", model.RoleId);
            ViewBag.Dealers = new SelectList(await _dealerService.GetAllAsync(), "Id", "Name", model.DealerId);

            return View(model);
        }


        public async Task<IActionResult> Delete(Guid id)
        {
            var account = await _accountService.GetAccountByIdAsync(id);
            if (account == null) return NotFound();
            return View(account);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            await _accountService.DeleteAccountAsync(id);
            return RedirectToAction("Index", "StaffManagement");
        }

    }
}
