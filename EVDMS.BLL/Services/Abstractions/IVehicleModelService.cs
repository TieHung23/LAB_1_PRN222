using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EVDMS.Core.Entities;
namespace EVDMS.BLL.Services.Abstractions
{
    public interface IVehicleModelService
    {
        Task<IEnumerable<VehicleModel>> GetFeaturedModelsAsync(int count);
        Task<IEnumerable<VehicleModel>> GetAllAsync(string searchTerm);

        Task<VehicleModel> GetByIdAsync(Guid id);
    }


}