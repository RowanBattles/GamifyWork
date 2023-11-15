﻿using GamifyWork.ContractLayer.Dto;
using GamifyWork.ContractLayer.Interfaces;
using GamifyWork.ServiceLibrary.Exceptions;
using GamifyWork.ServiceLibrary.Interfaces;
using GamifyWork.ServiceLibrary.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace GamifyWork.ServiceLibrary.Services
{
    public class TaskService : ITaskService
    {
        private readonly ITaskRepository _taskRepository;
        private readonly ITaskMapperS _taskMapper;

        public TaskService(ITaskRepository taskRepository, ITaskMapperS taskMapperS)
        {
            _taskRepository = taskRepository;
            _taskMapper = taskMapperS;
        }

        public async Task<List<TaskModel>> GetAllTasks()
        {
            try
            {
                var tasks = await _taskRepository.GetAllTasks();
                return _taskMapper.MapDtoToModelList(tasks);
            }
            catch
            {
                throw new TaskException("Error retrieving tasks", (int)HttpStatusCode.BadRequest);
            }
        }

        public async Task CreateTask(TaskModel taskModel)
        {
            taskModel.setPoints();
            await _taskRepository.CreateTask(_taskMapper.MapModelToDto(taskModel));
        }
    }
}
