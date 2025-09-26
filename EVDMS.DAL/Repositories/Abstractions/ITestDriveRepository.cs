using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EVDMS.Core.Entities;
namespace EVDMS.DAL.Repositories.Abstractions
{
    public interface ITestDriveRepository
    {
        Task<TestDrive> AddAsync(TestDrive testDrive);
        Task<IEnumerable<TestDrive>> GetAllAsync();
        Task<TestDrive> GetByIdAsync(Guid id);
        Task UpdateAsync(TestDrive testDrive);
    }
}
