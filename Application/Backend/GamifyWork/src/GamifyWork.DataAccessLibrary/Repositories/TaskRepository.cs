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

namespace GamifyWork.DataAccessLibrary.Repositories
{
    public class TaskRepository : ITaskRepository
    {
        private readonly dbContext _dbContext;
        private ITaskMapperD _taskMapper; 

        public TaskRepository(dbContext dbContext, ITaskMapperD taskMapperD)
        {
             _dbContext = dbContext;
            _taskMapper = taskMapperD;
        }

        public async Task<List<TaskDto>> GetAllTasks()
        {
            var taskEntities = await _dbContext.task.ToListAsync();
            return _taskMapper.MapEntityToDtoList(taskEntities);
        }

        public async Task CreateTask(TaskDto taskDto)
        {
            try
            {
                TaskEntity taskEntity = _taskMapper.MapDtoToEntity(taskDto);
                await _dbContext.task.AddAsync(taskEntity);
                await _dbContext.SaveChangesAsync();
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
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