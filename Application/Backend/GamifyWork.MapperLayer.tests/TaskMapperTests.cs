using AutoMapper;
using GamifyWork.ContractLayer.Dto;
using GamifyWork.DataAccessLibrary.Entities;
using GamifyWork.MapperLayer.Mappers;
using GamifyWork.ServiceLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace GamifyWork.MapperLayer.tests
{
    public class TaskMapperTests
    {
        [Fact]
        public void MapModelToDto_ShouldMapCorrectly()
        {
            // Arrange
            var config = new MapperConfiguration(cfg => cfg.AddProfile<MappingProfile>());
            var mapper = config.CreateMapper();
            var taskMapper = new TaskMapper(mapper);

            var taskModel = new TaskModel(1, "Task 1", null, 10, false, false, null, null, null, 1);

            // Act
            var taskDto = taskMapper.MapModelToDto(taskModel);

            // Assert
            Assert.Equal(taskModel.Task_ID, taskDto.Task_ID);
            Assert.Equal(taskModel.Title, taskDto.Title);
            Assert.Equal(taskModel.Description, taskDto.Description);
            Assert.Equal(taskModel.Points, taskDto.Points);
            Assert.Equal(taskModel.Completed, taskDto.Completed);
            Assert.Equal(taskModel.Recurring, taskDto.Recurring);
            Assert.Equal(taskModel.RecurrenceInterval, taskDto.RecurrenceInterval);
            Assert.Equal(taskModel.RecurrenceType, taskDto.RecurrenceType);
            Assert.Equal(taskModel.NextDueDate, taskDto.NextDueDate);
            Assert.Equal(taskModel.User_ID, taskDto.User_ID);
        }

        [Fact]
        public void MapDtoToEntity_ShouldMapCorrectly()
        {
            // Arrange
            var config = new MapperConfiguration(cfg => cfg.AddProfile<MappingProfile>());
            var mapper = config.CreateMapper();
            var taskMapper = new TaskMapper(mapper);

            var taskDto = new TaskDto(1, "Task 1", null, 10, false, false, null, null, null, 1);

            // Act
            var taskEntity = taskMapper.MapDtoToEntity(taskDto);

            // Assert
            Assert.Equal(taskDto.Task_ID, taskEntity.Task_ID);
            Assert.Equal(taskDto.Title, taskEntity.Title);
            Assert.Equal(taskDto.Points, taskEntity.Points);
            Assert.Equal(taskDto.Completed, taskEntity.Completed);
            Assert.Equal(taskDto.Recurring, taskEntity.Recurring);
            Assert.Equal(taskDto.RecurrenceInterval, taskEntity.RecurrenceInterval);
            Assert.Equal(taskDto.RecurrenceType, taskEntity.RecurrenceType);
            Assert.Equal(taskDto.NextDueDate, taskEntity.NextDueDate);
            Assert.Equal(taskDto.User_ID, taskEntity.User_ID);
        }

        [Fact]
        public void MapEntityToDtoList_ShouldMapCorrectly()
        {
            // Arrange
            var config = new MapperConfiguration(cfg => cfg.AddProfile<MappingProfile>());
            var mapper = config.CreateMapper();
            var taskMapper = new TaskMapper(mapper);

            var taskEntities = new List<TaskEntity>
            {
                new TaskEntity(1, "Task 1", null, 10, false, false, null, null, null, 1),
                new TaskEntity(2, "Task 2", null, 20, false, false, null, null, null, 1),
            };

            // Act
            var taskDtos = taskMapper.MapEntityToDtoList(taskEntities);

            // Assert
            Assert.Equal(taskEntities.Count, taskDtos.Count);

            for (int i = 0; i < taskEntities.Count; i++)
            {
                Assert.Equal(taskEntities[i].Task_ID, taskDtos[i].Task_ID);
                Assert.Equal(taskEntities[i].Title, taskDtos[i].Title);
                Assert.Equal(taskEntities[i].Points, taskDtos[i].Points);
                Assert.Equal(taskEntities[i].Completed, taskDtos[i].Completed);
                Assert.Equal(taskEntities[i].Recurring, taskDtos[i].Recurring);
                Assert.Equal(taskEntities[i].RecurrenceType, taskDtos[i].RecurrenceType);
                Assert.Equal(taskEntities[i].RecurrenceInterval, taskDtos[i].RecurrenceInterval);
                Assert.Equal(taskEntities[i].NextDueDate, taskDtos[i].NextDueDate);
                Assert.Equal(taskEntities[i].User_ID, taskDtos[i].User_ID);
            }
        }

        [Fact]
        public void MapDtoToModelList_ShouldMapCorrectly()
        {
            // Arrange
            var config = new MapperConfiguration(cfg => cfg.AddProfile<MappingProfile>());
            var mapper = config.CreateMapper();
            var taskMapper = new TaskMapper(mapper);

            var taskDtos = new List<TaskDto>
            {
                new TaskDto(1, "Task 1", null, 10, false, false, null, null, null, 1),
                new TaskDto(2, "Task 2", null, 20, false, false, null, null, null, 1),
            };

            // Act
            var taskModels = taskMapper.MapDtoToModelList(taskDtos);

            // Assert
            Assert.Equal(taskDtos.Count, taskModels.Count);

            for (int i = 0; i < taskDtos.Count; i++)
            {
                Assert.Equal(taskModels[i].Task_ID, taskDtos[i].Task_ID);
                Assert.Equal(taskModels[i].Title, taskDtos[i].Title);
                Assert.Equal(taskModels[i].Points, taskDtos[i].Points);
                Assert.Equal(taskModels[i].Completed, taskDtos[i].Completed);
                Assert.Equal(taskModels[i].Recurring, taskDtos[i].Recurring);
                Assert.Equal(taskModels[i].RecurrenceType, taskDtos[i].RecurrenceType);
                Assert.Equal(taskModels[i].RecurrenceInterval, taskDtos[i].RecurrenceInterval);
                Assert.Equal(taskModels[i].NextDueDate, taskDtos[i].NextDueDate);
                Assert.Equal(taskModels[i].User_ID, taskDtos[i].User_ID);
            }
        }
    }

}
