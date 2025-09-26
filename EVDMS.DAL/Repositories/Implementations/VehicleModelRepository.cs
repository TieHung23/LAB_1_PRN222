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
    public class VehicleModelRepository : IVehicleModelRepository
    {
        private readonly ApplicationDbContext _context;
        public VehicleModelRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<VehicleModel>> GetFeaturedModelsAsync(int count)
        {
            return await _context.VehicleModels
                                 .Where(vm => !vm.IsDeleted && vm.IsActive)
                                 .Take(count)
                                 .ToListAsync();
        }


        public async Task<IEnumerable<VehicleModel>> GetAllAsync(string searchTerm)
        {
            var query = _context.VehicleModels
                                .Where(vm => !vm.IsDeleted && vm.IsActive)
                                .AsQueryable();

            if (!string.IsNullOrEmpty(searchTerm))
            {
                query = query.Where(vm => vm.ModelName.Contains(searchTerm) || vm.Brand.Contains(searchTerm));
            }

            return await query.OrderBy(vm => vm.ModelName).ToListAsync();
        }

        public async Task<VehicleModel> GetByIdAsync(Guid id)
        {
            return await _context.VehicleModels
                                 .Include(vm => vm.VehicleConfig) 
                                 .FirstOrDefaultAsync(vm => vm.Id == id);
        }
    }
}