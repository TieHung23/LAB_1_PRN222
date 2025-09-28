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

        public async Task<IActionResult> Revenue(bool viewByEmployee = false, string? msg = null)
        {
            if (string.IsNullOrEmpty(msg))
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

            if (viewByEmployee)
            {
                var columns = typeof(EmployeeRevenueViewModel).GetProperties().Select(p => p.Name).ToList();

                var expectedResult = $"Expected result is with value {columns}";

                var result = await _aiService.GenerateSql(msg, expectedResult);

                var model = await _aiService.GetEmployeeRevenue(result);

                var mapModel = model.Select(x => new EmployeeRevenueViewModel
                {
                    EmployeeName = x.EmployeeName,
                    Revenue = x.Revenue
                });

                return View("Revenue", mapModel);
            }
            else
            {
                var columns = typeof(BranchRevenueViewModel).GetProperties().Select(p => p.Name).ToList();
                var employeeColumns = typeof(EmployeeRevenueViewModel).GetProperties().Select(p => p.Name).ToList();
                var expectedResult = $"Expected result is with value {nameof(BranchRevenueViewModel.DealerName)} and {employeeColumns} is relation 1 -n";

                var result = await _aiService.GenerateSql(msg, expectedResult);

                var model = await _aiService.GetBranchRevenue(result);

                var mapModel = model.Select(x => new BranchRevenueViewModel
                {
                    Employees = x.Employees.Select(h => new EmployeeRevenueViewModel
                    {
                        EmployeeName = h.EmployeeName,
                        Revenue = h.Revenue
                    }).ToList(),
                    DealerName = x.DealerName,
                    TotalRevenue = x.TotalRevenue
                });

                return View("Revenue");
            }
        }
    }
}