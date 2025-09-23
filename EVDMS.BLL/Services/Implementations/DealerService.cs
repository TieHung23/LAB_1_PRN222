using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EVDMS.BLL.Services.Abstractions;
using EVDMS.Core.Entities;
using EVDMS.DAL.Repositories.Abstractions;

namespace EVDMS.BLL.Services.Implementations
{
    public class DealerService : IDealerService
    {
        private readonly IDealerRepository _dealerRepository;
        public DealerService(IDealerRepository dealerRepository)
        {
            _dealerRepository = dealerRepository;
        }
        public async Task<IEnumerable<Dealer>> GetAllAsync()
        {
            return await _dealerRepository.GetAllAsync();
        }
    }
}