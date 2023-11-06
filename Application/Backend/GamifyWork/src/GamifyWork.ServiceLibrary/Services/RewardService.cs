using GamifyWork.ContractLayer.Interfaces;
using GamifyWork.SharedModels.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GamifyWork.ServiceLibrary.Services
{
    public class RewardService
    {
        private readonly IRewardRepository _rewardRepository;
        public RewardService(IRewardRepository rewardRepository)
        {
            _rewardRepository = rewardRepository;
        }

        public async Task<List<RewardModel>> GetAllRewards()
        {
            try
            {
                return await _rewardRepository.GetAllRewards();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
