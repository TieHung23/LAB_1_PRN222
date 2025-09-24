using EVDMS.BLL.Services.Abstractions;
using EVDMS.Presentation.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Threading.Tasks;

namespace EVDMS.Presentation.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IVehicleModelService _vehicleModelService;

   
        public HomeController(ILogger<HomeController> logger, IVehicleModelService vehicleModelService)
        {
            _logger = logger;
            _vehicleModelService = vehicleModelService;
        }

    
        public async Task<IActionResult> Index()
        {
          
            var featuredModels = await _vehicleModelService.GetFeaturedModelsAsync(3);
            return View(featuredModels);
        }

  

        public IActionResult Privacy()
        {
            return View();
        }

        [Authorize]
        public IActionResult MyClaims()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}