using EVDMS.BLL.Services.Abstractions;
using EVDMS.Core.Entities;
using Microsoft.AspNetCore.Authorization;
using EVDMS.Presentation.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using X.PagedList.Extensions;

namespace EVDMS.Presentation.Controllers
{
    [Authorize]
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

        [Authorize(Roles = "Dealer Manager,Dealer Staff")]
        public IActionResult Create()
        {
            return View(new CreateVehicleViewModel());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Dealer Manager,Dealer Staff")]
        public async Task<IActionResult> Create(CreateVehicleViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                // Tạo đối tượng VehicleConfig từ ViewModel
                var newVehicleConfig = new VehicleConfig
                {
                    BasePrice = viewModel.BasePrice,
                    WarrantyPeriod = viewModel.WarrantyPeriod,
                    VersionName = "Standard", // Gán giá trị mặc định
                    Color = "Default",      // Gán giá trị mặc định
                    InteriorType = "Standard" // Gán giá trị mặc định
                };

                // Tạo đối tượng VehicleModel từ ViewModel
                var newVehicleModel = new VehicleModel
                {
                    ModelName = viewModel.ModelName,
                    Brand = viewModel.Brand,
                    VehicleType = viewModel.VehicleType,
                    Description = viewModel.Description,
                    ImgUrl = viewModel.ImgUrl,
                    ReleaseYear = viewModel.ReleaseYear,
                    IsActive = viewModel.IsActive,
                    VehicleConfig = newVehicleConfig // Gán Config vào Model
                };

                await _vehicleModelService.CreateAsync(newVehicleModel);
                return RedirectToAction(nameof(Index));
            }
            return View(viewModel);
        }

        // GET: Vehicle/Edit/{id}
        [Authorize(Roles = "Dealer Manager,Dealer Staff")]
        public async Task<IActionResult> Edit(Guid id)
        {
            var vehicle = await _vehicleModelService.GetByIdAsync(id);
            if (vehicle == null || vehicle.VehicleConfig == null)
            {
                return NotFound();
            }

            // Ánh xạ (Map) từ Entity Model sang EditVehicleViewModel
            var viewModel = new EditVehicleViewModel
            {
                Id = vehicle.Id,
                VehicleConfigId = vehicle.VehicleConfigId,
                ModelName = vehicle.ModelName,
                Brand = vehicle.Brand,
                VehicleType = vehicle.VehicleType,
                Description = vehicle.Description,
                ImgUrl = vehicle.ImgUrl,
                ReleaseYear = vehicle.ReleaseYear,
                IsActive = vehicle.IsActive,
                BasePrice = vehicle.VehicleConfig.BasePrice,
                WarrantyPeriod = vehicle.VehicleConfig.WarrantyPeriod
            };

            return View(viewModel);
        }

        // POST: Vehicle/Edit/{id}
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Dealer Manager,Dealer Staff")]
        public async Task<IActionResult> Edit(Guid id, EditVehicleViewModel viewModel)
        {
            if (id != viewModel.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    // 1. Lấy bản ghi gốc từ database
                    var vehicleToUpdate = await _vehicleModelService.GetByIdAsync(viewModel.Id);
                    if (vehicleToUpdate == null || vehicleToUpdate.VehicleConfig == null)
                    {
                        return NotFound();
                    }

                    // 2. Cập nhật lại dữ liệu từ ViewModel vào bản ghi gốc
                    vehicleToUpdate.ModelName = viewModel.ModelName;
                    vehicleToUpdate.Brand = viewModel.Brand;
                    vehicleToUpdate.VehicleType = viewModel.VehicleType;
                    vehicleToUpdate.Description = viewModel.Description;
                    vehicleToUpdate.ImgUrl = viewModel.ImgUrl;
                    vehicleToUpdate.ReleaseYear = viewModel.ReleaseYear;
                    vehicleToUpdate.IsActive = viewModel.IsActive;

                    // Cập nhật cả thông tin của VehicleConfig liên quan
                    vehicleToUpdate.VehicleConfig.BasePrice = viewModel.BasePrice;
                    vehicleToUpdate.VehicleConfig.WarrantyPeriod = viewModel.WarrantyPeriod;

                    // 3. Gọi service để lưu thay đổi
                    await _vehicleModelService.UpdateAsync(vehicleToUpdate);
                }
                catch (Exception)
                {
                    // Xử lý lỗi concurrency (nếu cần)
                    throw;
                }
                return RedirectToAction(nameof(Index));
            }
            // Nếu có lỗi, trả về view với dữ liệu người dùng đã nhập
            return View(viewModel);
        }

        // GET: Vehicle/Delete/{id}
        [Authorize(Roles = "Dealer Manager,Dealer Staff")]
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
        [Authorize(Roles = "Dealer Manager,Dealer Staff")]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            await _vehicleModelService.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
