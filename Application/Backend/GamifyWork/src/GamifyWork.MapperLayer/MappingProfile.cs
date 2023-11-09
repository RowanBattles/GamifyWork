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

namespace GamifyWork.MapperLayer
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<TaskDto, TaskEntity>().ReverseMap();
            CreateMap<TaskDto, TaskModel>().ReverseMap();
            CreateMap<RewardDto, RewardEntity>().ReverseMap();
            CreateMap<RewardDto, RewardModel>().ReverseMap();
        }
    }

}
