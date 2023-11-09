using GamifyWork.ServiceLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GamifyWork.ServiceLibrary.Interfaces
{
    public interface ITaskService
    {
        Task<List<TaskModel>> GetAllTasks();
        Task CreateTask(TaskModel taskModel);
    }
}
