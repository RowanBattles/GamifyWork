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
    public class RewardService : IRewardService
    {
        private readonly IRewardRepository _rewardRepository;
        private readonly IRewardMapperS _rewardMapper;
        public RewardService(IRewardRepository rewardRepository, IRewardMapperS rewardMapper)
        {
            _rewardRepository = rewardRepository;
            _rewardMapper = rewardMapper;
        }

        public async Task<List<RewardModel>> GetAllRewards()
        {
            return _rewardMapper.MapDtoToModelList(await _rewardRepository.GetAllRewards());
        }
    }
}
