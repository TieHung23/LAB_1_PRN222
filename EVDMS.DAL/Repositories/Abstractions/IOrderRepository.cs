using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EVDMS.Core.Entities;

namespace EVDMS.DAL.Repositories.Abstractions
{
    public interface IOrderRepository
    {
        Task<decimal> GetTotalRevenueByStaffIdAsync(Guid staffId);
        Task<Order> AddAsync(Order order);
        Task<IEnumerable<Order>> GetOrdersByStaffIdAsync(Guid staffId);
        Task<Order> GetByIdAsync(Guid id);
    }
}
