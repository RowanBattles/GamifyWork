using AutoMapper;
using GamifyWork.ContractLayer.Dto;
using GamifyWork.DataAccessLibrary.Entities;
using GamifyWork.DataAccessLibrary.Interfaces;
using GamifyWork.Dto;
using GamifyWork.ServiceLibrary.Interfaces;
using GamifyWork.ServiceLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GamifyWork.MapperLayer.Mappers
{
    public class TaskMapper : ITaskMapperS, ITaskMapperD
    {
        private readonly IMapper _mapper;

        public TaskMapper(IMapper mapper)
        {
            _mapper = mapper;
        }
        public TaskDto MapModelToDto(TaskModel taskModel)
        {
            return _mapper.Map<TaskDto>(taskModel);
        }

        public TaskEntity MapDtoToEntity(TaskDto taskDto)
        {
            return _mapper.Map<TaskEntity>(taskDto);
        }

        public List<TaskDto> MapEntityToDtoList(List<TaskEntity> taskEntities)
        {
            return _mapper.Map<List<TaskDto>>(taskEntities);
        }

        public List<TaskModel> MapDtoToModelList(List<TaskDto> taskDtos)
        {
            return _mapper.Map<List<TaskModel>>(taskDtos);
        }
    }
}
