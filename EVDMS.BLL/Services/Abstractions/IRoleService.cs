using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EVDMS.Core.Entities;

namespace EVDMS.BLL.Services.Abstractions
{
    public interface IRoleService
    {
        Task<IEnumerable<Role>> GetAllAsync();
    }
}