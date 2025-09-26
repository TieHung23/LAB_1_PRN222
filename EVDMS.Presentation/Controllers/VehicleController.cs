using EVDMS.BLL.Services.Abstractions;
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
    }
}
