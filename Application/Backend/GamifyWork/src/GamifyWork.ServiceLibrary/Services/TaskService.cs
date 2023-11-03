using AutoMapper;
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
        private readonly ITaskRepository _taskRepository;
        private readonly IMapper _mapper;

        public TaskService(ITaskRepository taskRepository, IMapper mapper)
        {
            _taskRepository = taskRepository;
            _mapper = mapper;
        }
        public async Task<List<TaskModel>> GetAllTasks()
        {
            try
            {
                var entities = await _taskRepository.GetAllTasks();
                return _mapper.Map<List<TaskModel>>(entities);
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
                var entity = _mapper.Map<TaskModel>(taskModel);
                await _taskRepository.CreateTask(entity);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
