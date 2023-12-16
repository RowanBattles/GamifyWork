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
            Guid user = new("6B29FC40-CA47-1067-B31D-00DD010662DA");

            // Act
            var rewardModel = new RewardModel(rewardId, title, description, cost, user);

            // Assert
            Assert.Equal(rewardId, rewardModel.Reward_ID);
            Assert.Equal(title, rewardModel.Title);
            Assert.Equal(description, rewardModel.Description);
            Assert.Equal(cost, rewardModel.Cost);
            Assert.Equal(user, rewardModel.User);
        }
    }
}
