using GamifyWork.ContractLayer.Interfaces;
using GamifyWork.DataAccessLibrary.Data;
using GamifyWork.DataAccessLibrary.Interfaces;
using GamifyWork.Dto;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GamifyWork.DataAccessLibrary.Repositories
{
    public class RewardRepository : IRewardRepository
    {
        private readonly dbContext _dbContext;
        private readonly IRewardMapperD _rewardMapper;

        public RewardRepository(dbContext dbContext, IRewardMapperD rewardMapper)
        {
            _dbContext = dbContext;
            _rewardMapper = rewardMapper;
        }

        public async Task<List<RewardDto>> GetAllRewards()
        {
            using (_dbContext)
            {
                return _rewardMapper.MapEntityToDtoList(await _dbContext.reward.ToListAsync());
            }
        }
    }
}
