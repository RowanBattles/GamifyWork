using GamifyWork.ContractLayer.Dto;
using GamifyWork.DataAccessLibrary.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GamifyWork.DataAccessLibrary.Interfaces
{
    public interface ITaskMapperD
    {
        TaskEntity MapDtoToEntity(TaskDto taskDto);
        List<TaskDto> MapEntityToDtoList(List<TaskEntity> taskEntities);
    }
}
