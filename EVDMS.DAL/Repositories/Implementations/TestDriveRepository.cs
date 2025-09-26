using EVDMS.Core.Entities;
using EVDMS.DAL.Database;
using EVDMS.DAL.Repositories.Abstractions;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EVDMS.DAL.Repositories.Implementations
{
    public class TestDriveRepository : ITestDriveRepository
    {
        private readonly ApplicationDbContext _context;
        public TestDriveRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<TestDrive> AddAsync(TestDrive testDrive)
        {
            await _context.TestDrives.AddAsync(testDrive);
            await _context.SaveChangesAsync();
            return testDrive;
        }

        public async Task<IEnumerable<TestDrive>> GetAllAsync()
        {
            return await _context.TestDrives
                                 .Include(td => td.Customer) 
                                 .Include(td => td.VehicleModel) 
                                 .Where(td => !td.IsDeleted)
                                 .OrderByDescending(td => td.ScheduledDateTime) 
                                 .ToListAsync();
        }

        public async Task<TestDrive> GetByIdAsync(Guid id)
        {
            return await _context.TestDrives
                                 .Include(td => td.Customer)
                                 .Include(td => td.VehicleModel)
                                 .FirstOrDefaultAsync(td => td.Id == id);
        }

        public async Task UpdateAsync(TestDrive testDrive)
        {
            _context.TestDrives.Update(testDrive);
            await _context.SaveChangesAsync();
        }
    }
}
