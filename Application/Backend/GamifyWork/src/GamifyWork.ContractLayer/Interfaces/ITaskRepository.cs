using GamifyWork.ContractLayer.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GamifyWork.ContractLayer.Interfaces
{
    public interface ITaskRepository
    {
        Task<List<TaskDto>> GetAllTasks();
        Task CreateTask(TaskDto taskDto);
        Task<TaskDto> GetTaskById(int Id);
        Task MarkTask(TaskDto taskDto);
        Task<List<TaskDto>> GetAllTasksByUser(Guid user);
        Task DeleteTask(int Id);
    }
}
