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
        int userId = 1;

        // Act
        var taskModel = new TaskModel(taskId, title, description, points, completed, recurring, recurrenceType, recurrenceInterval, nextDueDate, userId);

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
        Assert.Equal(userId, taskModel.User_ID);
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
        int userId = 1;

        var taskModel = new TaskModel(taskId, title, description, points, completed, recurring, recurrenceType, recurrenceInterval, nextDueDate, userId);

        // Act
        var CalculatenextDueDate = taskModel.CalculateNextDueDate();

        // Assert
        Assert.Equal(taskModel.NextDueDate, CalculatenextDueDate);
    }

    [Fact]
    public void CalculateNextDueDate_RecurringDailyWithInterval1_ReturnsCorrectNextDueDate()
    {
        // Arrange
        int taskId = 1;
        string title = "Task 1";
        string description = "Description 1";
        int points = 10;
        bool completed = false;
        bool recurring = true;
        string recurrenceType = "daily";
        int recurrenceInterval = 1;
        DateTime? nextDueDate = new DateTime(2023, 10, 1, 12, 0, 0); // October 1, 2023, 12:00 PM
        int userId = 1;

        var taskModel = new TaskModel(taskId, title, description, points, completed, recurring, recurrenceType, recurrenceInterval, nextDueDate, userId);

        // Act
        var nextDueDateResult = taskModel.CalculateNextDueDate();

        // Assert
        var expectedNextDueDate = nextDueDate.Value.AddDays(1); // Assuming recurrence interval is specified in days
        Assert.Equal(expectedNextDueDate, nextDueDateResult);
    }
}
