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
    public class PromotionRepository : IPromotionRepository
    {
        private readonly ApplicationDbContext _context;
        public PromotionRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Promotion>> GetActivePromotionsAsync()
        {
            return await _context.Promotions
                                 .Where(p => p.IsActive && !p.IsDeleted)
                                 .ToListAsync();
        }

        public async Task<Promotion> GetByIdAsync(Guid id)
        {
            return await _context.Promotions.FindAsync(id);
        }
    }
}