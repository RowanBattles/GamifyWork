using AutoMapper;
using GamifyWork.DataAccessLibrary.Entities;
using GamifyWork.ServiceLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GamifyWork.MappingConfigurations
{
    public class TaskMapper : Profile
    {
        public TaskMapper()
        {
            CreateMap<TaskEntity, TaskModel>();
            CreateMap<TaskModel, TaskEntity>();
        }
    }
}
