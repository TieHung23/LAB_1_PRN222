using EVDMS.BLL.Services.Abstractions;
using EVDMS.Core.Entities;
using EVDMS.Presentation.Models.ViewModels; 
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering; 
using System.Threading.Tasks;
using X.PagedList;
using X.PagedList.Extensions;
namespace EVDMS.Presentation.Controllers
{
    [Authorize(Roles = "Admin,EVMStaff")]
    public class AccountManagementController : Controller
    {
        private readonly IAccountService _accountService;
        private readonly IRoleService _roleService;
        private readonly IDealerService _dealerService;

        public AccountManagementController(IAccountService accountService, IRoleService roleService, IDealerService dealerService)
        {
            _accountService = accountService;
            _roleService = roleService;
            _dealerService = dealerService;
        }

        public async Task<IActionResult> Index(string searchTerm, int? page)
        {
           
            ViewData["CurrentFilter"] = searchTerm;

            var accounts = await _accountService.GetAccounts(searchTerm);

            int pageNumber = page ?? 1;
            int pageSize = 5;

            var pagedAccounts = accounts.ToPagedList(pageNumber, pageSize);

            return View(pagedAccounts);
        }

        public async Task<IActionResult> Create()
        {
            // Lấy danh sách Roles và Dealers để đưa vào dropdown list trong form
            ViewBag.Roles = new SelectList(await _roleService.GetAllAsync(), "Id", "Name");
            ViewBag.Dealers = new SelectList(await _dealerService.GetAllAsync(), "Id", "Name");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CreateAccountViewModel model)
        {
            if (ModelState.IsValid)
            {
                var newAccount = new Account
                {
                    UserName = model.UserName,
                    HashedPassword = model.Password, 
                    FullName = model.FullName,
                    RoleId = model.RoleId,
                    DealerId = model.DealerId
                };

                await _accountService.CreateAccountAsync(newAccount);
                return RedirectToAction(nameof(Index)); 
            }

            // Nếu dữ liệu nhập vào không hợp lệ, tải lại dropdown và hiển thị lại form
            ViewBag.Roles = new SelectList(await _roleService.GetAllAsync(), "Id", "Name", model.RoleId);
            ViewBag.Dealers = new SelectList(await _dealerService.GetAllAsync(), "Id", "Name", model.DealerId);
            return View(model);
        }

        public async Task<IActionResult> Edit(Guid id)
        {
            var account = await _accountService.GetAccountByIdAsync(id);
            if (account == null)
            {
                return NotFound();
            }

            // Chuyển dữ liệu từ Entity sang ViewModel
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
            if (id != model.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
        
                var accountToUpdate = await _accountService.GetAccountByIdAsync(id);
                if (accountToUpdate == null)
                {
                    return NotFound();
                }

             
                accountToUpdate.UserName = model.UserName;
                accountToUpdate.FullName = model.FullName;
                accountToUpdate.RoleId = model.RoleId;
                accountToUpdate.DealerId = model.DealerId;
                accountToUpdate.IsActive = model.IsActive;

                await _accountService.UpdateAccountAsync(accountToUpdate);
                return RedirectToAction(nameof(Index));
            }

            ViewBag.Roles = new SelectList(await _roleService.GetAllAsync(), "Id", "Name", model.RoleId);
            ViewBag.Dealers = new SelectList(await _dealerService.GetAllAsync(), "Id", "Name", model.DealerId);
            return View(model);
        }

        public async Task<IActionResult> Delete(Guid id)
        {
            var account = await _accountService.GetAccountByIdAsync(id);
            if (account == null)
            {
                return NotFound();
            }
            return View(account);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            await _accountService.DeleteAccountAsync(id);
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Details(Guid id)
        {
            var account = await _accountService.GetAccountByIdWithDetailsAsync(id);

            if (account == null)
            {
                return NotFound();
            }

            return View(account);
        }

        public async Task<IActionResult> DeletedAccounts()
        {
            ViewData["Title"] = "Tài khoản đã xóa";
            var deletedAccounts = await _accountService.GetDeletedAccountsAsync();
            return View(deletedAccounts);
        }
     
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Restore(Guid id)
        {
            await _accountService.RestoreAccountAsync(id);
           
            return RedirectToAction(nameof(DeletedAccounts));
        }
    }
}