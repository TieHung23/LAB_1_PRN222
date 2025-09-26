using EVDMS.Core.Entities;
using EVDMS.DAL.Database;
using EVDMS.DAL.Repositories.Abstractions;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EVDMS.DAL.Repositories.Implementations
{
    public class InventoryRepository : IInventoryRepository
    {
        private readonly ApplicationDbContext _context;
        public InventoryRepository(ApplicationDbContext context)
        {
            _context = context;
        }

  
        public async Task<IEnumerable<Inventory>> GetAvailableStockAsync(Guid dealerId)
        {
            return await _context.Inventories
                                 .Include(i => i.VehicleModel)
                                 .Where(i => i.DealerId == dealerId && i.IsSale == true)
                                 .ToListAsync();
        }

        public async Task<Inventory> GetByIdAsync(Guid id)
        {
            return await _context.Inventories
                                 .Include(i => i.VehicleModel)
                                 .ThenInclude(vm => vm.VehicleConfig)
                                 .FirstOrDefaultAsync(i => i.Id == id);
        }
    }
}