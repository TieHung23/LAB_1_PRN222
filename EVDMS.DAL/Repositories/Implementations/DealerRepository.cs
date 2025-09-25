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
    public class DealerRepository : IDealerRepository
    {
        private readonly ApplicationDbContext _context;
        public DealerRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<Dealer>> GetAllAsync()
        {
            return await _context.Dealers.ToListAsync();
        }
    }
}