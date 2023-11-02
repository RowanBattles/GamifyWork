using GamifyWork.ServiceLibrary.Interfaces;
using GamifyWork.ServiceLibrary.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GamifyWork.ServiceLibrary.Services
{
    public class TaskService : ITaskService
    {
        private readonly ITaskRepository _taskRepository;

        public TaskService(ITaskRepository taskRepository)
        {
            _taskRepository = taskRepository;
        }
        public async Task<List<TaskModel>> GetAllTasks()
        {
            try
            {
                return await _taskRepository.GetAllTasks();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task CreateTask(TaskModel taskModel)
        {
            try
            {
                taskModel.setPoints();
                await _taskRepository.CreateTask(taskModel);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
