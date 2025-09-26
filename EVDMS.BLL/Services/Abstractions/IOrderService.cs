using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EVDMS.Core.Entities;
using System;
using System.Collections.Generic;

namespace EVDMS.BLL.Services.Abstractions
{
    public interface IOrderService
    {
        Task<decimal> GetTotalRevenueByStaffIdAsync(Guid staffId);
        Task<Order> CreateOrderAsync(Order order);
        Task<IEnumerable<Order>> GetOrdersByStaffIdAsync(Guid staffId);
        Task<Order> GetByIdAsync(Guid id);
    }
}
