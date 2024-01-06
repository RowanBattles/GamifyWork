using GamifyWork.ServiceLibrary.Exceptions;
using GamifyWork.ServiceLibrary.Models;
using System;
using Xunit;

public class TaskModelTests
{
    [Fact]
    public void TaskModel_PropertiesAreSetCorrectly()
    {
        // Arrange
        int taskId = 1;
        string title = "Task 1";
        string description = "Description 1";
        int points = 10;
        bool completed = false;
        bool recurring = false;
        string? recurrenceType = null;
        int? recurrenceInterval = null;
        DateTime? nextDueDate = null;
        Guid user = new("6B29FC40-CA47-1067-B31D-00DD010662DA");

        // Act
        var taskModel = new TaskModel(taskId, title, description, points, completed, recurring, recurrenceType, recurrenceInterval, nextDueDate, user);

        // Assert
        Assert.Equal(taskId, taskModel.Task_ID);
        Assert.Equal(title, taskModel.Title);
        Assert.Equal(description, taskModel.Description);
        Assert.Equal(points, taskModel.Points);
        Assert.Equal(completed, taskModel.Completed);
        Assert.Equal(recurring, taskModel.Recurring);
        Assert.Equal(recurrenceType, taskModel.RecurrenceType);
        Assert.Equal(recurrenceInterval, taskModel.RecurrenceInterval);
        Assert.Equal(nextDueDate, taskModel.NextDueDate);
        Assert.Equal(user, taskModel.User);
    }

    [Fact]
    public void CalculateNextDueDate_NotRecurring_ReturnsNextDueDate()
    {
        // Arrange
        int taskId = 1;
        string title = "Task 1";
        string description = "Description 1";
        int points = 10;
        bool completed = false;
        bool recurring = false;
        string? recurrenceType = null;
        int? recurrenceInterval = null;
        DateTime? nextDueDate = null;
        Guid user = new("6B29FC40-CA47-1067-B31D-00DD010662DA");

        var taskModel = new TaskModel(taskId, title, description, points, completed, recurring, recurrenceType, recurrenceInterval, nextDueDate, user);

        // Act
        taskModel.MarkTask();

        // Assert
        Assert.Null(taskModel.NextDueDate);
    }

    [Theory]
    [InlineData("Daily", 1, 1)]
    [InlineData("Weekly", 2, 14)]
    [InlineData("Monthly", 3, 91)]
    public void CalculateNextDueDate_ShouldSetCorrectNextDueDate(string RecurrenceType, int RecurrenceInterval, int expectedDays)
    {
        // Arrange
        int taskId = 1;
        string title = "Task 1";
        string description = "Description 1";
        int points = 10;
        bool completed = false;
        bool recurring = true;
        string? recurrenceType = RecurrenceType;
        int? recurrenceInterval = RecurrenceInterval;
        DateTime? nextDueDate = null;
        Guid user = new("6B29FC40-CA47-1067-B31D-00DD010662DA");

        var taskModel = new TaskModel(taskId, title, description, points, completed, recurring, recurrenceType, recurrenceInterval, nextDueDate, user);

        // Act
        taskModel.MarkTask();
        var actualDate = (DateTime)taskModel.NextDueDate;

        // Assert
        Assert.Equal(DateTime.Now.AddDays(expectedDays).ToString("yyyy-mm-dd"), actualDate.ToString("yyyy-mm-dd"));
    }

    [Fact]
    public void CalculateNextDueDate_InvalidRecurrenceType_ThrowsException()
    {
        // Arrange
        int taskId = 1;
        string title = "Task 1";
        string? description = null;
        int? points = null;
        bool completed = false;
        bool recurring = true;
        string? recurrenceType = "invalid";
        int recurrenceInterval = 2;
        DateTime nextDueDate = new(2023, 10, 1, 12, 0, 0);
        Guid user = new("6B29FC40-CA47-1067-B31D-00DD010662DA");

        var taskModel = new TaskModel(taskId, title, description, points, completed, recurring, recurrenceType, recurrenceInterval, nextDueDate, user);

        // Act and Assert
        Assert.Throws<TaskException>(() => taskModel.MarkTask());
    }
}
