using GamifyWork.API.Controllers;
using GamifyWork.API.Middleware;
using GamifyWork.ServiceLibrary.Exceptions;
using GamifyWork.ServiceLibrary.Interfaces;
using GamifyWork.ServiceLibrary.Models;
using GamifyWork.ServiceLibrary.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace GamifyWork.Api.tests.Controllers
{
    public class TaskControllerTests
    {
        Guid user = new("6B29FC40-CA47-1067-B31D-00DD010662DA");
        private readonly Mock<ITaskService> _taskService;
        private readonly TaskController _controller;

        public TaskControllerTests()
        {
            _taskService = new Mock<ITaskService>();
            _controller = new TaskController(_taskService.Object);
        }

        [Fact]
        public async Task GetTasks_ShouldReturnOkResponse_WhenDataFound()
        {
            // Arrange
            var tasks = new List<TaskModel>();
            _taskService.Setup(x => x.GetAllTasks()).ReturnsAsync(tasks);

            // Act
            var result = await _controller.GetAllTasks();

            // Assert
            var Okresult = Assert.IsType<OkObjectResult>(result);
            Assert.NotNull(result);
            var returnedTasks = Assert.IsAssignableFrom<IEnumerable<TaskModel>>(Okresult.Value);
            Assert.NotNull(returnedTasks);
        }

        [Fact]
        public async Task CreateTask_ReturnsOk_WhenModelStateIsValid()
        {
            // Arrange
            var taskModel = new TaskModel(1, "title", null, null, false, false, null, null, null, user);

            // Act
            var result = await _controller.CreateTask(taskModel);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            Assert.Equal(StatusCodes.Status200OK, okResult.StatusCode);
        }

        [Fact]
        public async Task MarkTask_ReturnsOk_WhenIdIsValid()
        {
            // Arrange
            var id = 1;

            // Act
            var result = await _controller.MarkTask(id);

            // Assert
            Assert.Equal(StatusCodes.Status200OK, ((OkResult)result).StatusCode);
        }
    }
}
