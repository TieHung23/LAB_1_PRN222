using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EVDMS.Core.Entities;
namespace EVDMS.DAL.Repositories.Abstractions
{
    public interface IVehicleModelRepository
    {
        Task<IEnumerable<VehicleModel>> GetFeaturedModelsAsync(int count);
    }
}