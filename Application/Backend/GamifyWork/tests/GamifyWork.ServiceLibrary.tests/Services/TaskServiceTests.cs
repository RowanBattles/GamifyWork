using GamifyWork.ServiceLibrary.Interfaces;
using GamifyWork.ServiceLibrary.Models;
using GamifyWork.ServiceLibrary.Services;
using Moq;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;
using GamifyWork.ContractLayer.Interfaces;
using GamifyWork.ContractLayer.Dto;
using GamifyWork.ServiceLibrary.Exceptions;
using Microsoft.Extensions.Logging;

public class TaskServiceTests
{
    DateTime _currentTime = DateTime.Now;
    Mock<ITaskRepository> _mockRepository;
    Mock<ITaskMapperS> _mockMapper;
    Mock<ILogger<TaskService>> _mockLogger;

    public TaskServiceTests()
    {
        _mockRepository = new Mock<ITaskRepository>();
        _mockMapper = new Mock<ITaskMapperS>();
        _mockLogger = new Mock<ILogger<TaskService>>();
    }

    [Fact]
    public async Task GetAllTasks_ReturnsAllTasks()
    {
        // Arrange
        var taskDtos = new List<TaskDto>
        {
            new TaskDto(1, "Task 1", "Description 1", 10, false, true, "daily", 3, _currentTime, 1),
            new TaskDto(2, "Task 2", "Description 2", 20, true, false, null, null, null, 1),
            new TaskDto(3, "Task 3", "Description 3", 30, false, false, null, null, null, 2)
        };

        _mockRepository.Setup(repo => repo.GetAllTasks()).ReturnsAsync(taskDtos);
        _mockMapper.Setup(mapper => mapper.MapDtoToModelList(taskDtos))
                     .Returns(taskDtos.Select(dto => new TaskModel(
                         dto.Task_ID,
                         dto.Title,
                         dto.Description,
                         dto.Points,
                         dto.Completed,
                         dto.Recurring,
                         dto.RecurrenceType,
                         dto.RecurrenceInterval,
                         dto.NextDueDate,
                         dto.User_ID
                     )).ToList());

        var taskService = new TaskService(_mockRepository.Object, _mockMapper.Object, _mockLogger.Object);


        // Act
        var result = await taskService.GetAllTasks();

        // Assert
        Assert.Contains(result, task => task.Task_ID == 1);
        Assert.Contains(result, task => task.Task_ID == 2);
        Assert.Contains(result, task => task.Task_ID == 3);

        Assert.Equal(3, result.Count());

        Assert.Equal("Task 1", result[0].Title);
        Assert.Equal("Task 2", result[1].Title);
        Assert.Equal("Task 3", result[2].Title);
        Assert.Equal("Description 1", result[0].Description);
        Assert.Equal("Description 2", result[1].Description);
        Assert.Equal("Description 3", result[2].Description);
        Assert.Equal(10, result[0].Points);
        Assert.Equal(20, result[1].Points);
        Assert.Equal(30, result[2].Points);
        Assert.False(result[0].Completed);
        Assert.True(result[1].Completed);
        Assert.False(result[2].Completed);
        Assert.True(result[0].Recurring);
        Assert.False(result[1].Recurring);
        Assert.False(result[2].Recurring);
        Assert.Equal("daily", result[0].RecurrenceType);
        Assert.Null(result[1].RecurrenceType);
        Assert.Null(result[2].RecurrenceType);
        Assert.Equal(3, result[0].RecurrenceInterval);
        Assert.Null(result[1].RecurrenceInterval);
        Assert.Null(result[2].RecurrenceInterval);
        Assert.Equal(_currentTime, result[0].NextDueDate);
        Assert.Null(result[1].NextDueDate);
        Assert.Null(result[2].NextDueDate);
        Assert.Equal(1, result[0].User_ID);
        Assert.Equal(1, result[1].User_ID);
        Assert.Equal(2, result[2].User_ID);
    }

