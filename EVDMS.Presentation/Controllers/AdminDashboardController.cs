using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EVDMS.Presentation.Controllers
{
    [Authorize(Roles = "Admin,EVMStaff")] 
    public class AdminDashboardController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}