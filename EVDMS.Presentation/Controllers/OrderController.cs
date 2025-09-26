using EVDMS.BLL.Services.Abstractions;
using EVDMS.Core.Entities;
using EVDMS.Presentation.Models.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Security.Claims;
using X.PagedList.Extensions;

namespace EVDMS.Presentation.Controllers
{
    [Authorize(Roles = "Dealer Manager,Dealer Staff")]
    public class OrderController : Controller
    {
        private readonly IOrderService _orderService;
        private readonly ICustomerService _customerService;
        private readonly IInventoryService _inventoryService;
        private readonly IPromotionService _promotionService;

        public OrderController(IOrderService orderService, ICustomerService customerService,
                               IInventoryService inventoryService, IPromotionService promotionService)
        {
            _orderService = orderService;
            _customerService = customerService;
            _inventoryService = inventoryService;
            _promotionService = promotionService;
        }

        public async Task<IActionResult> Index(int? page)
        {
            var staffIdString = User.FindFirstValue("AccountId");
            if (Guid.TryParse(staffIdString, out Guid staffId))
            {
                var orders = await _orderService.GetOrdersByStaffIdAsync(staffId);
                int pageNumber = page ?? 1;
                int pageSize = 10;
                return View(orders.ToPagedList(pageNumber, pageSize));
            }
            return View(new List<Order>().ToPagedList(1, 10));
        }

        public async Task<IActionResult> Create()
        {
            await PopulateDropdowns();
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CreateOrderViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var accountIdString = User.FindFirstValue("AccountId");
                    if (!Guid.TryParse(accountIdString, out Guid accountId) || accountId == Guid.Empty)
                    {
                        ModelState.AddModelError("", "Không thể xác thực tài khoản nhân viên.");
                        await PopulateDropdowns(model);
                        return View(model);
                    }

                    var newOrder = new Order
                    {
                        CustomerId = model.CustomerId,
                        InventoryId = model.InventoryId,
                        PromotionId = model.PromotionId,
                        AccountId = accountId,
                        CreatedById = accountId
                    };

                    await _orderService.CreateOrderAsync(newOrder);

                    TempData["SuccessMessage"] = "Đã tạo đơn hàng thành công!";
                    return RedirectToAction(nameof(Index)); 
                }
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", $"Đã xảy ra lỗi: {ex.Message}");
            }

            await PopulateDropdowns(model);
            return View(model);
        }

        private async Task PopulateDropdowns(CreateOrderViewModel model = null)
        {
            var dealerIdString = User.FindFirstValue("DealerId");
            if (Guid.TryParse(dealerIdString, out Guid dealerId))
            {
                if (model == null)
                {
                    ViewBag.Customers = new SelectList(await _customerService.GetAllAsync(), "Id", "FullName");
                    ViewBag.Inventory = new SelectList(await _inventoryService.GetAvailableStockAsync(dealerId), "Id", "VehicleModel.ModelName");
                    ViewBag.Promotions = new SelectList(await _promotionService.GetActivePromotionsAsync(), "Id", "Name");
                }
                else
                {
                    ViewBag.Customers = new SelectList(await _customerService.GetAllAsync(), "Id", "FullName", model.CustomerId);
                    ViewBag.Inventory = new SelectList(await _inventoryService.GetAvailableStockAsync(dealerId), "Id", "VehicleModel.ModelName", model.InventoryId);
                    ViewBag.Promotions = new SelectList(await _promotionService.GetActivePromotionsAsync(), "Id", "Name", model.PromotionId);
                }
            }
        }
        public async Task<IActionResult> Details(Guid id)
        {
            var order = await _orderService.GetByIdAsync(id);
            if (order == null)
            {
                return NotFound();
            }
            return View(order);
        }
    }
}