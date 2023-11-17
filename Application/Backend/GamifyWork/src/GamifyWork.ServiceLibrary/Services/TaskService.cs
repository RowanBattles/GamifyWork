using GamifyWork.ContractLayer.Interfaces;
using GamifyWork.ServiceLibrary.Exceptions;
using GamifyWork.ServiceLibrary.Interfaces;
using GamifyWork.ServiceLibrary.Models;
using Microsoft.Extensions.Logging;
using System.Net;

namespace GamifyWork.ServiceLibrary.Services
{
    public class TaskService : ITaskService
    {
        private readonly ITaskRepository _taskRepository;
        private readonly ITaskMapperS _taskMapper;
        private readonly ILogger<TaskService> _logger;

        public TaskService(ITaskRepository taskRepository, ITaskMapperS taskMapperS, ILogger<TaskService> logger)
        {
            _taskRepository = taskRepository;
            _taskMapper = taskMapperS;
            _logger = logger;
        }

        public async Task<List<TaskModel>> GetAllTasks()
        {
            try
            {
                var tasks = await _taskRepository.GetAllTasks();
                return _taskMapper.MapDtoToModelList(tasks);
            }
            catch(Exception ex)
            {
                _logger.LogError(ex, "An unexpected error occurred while retrieving tasks in service");
                throw new TaskException("Error retrieving tasks", (int)HttpStatusCode.InternalServerError);
            }
        }

        public async Task CreateTask(TaskModel taskModel)
        {
            taskModel.setPoints();
            await _taskRepository.CreateTask(_taskMapper.MapModelToDto(taskModel));
        }
    }
}
