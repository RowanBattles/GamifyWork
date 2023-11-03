using GamifyWork.ServiceLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace GamifyWork.ServiceLibrary.tests.Models
{
    public class RewardModelTests
    {
        [Fact]
        public void RewardModel_PropertiesAreSetCorrectly()
        {
            // Arrange
            int rewardId = 1;
            string title = "Reward 1";
            string description = "Description 1";
            int cost = 10;
            int userId = 1;

            // Act
            var rewardModel = new RewardModel(rewardId, title, description, cost, userId);

            // Assert
            Assert.Equal(rewardId, rewardModel.Reward_ID);
            Assert.Equal(title, rewardModel.Title);
            Assert.Equal(description, rewardModel.Description);
            Assert.Equal(cost, rewardModel.Cost);
            Assert.Equal(userId, rewardModel.User_ID);
        }
    }
}
