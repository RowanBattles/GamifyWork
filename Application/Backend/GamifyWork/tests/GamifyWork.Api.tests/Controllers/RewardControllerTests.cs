//using GamifyWork.API.Controllers;
//using GamifyWork.ServiceLibrary.Interfaces;
//using GamifyWork.ServiceLibrary.Models;
//using Microsoft.AspNetCore.Mvc;
//using Moq;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using Xunit;

//namespace GamifyWork.Api.tests.Controllers
//{
//    public class RewardControllerTests
//    {
//        private readonly Mock<IRewardService> _rewardServiceMock;
//        private readonly RewardController _controller;

//        public RewardControllerTests()
//        {
//            _rewardServiceMock = new Mock<IRewardService>();
//            _controller = new RewardController(_rewardServiceMock.Object);
//        }

//        [Fact]
//        public async Task GetRewards_ShouldReturnOkResponse_WhenDataFound()
//        {
//            // Arrange
//            var rewards = new List<RewardModel>();
//            _rewardServiceMock.Setup(x => x.GetAllRewards()).ReturnsAsync(rewards);

//            // Act
//            var result = await _controller.GetAllRewards();

//            // Assert
//            var Okresult = Assert.IsType<OkObjectResult>(result);
//            Assert.NotNull(result);
//            var returnedRewards = Assert.IsAssignableFrom<IEnumerable<RewardModel>>(Okresult.Value);
//            Assert.NotNull(returnedRewards);
//        }

//        [Fact]
//        public async Task GetRewards_ShouldReturnNotFound_WhenDataNotFound()
//        {
//            // Arrange
//            List<RewardModel> rewards = null;
//            _rewardServiceMock.Setup(x => x.GetAllRewards()).ReturnsAsync(rewards);

//            // Act
//            var result = await _controller.GetAllRewards();

//            // Assert
//            var notFoundResult = Assert.IsType<NotFoundResult>(result);
//            Assert.Equal(404, notFoundResult.StatusCode);
//        }
//    }
//}
