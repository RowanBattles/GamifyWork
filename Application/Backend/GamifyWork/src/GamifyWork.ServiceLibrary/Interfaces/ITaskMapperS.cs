using GamifyWork.ContractLayer.Dto;
using GamifyWork.ServiceLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GamifyWork.ServiceLibrary.Interfaces
{
    public interface ITaskMapperS
    {
        TaskDto MapModelToDto(TaskModel taskModel);
        List<TaskModel> MapDtoToModelList(List<TaskDto> taskDtos);
        TaskModel MapDtoToModel(TaskDto taskDto);
    }
}
