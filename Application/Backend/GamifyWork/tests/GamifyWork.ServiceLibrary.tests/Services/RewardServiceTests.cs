//using GamifyWork.ServiceLibrary.Interfaces;
//using GamifyWork.ServiceLibrary.Models;
//using GamifyWork.ServiceLibrary.Services;
//using Moq;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using Xunit;

//namespace GamifyWork.ServiceLibrary.tests.Services
//{
//    public class RewardServiceTests
//    {
//        [Fact]
//        public async Task GetAllRewards_ReturnsAllRewards()
//        {
//            // Arrange
//            var mockRepository = new Mock<IRewardRepository>();
//            var rewards = new List<RewardModel>
//            {
//                new RewardModel(1, "Reward 1", "Description 1", 10, 1),
//                new RewardModel(2, "Reward 2", "Description 2", 20, 1),
//                new RewardModel(3, "Reward 3", "Description 3", 30, 2)
//            };
//            mockRepository.Setup(repo => repo.GetAllRewards()).ReturnsAsync(rewards);

//            var rewardService = new RewardService(mockRepository.Object);

//            // Act
//            var result = await rewardService.GetAllRewards();

//            // Assert
//            Assert.Contains(result, reward => reward.Reward_ID == 1);
//            Assert.Contains(result, reward => reward.Reward_ID == 2);
//            Assert.Contains(result, reward => reward.Reward_ID == 3);

//            Assert.Equal(3, result.Count());

//            Assert.Equal("Reward 1", result[0].Title);
//            Assert.Equal("Reward 2", result[1].Title);
//            Assert.Equal("Reward 3", result[2].Title);
//            Assert.Equal("Description 1", result[0].Description);
//            Assert.Equal("Description 2", result[1].Description);
//            Assert.Equal("Description 3", result[2].Description);
//            Assert.Equal(10, result[0].Cost);
//            Assert.Equal(20, result[1].Cost);
//            Assert.Equal(30, result[2].Cost);
//            Assert.Equal(1, result[0].User_ID);
//            Assert.Equal(1, result[1].User_ID);
//            Assert.Equal(2, result[2].User_ID);
//        }

//        [Fact]
//        public async Task GetAllRewards_ReturnsEmptyList()
//        {
//            // Arrange
//            var mockRepository = new Mock<IRewardRepository>();
//            var emptyRewards = new List<RewardModel>();
//            mockRepository.Setup(repo => repo.GetAllRewards()).ReturnsAsync(emptyRewards);

//            var rewardService = new RewardService(mockRepository.Object);

//            // Act
//            var result = await rewardService.GetAllRewards();

//            // Assert
//            Assert.Empty(result);
//        }

//        [Fact]
//        public async Task GetAllRewards_ThrowsException()
//        {
//            // Arrange
//            var mockRepository = new Mock<IRewardRepository>();
//            mockRepository.Setup(repo => repo.GetAllRewards()).ThrowsAsync(new Exception("An error occurred"));

//            var rewardService = new RewardService(mockRepository.Object);

//            // Act and Assert
//            await Assert.ThrowsAsync<Exception>(() => rewardService.GetAllRewards());
//        }
//    }
//}
