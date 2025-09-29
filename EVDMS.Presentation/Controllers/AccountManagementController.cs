using EVDMS.BLL.Services.Abstractions;
using EVDMS.Core.Entities;
using EVDMS.Presentation.Models.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using OfficeOpenXml;
using System.Threading.Tasks;
using X.PagedList.Extensions;
namespace EVDMS.Presentation.Controllers
{
    [Authorize(Roles = "Admin,EVM Staff")]
    public class AccountManagementController : Controller
    {
        private readonly IAccountService _accountService;
        private readonly IRoleService _roleService;
        private readonly IDealerService _dealerService;
        private static List<CreateAccountViewModel> _importCache = new();
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
            ViewBag.Roles = new SelectList(await _roleService.GetAllAsync(), "Id", "Name");
            ViewBag.Dealers = new SelectList(await _dealerService.GetAllAsync(), "Id", "Name");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CreateAccountViewModel model)
        {

            var selectedRole = await _roleService.GetByIdAsync(model.RoleId);

            if (selectedRole != null && (selectedRole.Name == "Dealer Staff" || selectedRole.Name == "Dealer Manager"))
            {
                if (!model.DealerId.HasValue)
                {
                    ModelState.AddModelError("DealerId", "Vui lòng chọn một đại lý cho vai trò này.");
                }
            }
            else
            {
                model.DealerId = null;
            }
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

        public IActionResult Import()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Obsolete]
        public async Task<IActionResult> Import(IFormFile file)
        {
            if (file == null || file.Length == 0)
            {
                ModelState.AddModelError("", "Vui lòng chọn file Excel.");
                return View();
            }
            ExcelPackage.License.SetNonCommercialPersonal("TieHung");
            var accounts = new List<CreateAccountViewModel>();
            using (var stream = file.OpenReadStream())
            using (var package = new ExcelPackage(stream))
            {
                var worksheet = package.Workbook.Worksheets[0];
                int rowCount = worksheet.Dimension?.Rows ?? 0;

                for (int row = 2; row <= rowCount; row++)
                {
                    var userName = worksheet.Cells[row, 3].Text;
                    var password = worksheet.Cells[row, 2].Text;


                    accounts.Add(new CreateAccountViewModel
                    {
                        UserName = !string.IsNullOrEmpty(userName) ? userName : await GenerateUserNameAsync(worksheet.Cells[row, 1].Text, accounts),
                        Password = !string.IsNullOrEmpty(password) ? password : "12345",
                        FullName = worksheet.Cells[row, 1].Text,
                        RoleId = Guid.TryParse(worksheet.Cells[row, 4].Text, out var role) ? role : new Guid("11111111-1111-1111-1111-111111111111"),
                        DealerId = Guid.TryParse(worksheet.Cells[row, 5].Text, out var dealer) ? dealer : (Guid?)null
                    });
                }
            }

            _importCache = accounts;
            ViewBag.Preview = accounts;

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ConfirmImport()
        {
            var result = _importCache.Select(model => new Account
            {
                UserName = model.UserName,
                HashedPassword = model.Password,
                FullName = model.FullName,
                RoleId = model.RoleId,
                DealerId = model.DealerId
            });

            foreach (var entity in result)
            {
                await _accountService.CreateAccountAsync(entity);
            }

            TempData["Message"] = $"Đã import {_importCache.Count} tài khoản thành công!";
            _importCache.Clear();

            return RedirectToAction("Index");
        }

        public async Task<string> GenerateUserNameAsync(string fullName, List<CreateAccountViewModel>? accounts)
        {
            if (string.IsNullOrWhiteSpace(fullName))
                throw new ArgumentException("FullName cannot be empty");

            var parts = fullName.Trim().ToLower().Split(' ', StringSplitOptions.RemoveEmptyEntries);

            var lastName = parts.Last();
            var initials = string.Join("", parts.Take(parts.Length - 1).Select(p => p[0]));

            var baseUserName = lastName + initials;
            var userName = baseUserName + "1";
            int counter = 1;
            while (await _accountService.IsUserNameExist(userName) ||
                   (accounts != null && accounts.Any(a => a.UserName.Equals(userName, StringComparison.OrdinalIgnoreCase))))
            {
                counter++;
                userName = baseUserName + counter;
            }

            return userName;
        }

    }
}