    [Fact]
    public async Task GetAllTasks_ReturnsEmptyList()
    {
        // Arrange
        var emptyTasks = new List<TaskDto>();
        _mockRepository.Setup(repo => repo.GetAllTasks()).ReturnsAsync(emptyTasks);
        _mockMapper.Setup(mapper => mapper.MapDtoToModelList(emptyTasks))
                     .Returns(emptyTasks.Select(dto => new TaskModel(
                         dto.Task_ID,
                         dto.Title,
                         dto.Description,
                         dto.Points,
                         dto.Completed,
                         dto.Recurring,
                         dto.RecurrenceType,
                         dto.RecurrenceInterval,
                         dto.NextDueDate,
                         dto.User_ID
                     )).ToList());

        var taskService = new TaskService(_mockRepository.Object, _mockMapper.Object, _mockLogger.Object);

        // Act
        var result = await taskService.GetAllTasks();

        // Assert
        Assert.Empty(result);
    }

    [Fact]
    public async Task GetAllTasks_ThrowsTaskException()
    {
        // Arrange
        _mockRepository.Setup(repo => repo.GetAllTasks()).ThrowsAsync(new Exception("An error occurred"));
        var taskService = new TaskService(_mockRepository.Object, _mockMapper.Object, _mockLogger.Object);

        // Act and Assert
        await Assert.ThrowsAsync<TaskException>(() => taskService.GetAllTasks());
    }

    [Fact]
    public async Task CreateTask_SetsPointsAndCallsRepository()
    {
        // Arrange
        var taskModel = new TaskModel(1, "Task 1", "Description 1", null, false, true, "daily", 3, DateTime.Now, 1);

        _mockMapper.Setup(mapper => mapper.MapModelToDto(taskModel))
                  .Returns(new TaskDto(
                      taskModel.Task_ID,
                      taskModel.Title,
                      taskModel.Description,
                      taskModel.Points ?? 0,
                      taskModel.Completed,
                      taskModel.Recurring,
                      taskModel.RecurrenceType,
                      taskModel.RecurrenceInterval,
                      taskModel.NextDueDate,
                      taskModel.User_ID
                  ));

        var taskService = new TaskService(_mockRepository.Object, _mockMapper.Object, _mockLogger.Object);

        // Act
        await taskService.CreateTask(taskModel);

        // Assert
        _mockMapper.Verify(mapper => mapper.MapModelToDto(taskModel), Times.Once);
        _mockRepository.Verify(repo => repo.CreateTask(It.IsAny<TaskDto>()), Times.Once);
    }

    [Fact]
    public async Task CreateTask_CallsSetPointsBeforeMapping()
    {
        // Arrange
        var taskModel = new TaskModel(1, "Task 1", "Description 1", null, false, true, "daily", 3, DateTime.Now, 1);

        _mockMapper.Setup(mapper => mapper.MapModelToDto(taskModel))
                  .Returns(new TaskDto(
                      taskModel.Task_ID,
                      taskModel.Title,
                      taskModel.Description,
                      taskModel.Points ?? 0,
                      taskModel.Completed,
                      taskModel.Recurring,
                      taskModel.RecurrenceType,
                      taskModel.RecurrenceInterval,
                      taskModel.NextDueDate,
                      taskModel.User_ID
                  ));

        var taskService = new TaskService(_mockRepository.Object, _mockMapper.Object, _mockLogger.Object);

        // Act
        await taskService.CreateTask(taskModel);

        // Assert
        Assert.NotNull(taskModel.Points);
        _mockMapper.Verify(mapper => mapper.MapModelToDto(taskModel), Times.Once);
    }

    [Fact]
    public async Task CreateTask_ShouldThrowException()
    {
        // Arrange
        TaskDto taskDto = new(1, "this", null, 10, false, false, null, null, null, 1);
        TaskModel taskModel = new(1, "this", null, 10, false, false, null, null, null, 1);
        _mockRepository.Setup(repo => repo.CreateTask(taskDto)).ThrowsAsync(new Exception("An error occurred"));
        var taskService = new TaskService(_mockRepository.Object, _mockMapper.Object, _mockLogger.Object);

        // Act and Assert
        await Assert.ThrowsAsync<TaskException>(() => taskService.CreateTask(taskModel));
    }

}
