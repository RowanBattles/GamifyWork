using GamifyWork.ContractLayer.Interfaces;
using GamifyWork.ServiceLibrary.Exceptions;
using GamifyWork.ServiceLibrary.Interfaces;
using GamifyWork.ServiceLibrary.Models;
using Microsoft.Extensions.Logging;
using System.Net;

namespace GamifyWork.ServiceLibrary.Services
{
    public class RewardService : IRewardService
    {
        private readonly IRewardRepository _rewardRepository;
        private readonly IRewardMapperS _rewardMapper;
        private readonly ILogger<RewardService> _logger;
        public RewardService(IRewardRepository rewardRepository, IRewardMapperS rewardMapper, ILogger<RewardService> logger)
        {
            _rewardRepository = rewardRepository;
            _rewardMapper = rewardMapper;
            _logger = logger;
        }

        public async Task<List<RewardModel>> GetAllRewards()
        {
            try
            {
                return _rewardMapper.MapDtoToModelList(await _rewardRepository.GetAllRewards());
            }
            catch(Exception ex)
            {
                _logger.LogError(ex, "An unexpected error occured while retrieving rewards");
                throw new RewardException("Error retrieving rewards", (int)HttpStatusCode.InternalServerError);
            }
            
        }
    }
}
