using EVDMS.BLL.Services.Abstractions;
using EVDMS.Core.Entities;
using EVDMS.Presentation.Models.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Security.Claims;
using System.Threading.Tasks;
using X.PagedList.Extensions;
using X.PagedList;

namespace EVDMS.Presentation.Controllers
{
    [Authorize(Roles = "Dealer Manager,Dealer Staff")]
    public class TestDriveController : Controller
    {
        private readonly ITestDriveService _testDriveService;
        private readonly ICustomerService _customerService;
        private readonly IVehicleModelService _vehicleModelService;

        public TestDriveController(ITestDriveService testDriveService, ICustomerService customerService, IVehicleModelService vehicleModelService)
        {
            _testDriveService = testDriveService;
            _customerService = customerService;
            _vehicleModelService = vehicleModelService;
        }

        public async Task<IActionResult> Index(int? page)
        {
            var testDrives = await _testDriveService.GetAllAsync();
            int pageNumber = page ?? 1;
            int pageSize = 5;

            if (User.IsInRole("Dealer Manager"))
            {
                ViewBag.BackController = "ManagerDashboard";
            }
            else if (User.IsInRole("Dealer Staff"))
            {
                ViewBag.BackController = "SalesDashboard";
            }
            else
            {
                ViewBag.BackController = "Home";
            }

            return View(testDrives.ToPagedList(pageNumber, pageSize));
        }

        public async Task<IActionResult> Create()
        {
            ViewBag.Customers = new SelectList(await _customerService.GetAllAsync(), "Id", "FullName");
            ViewBag.VehicleModels = new SelectList(await _vehicleModelService.GetAllAsync(null), "Id", "ModelName");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CreateTestDriveViewModel model)
        {
            if (ModelState.IsValid)
            {
                var testDrive = new TestDrive
                {
                    CustomerId = model.CustomerId,
                    VehicleModelId = model.VehicleModelId,
                    ScheduledDateTime = model.ScheduledDateTime
                };
                await _testDriveService.CreateTestDriveAsync(testDrive);

                if (User.IsInRole("Dealer Manager"))
                    return RedirectToAction("Index", "ManagerDashboard");
                else if (User.IsInRole("Dealer Staff"))
                    return RedirectToAction("Index", "SalesDashboard");
                else
                    return RedirectToAction(nameof(Index));
            }
            ViewBag.Customers = new SelectList(await _customerService.GetAllAsync(), "Id", "FullName", model.CustomerId);
            ViewBag.VehicleModels = new SelectList(await _vehicleModelService.GetAllAsync(null), "Id", "ModelName", model.VehicleModelId);
            return View(model);
        }

        public async Task<IActionResult> Details(Guid id)
        {
            var testDrive = await _testDriveService.GetByIdAsync(id);
            if (testDrive == null)
            {
                return NotFound();
            }
            return View(testDrive);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> UpdateStatus(Guid id, bool isSuccess)
        {
            await _testDriveService.UpdateStatusAsync(id, isSuccess);
            return RedirectToAction(nameof(Details), new { id = id });
        }
    }
}
