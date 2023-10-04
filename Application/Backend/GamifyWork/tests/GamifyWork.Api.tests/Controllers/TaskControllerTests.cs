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
    public class TaskControllerTests
    {
        private readonly Mock<ITaskService> _taskServiceMock;
        private readonly TaskController _controller;

        public TaskControllerTests()
        {
            _taskServiceMock = new Mock<ITaskService>();
            _controller = new TaskController(_taskServiceMock.Object);
        }

        [Fact]
        public async Task GetTasks_ShouldReturnOkResponse_WhenDataFound()
        {
            // Arrange
            var tasks = new List<TaskModel>();
            _taskServiceMock.Setup(x => x.GetAllTasks()).ReturnsAsync(tasks);

            // Act
            var result = await _controller.GetAllTasks();

            // Assert
            var Okresult = Assert.IsType<OkObjectResult>(result);
            Assert.NotNull(result);
            var returnedTasks = Assert.IsAssignableFrom<IEnumerable<TaskModel>>(Okresult.Value);
            Assert.NotNull(returnedTasks);
        }

        [Fact]
        public async Task GetTasks_ShouldReturnNotFound_WhenDataNotFound()
        {
            // Arrange
            List<TaskModel> tasks = null;
            _taskServiceMock.Setup(x => x.GetAllTasks()).ReturnsAsync(tasks);

            // Act
            var result = await _controller.GetAllTasks();

            // Assert
            var notFoundResult = Assert.IsType<NotFoundResult>(result);
            Assert.Equal(404, notFoundResult.StatusCode);
        }
    }
}
