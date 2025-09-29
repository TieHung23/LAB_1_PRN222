using EVDMS.BLL.Services.Abstractions;
using EVDMS.Core.Entities;
using EVDMS.Presentation.Models.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace EVDMS.Presentation.Controllers
{
    [Authorize(Roles = "Dealer Manager")]
    public class StaffManagementController : Controller
    {
        private readonly IAccountService _accountService;
        private readonly IRoleService _roleService;

        public StaffManagementController(IAccountService accountService, IRoleService roleService)
        {
            _accountService = accountService;
            _roleService = roleService;
        }

        public async Task<IActionResult> Index()
        {
            var dealerIdStr = User.Claims.FirstOrDefault(c => c.Type == "DealerId")?.Value;
            if (!Guid.TryParse(dealerIdStr, out Guid dealerId))
                return View(new List<Account>());

            var accounts = await _accountService.GetAccountsByDealerAsync(dealerId);
            var staffAccounts = accounts.Where(a => a.Role != null && a.Role.Name == "Dealer Staff");

            return View(staffAccounts);
        }
        public async Task<IActionResult> Create()
        {
            var roles = await _roleService.GetAllAsync();
            ViewBag.Roles = new SelectList(roles.Where(r => r.Name == "Dealer Staff"), "Id", "Name");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CreateAccountViewModel model)
        {
            var dealerIdStr = User.Claims.FirstOrDefault(c => c.Type == "DealerId")?.Value;
            if (!Guid.TryParse(dealerIdStr, out Guid dealerId))
                return RedirectToAction(nameof(Index));

            if (ModelState.IsValid)
            {
                var newAccount = new Account
                {
                    UserName = model.UserName,
                    HashedPassword = model.Password,
                    FullName = model.FullName,
                    RoleId = model.RoleId,
                    DealerId = dealerId
                };

                await _accountService.CreateAccountAsync(newAccount);
                return RedirectToAction(nameof(Index));
            }

            return View(model);
        }
        public async Task<IActionResult> Edit(Guid id)
        {
            var account = await _accountService.GetAccountByIdAsync(id);
            if (account == null || account.Role?.Name != "Dealer Staff")
                return NotFound();

            var viewModel = new EditAccountViewModel
            {
                Id = account.Id,
                UserName = account.UserName,
                FullName = account.FullName,
                RoleId = account.RoleId,
                DealerId = account.DealerId,
                IsActive = account.IsActive
            };

            var roles = await _roleService.GetAllAsync();
            ViewBag.Roles = new SelectList(roles.Where(r => r.Name == "Dealer Staff"), "Id", "Name", account.RoleId);

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
                if (accountToUpdate == null || accountToUpdate.Role?.Name != "Dealer Staff")
                    return NotFound();

                accountToUpdate.UserName = model.UserName;
                accountToUpdate.FullName = model.FullName;
                accountToUpdate.RoleId = model.RoleId;
                accountToUpdate.IsActive = model.IsActive;

                await _accountService.UpdateAccountAsync(accountToUpdate);
                return RedirectToAction(nameof(Index));
            }

            return View(model);
        }
        public async Task<IActionResult> Delete(Guid id)
        {
            var account = await _accountService.GetAccountByIdAsync(id);
            if (account == null || account.Role?.Name != "Dealer Staff")
                return NotFound();

            return View(account);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var account = await _accountService.GetAccountByIdAsync(id);
            if (account != null && account.Role?.Name == "Dealer Staff")
            {
                await _accountService.DeleteAccountAsync(id);
            }
            return RedirectToAction(nameof(Index));
        }
    }
}
