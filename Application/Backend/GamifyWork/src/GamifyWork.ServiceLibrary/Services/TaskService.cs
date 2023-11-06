using GamifyWork.ContractLayer.Dto;
using GamifyWork.ContractLayer.Interfaces;
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
    public class TaskService
    {
        private ITaskRepository _taskRepository;
        private ITaskMapperS _taskMapper;

        public TaskService(ITaskRepository taskRepository, ITaskMapperS taskMapperS)
        {
            _taskRepository = taskRepository;
            _taskMapper = taskMapperS;
        }

        public async Task<List<TaskModel>> GetAllTasks()
        {
            try
            {
                var taskDtos = await _taskRepository.GetAllTasks();
                var taskModels = _taskMapper.MapDtoToModelList(taskDtos);
                return taskModels;
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
                TaskDto taskDto = _taskMapper.MapModelToDto(taskModel);
                await _taskRepository.CreateTask(taskDto);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
