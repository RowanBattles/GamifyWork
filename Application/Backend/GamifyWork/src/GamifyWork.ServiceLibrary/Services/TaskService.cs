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
                return _taskMapper.MapDtoToModelList(await _taskRepository.GetAllTasks());
            }
            catch(Exception ex)
            {
                _logger.LogError(ex, "An unexpected error occurred while retrieving tasks in service");
                throw new TaskException("Error retrieving tasks", (int)HttpStatusCode.InternalServerError);
            }
        }

        public async Task CreateTask(TaskModel taskModel)
        {
            try
            {
                taskModel.SetPoints();
                await _taskRepository.CreateTask(_taskMapper.MapModelToDto(taskModel));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An unexpected error occurred while creating a task in service");
                throw new TaskException("Error creating task", (int)HttpStatusCode.InternalServerError);
            }
        }
    }
}
