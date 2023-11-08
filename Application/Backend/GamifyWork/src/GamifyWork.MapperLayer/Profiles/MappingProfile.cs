using AutoMapper;
using GamifyWork.ContractLayer.Dto;
using GamifyWork.DataAccessLibrary.Entities;
using GamifyWork.Dto;
using GamifyWork.ServiceLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GamifyWork.MapperLayer.Profiles
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<TaskEntity, TaskDto>();
            CreateMap<TaskDto, TaskModel>();
            CreateMap<RewardEntity, RewardDto>();
            CreateMap<RewardDto, RewardModel>();
        }
    }

}
