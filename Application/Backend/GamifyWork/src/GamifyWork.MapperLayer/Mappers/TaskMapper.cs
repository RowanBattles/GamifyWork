using GamifyWork.ContractLayer.Dto;
using GamifyWork.DataAccessLibrary.Entities;
using GamifyWork.DataAccessLibrary.Interfaces;
using GamifyWork.ServiceLibrary.Interfaces;
using GamifyWork.ServiceLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GamifyWork.MapperLayer.Mappers
{
    public class TaskMapper : ITaskMapperS, ITaskMapperD
    {
        public TaskDto MapModelToDto(TaskModel taskModel)
        {
            return new(
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
            );
        }

        public TaskEntity MapDtoToEntity(TaskDto taskDto)
        {
            return new(
                taskDto.Task_ID,
                taskDto.Title,
                taskDto.Description,
                taskDto.Points,
                taskDto.Completed,
                taskDto.Recurring,
                taskDto.RecurrenceType,
                taskDto.RecurrenceInterval,
                taskDto.NextDueDate,
                taskDto.User_ID
            );
        }

        public List<TaskDto> MapEntityToDtoList(List<TaskEntity> taskEntities)
        {
            return taskEntities.Select(taskEntity => new TaskDto(
                taskEntity.Task_ID,
                taskEntity.Title,
                taskEntity.Description,
                taskEntity.Points,
                taskEntity.Completed,
                taskEntity.Recurring,
                taskEntity.RecurrenceType,
                taskEntity.RecurrenceInterval,
                taskEntity.NextDueDate,
                taskEntity.User_ID
                )).ToList();
        }

        public List<TaskModel> MapDtoToModelList(List<TaskDto> taskDtos)
        {
            return taskDtos.Select(taskModel => new TaskModel(
                taskModel.Task_ID,
                taskModel.Title,
                taskModel.Description,
                taskModel.Points,
                taskModel.Completed,
                taskModel.Recurring,
                taskModel.RecurrenceType,
                taskModel.RecurrenceInterval,
                taskModel.NextDueDate,
                taskModel.User_ID
                )).ToList();
        }
    }
}
