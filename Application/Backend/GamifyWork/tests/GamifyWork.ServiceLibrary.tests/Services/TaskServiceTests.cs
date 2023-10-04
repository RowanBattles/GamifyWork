using GamifyWork.ServiceLibrary.Interfaces;
using GamifyWork.ServiceLibrary.Models;
using GamifyWork.ServiceLibrary.Services;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace GamifyWork.ServiceLibrary.tests.Services
{
    public class TaskServiceTests
    {
        private readonly Mock<ITaskRepository> _taskRepositoryMock;
        private readonly ITaskService _taskService;

        public TaskServiceTests()
        {
            _taskRepositoryMock = new Mock<ITaskRepository>();
            _taskService = new TaskService(_taskRepositoryMock.Object);
        }

        private readonly TaskModel mockTask1 = new(1, "title 1", null, 10, false, false, null, null, null, 1);
        private readonly TaskModel mockTask2 = new(1, "title 2", "this description", 20, true, true, "weekly", 2, DateTime.Today, 1);
        

        [Fact]
        public void GetTasks_ShouldReturnData_WhenDataFound()
        {
            // Arrange
            List<TaskModel> MockTasks = new();
            MockTasks.Add(mockTask1);
            MockTasks.Add(mockTask2);

            _taskRepositoryMock.Setup(x => x.GetAllTasks()).ReturnsAsync(MockTasks);

            // Act

            // Assert
        }
    }
}
