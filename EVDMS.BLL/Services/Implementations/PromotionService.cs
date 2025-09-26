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
    public class PromotionService : IPromotionService
    {
        private readonly IPromotionRepository _promotionRepository;
        public PromotionService(IPromotionRepository promotionRepository)
        {
            _promotionRepository = promotionRepository;
        }

        public async Task<IEnumerable<Promotion>> GetActivePromotionsAsync()
        {
            return await _promotionRepository.GetActivePromotionsAsync();
        }
    }
}