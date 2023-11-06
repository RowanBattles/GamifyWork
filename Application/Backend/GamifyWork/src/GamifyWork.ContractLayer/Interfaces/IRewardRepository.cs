using GamifyWork.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GamifyWork.ContractLayer.Interfaces
{
    public interface IRewardRepository
    {
        Task<List<RewardDto>> GetAllRewards();
    }
}
