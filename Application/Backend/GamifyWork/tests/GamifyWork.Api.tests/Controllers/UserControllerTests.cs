using GamifyWork.API.Controllers;
using GamifyWork.ServiceLibrary.Interfaces;
using GamifyWork.ServiceLibrary.Models;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace GamifyWork.Api.tests.Controllers
{
    public class UserControllerTests
    {
        private readonly Mock<IUserService> _userService;
        private readonly UserController _controller;
        public UserControllerTests()
        {
            _userService = new Mock<IUserService>();
            _controller = new UserController(_userService.Object);
        }

        [Fact]
        public async Task GetAllUsers_ShouldReturnOkResponse_WhenDataFound()
        {
            // Arrange
            var users = new List<UserModel>();
            _userService.Setup(x => x.GetAllFriendsByUser(new Guid())).ReturnsAsync(users);

            // Act
            var result = await _controller.GetAllFriendsByUser(new Guid());

            // Assert
            var Okresult = Assert.IsType<OkObjectResult>(result);
            Assert.NotNull(result);
            var returnedUsers = Assert.IsAssignableFrom<IEnumerable<UserModel>>(Okresult.Value);
            Assert.NotNull(returnedUsers);
        }

        [Fact]
        public async Task GetUserById_ShouldReturnOkResponse_WHenDataFound()
        {
            // Arrange
            var user = new UserModel(new Guid(), 0);
            _userService.Setup(x => x.GetUserById(new Guid())).ReturnsAsync(user);

            // Act
            var result = await _controller.GetUserById(new Guid());

            // Assert
            var Okresult = Assert.IsType<OkObjectResult>(result);
            Assert.NotNull(result);
            var returnedUser = Assert.IsAssignableFrom<UserModel>(Okresult.Value);
            Assert.NotNull(returnedUser);
        }

        [Fact]
        public async Task CreateUser_ShouldReturnOkResponse_WhenModelStateIsValid()
        {
            // Arrange & Act 
            var result = await _controller.CreateUser(new Guid());

            // Assert
            Assert.IsType<OkResult>(result);
            Assert.NotNull(result);
        }
    }
}
