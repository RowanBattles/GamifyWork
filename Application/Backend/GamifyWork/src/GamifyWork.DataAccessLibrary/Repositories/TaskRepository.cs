using GamifyWork.DataAccessLibrary.Data;
using GamifyWork.ServiceLibrary.Interfaces;
using GamifyWork.ServiceLibrary.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GamifyWork.DataAccessLibrary.Repositories
{
    public class TaskRepository : ITaskRepository
    {
        private readonly dbContext _dbContext;

        public TaskRepository(dbContext dbContext)
        {
             _dbContext = dbContext;
        }
        public async Task<List<TaskModel>> GetAllTasks()
        {
            using (_dbContext)
            {
                return await _dbContext.task.ToListAsync();
            }
        }

        public async Task CreateTask(TaskModel taskModel)
        {
            using (_dbContext)
            {
                await _dbContext.task.AddAsync(taskModel);
                //await _dbContext.SaveChangesAsync();
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