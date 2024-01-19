using GamifyWork.ContractLayer.Dto;
using GamifyWork.ContractLayer.Interfaces;
using GamifyWork.ServiceLibrary.Helpers;
using GamifyWork.ServiceLibrary.Interfaces;
using GamifyWork.ServiceLibrary.Models;
using GamifyWork.ServiceLibrary.Services;
using Microsoft.Extensions.Logging;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace GamifyWork.ServiceLibrary.tests.Services
{
    public class UserServiceTests
    {
        Mock<IUserRepository> _mockRepository;
        Mock<IUserMapperS> _mockMapper;
        Mock<ILogger<UserService>> _mockLogger;
        Mock<IKeycloakLogic> _mockKeycloak;

        public UserServiceTests()
        {
            _mockRepository = new Mock<IUserRepository>();
            _mockMapper = new Mock<IUserMapperS>();
            _mockLogger = new Mock<ILogger<UserService>>();
            _mockKeycloak = new Mock<IKeycloakLogic>();
        }

        [Fact]
        public async Task GetAllFriendsByUser_ReturnAllFriends()
        {
            // Arrange

            var users = new List<UserDto>
            {
                new UserDto(new Guid("6B29FC40-CA47-1067-B31D-00DD010662DA"), 0),
                new UserDto(new Guid("6B29FC40-CA47-1067-B31D-00DD010662DB"), 10),
                new UserDto(new Guid("6B29FC40-CA47-1067-B31D-00DD010662DC"), 100)
            };

            _mockRepository.Setup(x => x.GetAllFriendsByUser()).ReturnsAsync(users);
            _mockMapper.Setup(x => x.MapDtosToModels(users))
                .Returns(users.Select(dto => new UserModel(
                    dto.User_ID,
                    dto.Points
                )).ToList());

            var keycloakLogicMock = new Mock<IKeycloakLogic>();
            keycloakLogicMock.Setup(x => x.AddUsernamesForUsers(It.IsAny<List<UserModel>>()))
                .ReturnsAsync((List<UserModel> models) =>
                {
                    foreach (var model in models)
                    {
                        model.SetUsername($"Username_{model.User_ID}");
                    }
                    return models;
                });

            _mockKeycloak.Setup(x => x.AddUsernamesForUsers(It.IsAny<List<UserModel>>()))
                .ReturnsAsync((List<UserModel> models) =>
                {
                    foreach (var model in models)
                    {
                        model.SetUsername($"Username_{model.User_ID}");
                    }
                    return models;
                });

            var userService = new UserService(_mockKeycloak.Object, _mockRepository.Object, _mockMapper.Object, _mockLogger.Object);
        
            // Act
            var result = await userService.GetAllFriendsByUser(new Guid("6B29FC40-CA47-1067-B31D-00DD010662DA"));

            // Assert
            Assert.Contains(result, u => u.User_ID == new Guid("6B29FC40-CA47-1067-B31D-00DD010662DB"));
            Assert.Contains(result, u => u.User_ID == new Guid("6B29FC40-CA47-1067-B31D-00DD010662DC"));

            Assert.Equal(2, result.Count);

            Assert.Equal("6B29FC40-CA47-1067-B31D-00DD010662DB", result[0].User_ID.ToString(), StringComparer.OrdinalIgnoreCase);
            Assert.Equal("6B29FC40-CA47-1067-B31D-00DD010662DC", result[1].User_ID.ToString(), StringComparer.OrdinalIgnoreCase);
            Assert.Equal(10, result[0].Points);
            Assert.Equal(100, result[1].Points);
        }

        [Fact]
        public async Task GetAllFriendsByUser_ReturnEmptyList()
        {
            // Arrange

            var users = new List<UserDto>
            {
                new UserDto(new Guid("6B29FC40-CA47-1067-B31D-00DD010662DA"), 0),
            };

            _mockRepository.Setup(x => x.GetAllFriendsByUser()).ReturnsAsync(users);
            _mockMapper.Setup(x => x.MapDtosToModels(users))
                .Returns(users.Select(dto => new UserModel(
                    dto.User_ID,
                    dto.Points
                )).ToList());

            var keycloakLogicMock = new Mock<IKeycloakLogic>();
            keycloakLogicMock.Setup(x => x.AddUsernamesForUsers(It.IsAny<List<UserModel>>()))
                .ReturnsAsync((List<UserModel> models) =>
                {
                    foreach (var model in models)
                    {
                        model.SetUsername($"Username_{model.User_ID}");
                    }
                    return models;
                });

            _mockKeycloak.Setup(x => x.AddUsernamesForUsers(It.IsAny<List<UserModel>>()))
                .ReturnsAsync((List<UserModel> models) =>
                {
                    foreach (var model in models)
                    {
                        model.SetUsername($"Username_{model.User_ID}");
                    }
                    return models;
                });

            var userService = new UserService(_mockKeycloak.Object, _mockRepository.Object, _mockMapper.Object, _mockLogger.Object);

            // Act
            var result = await userService.GetAllFriendsByUser(new Guid("6B29FC40-CA47-1067-B31D-00DD010662DA"));

            // Assert
            Assert.Empty(result);
        }

    }
}
