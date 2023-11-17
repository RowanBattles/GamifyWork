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
            await _dbContext.task.AddAsync(_taskMapper.MapDtoToEntity(taskDto));
            await _dbContext.SaveChangesAsync();
        }
    }
}

//public async Task<TaskModel> GetTaskById(int Id)
//{
//    using (var db = new dbContext())
//    {
//        return await db.Tasks.FirstOrDefaultAsync(task => task.Task_ID == Id);
//    }
//}

        

//public async Task<bool> UpdateTask(TaskModel taskModel)
//{
//    using (var db = new dbContext())
//    {
//        try
//        {
//            db.Tasks.Update(taskModel);

//            return await db.SaveChangesAsync() >= 1;
//        }
//        catch (Exception ex)
//        {
//            return false;
//        }
//    }
//}

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