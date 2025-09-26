using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EVDMS.Core.Entities;
namespace EVDMS.BLL.Services.Abstractions
{
    public interface ITestDriveService
    {
        Task<TestDrive> CreateTestDriveAsync(TestDrive testDrive);
        Task<IEnumerable<TestDrive>> GetAllAsync();
        Task<TestDrive> GetByIdAsync(Guid id);
        Task UpdateStatusAsync(Guid id, bool isSuccess);
    }
}
