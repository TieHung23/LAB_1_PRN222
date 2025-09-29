using System.Threading.Tasks;
using EVDMS.BLL.Services.Abstractions;
using EVDMS.BLL.Services.Implementations;
using EVDMS.Presentation.Models.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EVDMS.Presentation.Controllers
{
    [Authorize(Roles = "Admin,EVMStaff")]
    public class AdminDashboardController : Controller
    {
        private readonly IOrderService _orderService;
        private readonly IAIService _aiService;

        public AdminDashboardController(IOrderService orderService, IAIService aiService)
        {
            _orderService = orderService;
            _aiService = aiService;
        }

        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> Revenue(bool viewByEmployee = false)
        {
            var result = await _orderService.GetAllOrder();
            if (viewByEmployee)
            {
                var employees = result
                    .GroupBy(o => o.Account!.FullName)
                    .Select(g => new EmployeeRevenueViewModel
                    {
                        EmployeeName = g.Key,
                        Revenue = g.Sum(x => x.Payment!.FinalPrice)
                    })
                    .ToList();

                var model = new RevenueReportViewModel
                {
                    ViewByEmployee = true,
                    Employees = employees
                };

                return View("Revenue", model);
            }
            else
            {
                var branches = result
                    .GroupBy(o => o.Account!.Dealer!.Name)
                    .Select(g => new BranchRevenueViewModel
                    {
                        DealerName = g.Key,
                        TotalRevenue = g.Sum(x => x.Payment!.FinalPrice),
                        Employees = g
                            .GroupBy(o => o.Account!.FullName)
                            .Select(e => new EmployeeRevenueViewModel
                            {
                                EmployeeName = e.Key,
                                Revenue = e.Sum(x => x.Payment!.FinalPrice)
                            })
                            .ToList()
                    })
                    .ToList();

                var model = new RevenueReportViewModel
                {
                    ViewByEmployee = false,
                    Branches = branches
                };

                return View("Revenue", model);
            }
        }

        public async Task<IActionResult> RevenueAI()
        {
            var result = await _orderService.GetAllOrder();

            var data = result.Select(x => new RevenueDataViewModel
            {
                AccountName = x.Account!.FullName,
                DealerName = x.Account.Dealer!.Name,
                Revenue = x.Payment!.FinalPrice
            }).ToList();

            return View(data);
        }

        [HttpPost]
        public async Task<IActionResult> RevenueAI(string message)
        {
            var employeeColumns = typeof(RevenueDataViewModel).GetProperties().Select(p => p.Name).ToList();
            var expectedResult = $"Expected result is with with properties must use alias to have true name of properties: {string.Join(", ", employeeColumns)}";

            var result = await _aiService.GenerateSql(message, expectedResult);

            var data = (await _aiService.ExecuteSql(result)).Select(x => new RevenueDataViewModel
            {
                AccountName = x.AccountName,
                DealerName = x.DealerName,
                Revenue = x.Revenue
            }).ToList();

            TempData["AISuccess"] = "Đã gửi dữ liệu đến AI thành công!";
            return View(data);
        }

    }
}