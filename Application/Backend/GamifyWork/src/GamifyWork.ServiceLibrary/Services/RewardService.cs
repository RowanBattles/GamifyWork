using GamifyWork.ContractLayer.Interfaces;
using GamifyWork.ServiceLibrary.Interfaces;
using GamifyWork.ServiceLibrary.Models;
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
        private IRewardMapperS _rewardMapper;
        public RewardService(IRewardRepository rewardRepository, IRewardMapperS rewardMapper)
        {
            _rewardRepository = rewardRepository;
            _rewardMapper = rewardMapper;
        }

        public async Task<List<RewardModel>> GetAllRewards()
        {
            try
            {
                var rewardDtos = await _rewardRepository.GetAllRewards();
                var rewardModels = _rewardMapper.MapDtoToModelList(rewardDtos);
                return rewardModels;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
