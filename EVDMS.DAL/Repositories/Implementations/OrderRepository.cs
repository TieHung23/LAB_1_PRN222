using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EVDMS.Core.Entities;
using EVDMS.DAL.Database;
using EVDMS.DAL.Repositories.Abstractions;
using Microsoft.EntityFrameworkCore;

namespace EVDMS.DAL.Repositories.Implementations
{
    public class OrderRepository : IOrderRepository
    {
        private readonly ApplicationDbContext _context;
        public OrderRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<decimal> GetTotalRevenueByStaffIdAsync(Guid staffId)
        {
            var totalRevenue = await _context.Payments
                .Where(p => p.Order.AccountId == staffId && p.IsSuccess)
                .SumAsync(p => p.FinalPrice);

            return totalRevenue;
        }
        public async Task<Order> AddAsync(Order order)
        {
            await _context.Orders.AddAsync(order);
            var inventoryItem = await _context.Inventories.FindAsync(order.InventoryId);
            if (inventoryItem != null)
            {
                inventoryItem.IsSale = false;
                _context.Inventories.Update(inventoryItem);
            }
            await _context.SaveChangesAsync();
            return order;
        }

        public async Task<IEnumerable<Order>> GetOrdersByStaffIdAsync(Guid staffId)
        {
            return await _context.Orders
                                 .Where(o => o.AccountId == staffId)
                                 .Include(o => o.Customer)
                                 .Include(o => o.Inventory)
                                    .ThenInclude(i => i.VehicleModel)
                                 .Include(o => o.Promotion)
                                 .Include(o => o.Payment) 
                                 .OrderByDescending(o => o.CreatedAt)
                                 .ToListAsync();
        }

        public async Task<Order> GetByIdAsync(Guid id)
        {
            return await _context.Orders
                                 .Where(o => o.Id == id)
                                 .Include(o => o.Customer)
                                 .Include(o => o.Account) 
                                 .Include(o => o.Inventory)
                                    .ThenInclude(i => i.VehicleModel)
                                        .ThenInclude(vm => vm.VehicleConfig) 
                                 .Include(o => o.Promotion)
                                 .Include(o => o.Payment)
                                 .FirstOrDefaultAsync();
        }
    }
}
