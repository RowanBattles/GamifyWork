using AutoMapper;
using GamifyWork.ContractLayer.Dto;
using GamifyWork.DataAccessLibrary.Entities;
using GamifyWork.ServiceLibrary.Interfaces;
using GamifyWork.ServiceLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GamifyWork.MapperLayer.Mappers
{
    public class UserMapper : IUserMapperS, IUserMapperD
    {
        private readonly IMapper _mapper;
        public UserMapper(IMapper mapper)
        {
            _mapper = mapper;
        }

        public UserModel MapDtoToModel(UserDto user)
        {
            return _mapper.Map<UserModel>(user);
        }

        public UserDto MapEntityToDto(UserEntity userEntity)
        {
            return _mapper.Map<UserDto>(userEntity);
        }
    }
}
