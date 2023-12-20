using AutoMapper;
using GamifyWork.ContractLayer.Dto;
using GamifyWork.ServiceLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GamifyWork.ServiceLibrary.Interfaces
{
    public interface IUserMapperS
    {
        UserModel MapDtoToModel(UserDto user);
        UserDto MapModelToDto(UserModel user);
    }
}
