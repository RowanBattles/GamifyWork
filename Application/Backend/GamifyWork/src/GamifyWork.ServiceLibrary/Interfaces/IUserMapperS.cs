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
        List<UserModel> MapDtosToModels(List<UserDto> userDtos);
        UserModel MapDtoToModel(UserDto user);
        UserDto MapModelToDto(UserModel user);
    }
}
