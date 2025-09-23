using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EVDMS.Presentation.Controllers
{
    [Authorize(Roles = "Manager,Staff")] 
    public class SalesDashboardController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}