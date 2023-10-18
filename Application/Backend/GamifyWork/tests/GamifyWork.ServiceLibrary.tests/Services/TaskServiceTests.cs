using GamifyWork.ServiceLibrary.Interfaces;
using GamifyWork.ServiceLibrary.Models;
using GamifyWork.ServiceLibrary.Services;
using Moq;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;

public class TaskServiceTests
{
    [Fact]
    public async Task GetAllTasks_ReturnsAllTasks()
    {
        // Arrange
        var mockRepository = new Mock<ITaskRepository>();
        var tasks = new List<TaskModel>
        {
            new TaskModel(1, "Task 1", "Description 1", 10, false, false, null, null, null, 1),
            new TaskModel(2, "Task 2", "Description 2", 20, false, false, null, null, null, 1),
            new TaskModel(3, "Task 3", "Description 3", 30, false, false, null, null, null, 2)
        };
        mockRepository.Setup(repo => repo.GetAllTasks()).ReturnsAsync(tasks);

        var taskService = new TaskService(mockRepository.Object);

        // Act
        var result = await taskService.GetAllTasks();

        // Assert
        Assert.Equal(3, result.Count()); 
    }

    [Fact]
    public async Task GetAllTasks_ThrowsException()
    {
        // Arrange
        var mockRepository = new Mock<ITaskRepository>();
        mockRepository.Setup(repo => repo.GetAllTasks()).ThrowsAsync(new Exception("An error occurred"));

        var taskService = new TaskService(mockRepository.Object);

        // Act and Assert
        await Assert.ThrowsAsync<Exception>(() => taskService.GetAllTasks());
    }
}
