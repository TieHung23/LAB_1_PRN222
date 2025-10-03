using EVDMS.BLL.Services.Abstractions;
using EVDMS.Core.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc;
using X.PagedList;
using X.PagedList.Extensions;

namespace EVDMS.Presentation.Controllers
{
    [Authorize(Roles = "Dealer Manager,Dealer Staff")]
    public class VehicleController : Controller
    {
        private readonly IVehicleModelService _vehicleModelService;

        public VehicleController(IVehicleModelService vehicleModelService)
        {
            _vehicleModelService = vehicleModelService;
        }

        public async Task<IActionResult> Index(string searchTerm, int? page)
        {
            ViewData["CurrentFilter"] = searchTerm;
            var vehicles = await _vehicleModelService.GetAllAsync(searchTerm);

            int pageNumber = page ?? 1;
            int pageSize = 6; 

            return View(vehicles.ToPagedList(pageNumber, pageSize));
        }

        public async Task<IActionResult> Details(Guid id)
        {
            var vehicle = await _vehicleModelService.GetByIdAsync(id);
            if (vehicle == null)
            {
                return NotFound();
            }
            return View(vehicle);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(VehicleModel vehicleModel)
        {
            if (ModelState.IsValid)
            {
                await _vehicleModelService.CreateAsync(vehicleModel);
                return RedirectToAction(nameof(Index));
            }
            return View(vehicleModel);
        }

        // GET: Vehicle/Edit/{id}
        public async Task<IActionResult> Edit(Guid id)
        {
            var vehicle = await _vehicleModelService.GetByIdAsync(id);
            if (vehicle == null)
            {
                return NotFound();
            }
            return View(vehicle);
        }

        // POST: Vehicle/Edit/{id}
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, VehicleModel vehicleModel)
        {
            if (id != vehicleModel.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    await _vehicleModelService.UpdateAsync(vehicleModel);
                }
                catch (Exception)
                {
                    // Có thể thêm logic kiểm tra xem bản ghi có còn tồn tại không
                    // hoặc xử lý lỗi concurrency tại đây
                    throw;
                }
                return RedirectToAction(nameof(Index));
            }
            return View(vehicleModel);
        }

        // GET: Vehicle/Delete/{id}
        public async Task<IActionResult> Delete(Guid id)
        {
            var vehicle = await _vehicleModelService.GetByIdAsync(id);
            if (vehicle == null)
            {
                return NotFound();
            }
            return View(vehicle);
        }

        // POST: Vehicle/Delete/{id}
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            await _vehicleModelService.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
