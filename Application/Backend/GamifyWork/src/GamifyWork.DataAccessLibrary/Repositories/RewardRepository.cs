using GamifyWork.DataAccessLibrary.Data;
using GamifyWork.ServiceLibrary.Interfaces;
using GamifyWork.ServiceLibrary.Models;
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

        public RewardRepository(dbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<RewardModel>> GetAllRewards()
        {
            using (_dbContext)
            {
                return await _dbContext.reward.ToListAsync();
            }
        }
    }
}
