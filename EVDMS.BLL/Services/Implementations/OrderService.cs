using EVDMS.BLL.Services.Abstractions;
using EVDMS.Core.Entities;
using EVDMS.DAL.Repositories.Abstractions;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EVDMS.BLL.Services.Implementations
{
    public class OrderService : IOrderService
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IInventoryRepository _inventoryRepository;
        private readonly IPromotionRepository _promotionRepository;

        public OrderService(IOrderRepository orderRepository, IInventoryRepository inventoryRepository, IPromotionRepository promotionRepository)
        {
            _orderRepository = orderRepository;
            _inventoryRepository = inventoryRepository;
            _promotionRepository = promotionRepository;
        }

        public async Task<Order> CreateOrderAsync(Order order)
        {
            var inventoryItem = await _inventoryRepository.GetByIdAsync(order.InventoryId);
            if (inventoryItem == null || inventoryItem.VehicleModel?.VehicleConfig == null)
            {
                throw new Exception("Không tìm thấy thông tin xe hoặc giá xe.");
            }

            decimal basePrice = inventoryItem.VehicleModel.VehicleConfig.BasePrice;
            decimal discountPrice = 0;

            if (order.PromotionId.HasValue)
            {
                var promotion = await _promotionRepository.GetByIdAsync(order.PromotionId.Value);
                if (promotion != null)
                {
                    discountPrice = basePrice * promotion.PercentDiscount / 100;
                }
            }

            decimal finalPrice = basePrice - discountPrice;

            order.Payment = new Payment
            {
                BasePrice = basePrice,
                DiscountPrice = discountPrice,
                FinalPrice = finalPrice,
                IsSuccess = true,
                CreatedById = order.CreatedById
            };

            return await _orderRepository.AddAsync(order);
        }

        public async Task<decimal> GetTotalRevenueByStaffIdAsync(Guid staffId)
        {
            return await _orderRepository.GetTotalRevenueByStaffIdAsync(staffId);
        }

        public async Task<IEnumerable<Order>> GetOrdersByStaffIdAsync(Guid staffId)
        {
            return await _orderRepository.GetOrdersByStaffIdAsync(staffId);
        }

        public async Task<Order> GetByIdAsync(Guid id)
        {
            return await _orderRepository.GetByIdAsync(id);
        }

        public async Task<decimal> GetTotalRevenueByDealerIdAsync(Guid dealerId)
        {
            return await _orderRepository.GetTotalRevenueByDealerIdAsync(dealerId);
        }

        public async Task<IEnumerable<Order>> GetOrdersByDealerIdAsync(Guid dealerId)
        {
            return await _orderRepository.GetOrdersByDealerIdAsync(dealerId);
        }

        public async Task<List<(Account Staff, decimal Revenue)>> GetStaffRevenuesByDealerAsync(Guid dealerId)
        {
            return await _orderRepository.GetStaffRevenuesByDealerAsync(dealerId);
        }
    }
}