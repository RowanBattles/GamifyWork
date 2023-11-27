using GamifyWork.DataAccessLibrary.Data;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using GamifyWork.DataAccessLibrary.Entities;
using GamifyWork.ContractLayer.Interfaces;
using GamifyWork.ContractLayer.Dto;
using GamifyWork.DataAccessLibrary.Interfaces;
using Microsoft.Extensions.Logging;
using System.Data.Common;
using System.Net;

namespace GamifyWork.DataAccessLibrary.Repositories
{
    public class TaskRepository : ITaskRepository
    {
        private readonly dbContext _dbContext;
        private readonly ITaskMapperD _taskMapper;
        private readonly ILogger<TaskRepository> _logger;

        public TaskRepository(dbContext dbContext, ITaskMapperD taskMapperD, ILogger<TaskRepository> logger)
        {
             _dbContext = dbContext;
            _taskMapper = taskMapperD;
            _logger = logger;
        }

        private async Task <TaskEntity> GetTaskEntityById(int Id)
        {
            try
            {
                return await _dbContext.task.FindAsync(Id) ?? throw new Exception("Task not found");
            }
            catch
            {
                _logger.LogError("An unexpected error occurred while retrieving a task in repository");
                throw;
            }
        }

        public async Task<List<TaskDto>> GetAllTasks()
        {
            try
            {
                return _taskMapper.MapEntityToDtoList(await _dbContext.task.ToListAsync());
            }
            catch
            {
                _logger.LogError("An unexpected error occurred while processing tasks in repository");
                throw;
            }  
        }

        public async Task CreateTask(TaskDto taskDto)
        {
            try
            {
                await _dbContext.task.AddAsync(_taskMapper.MapDtoToEntity(taskDto));
                await _dbContext.SaveChangesAsync();
            }
            catch
            {
                _logger.LogError("An unexpected error occurred while creating a task in repository");
                throw;
            }
        }

        public async Task<TaskDto> GetTaskById(int Id)
        {
            try
            {
                var taskEntity = await _dbContext.task.FindAsync(Id);
                return taskEntity == null ? throw new Exception("Task not found in repository") : _taskMapper.MapEntityToDto(taskEntity);
            }
            catch
            {
                _logger.LogError("An unexpected error occurred while retrieving a task in repository");
                throw;
            }
        }

        public async Task MarkTask(TaskDto taskDto)
        {
            try
            {
                TaskEntity existingEntity = await GetTaskEntityById(taskDto.Task_ID);

                existingEntity.Completed = taskDto.Completed;
                existingEntity.NextDueDate = taskDto.NextDueDate;

                _dbContext.Entry(existingEntity).State = EntityState.Modified;
                await _dbContext.SaveChangesAsync();
            }
            catch
            {
                _logger.LogError("An unexpected error occurred while marking a task in repository");
                throw;
            }
        }

    }
}

//public async Task<bool> DeleteTask(int Id)
//{
//    using (var db = new dbContext())
//    {
//        try
//        {
//            TaskModel taskModel = await GetTaskById(Id);
                    
//            db.Remove(taskModel);

//            return await db.SaveChangesAsync() >= 1;
//        }
//        catch (Exception ex)
//        {
//            return false;
//        }
//    }
//}