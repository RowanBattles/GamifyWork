﻿using GamifyWork.ContractLayer.Dto;
using GamifyWork.DataAccessLibrary.Entities;

namespace GamifyWork.MapperLayer.Mappers
{
    public interface IUserMapperD
    {
        UserDto MapEntityToDto(UserEntity userEntity);
    }
}