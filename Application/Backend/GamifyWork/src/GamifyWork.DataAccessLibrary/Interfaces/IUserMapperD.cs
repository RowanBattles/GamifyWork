using GamifyWork.ContractLayer.Dto;
using GamifyWork.DataAccessLibrary.Entities;

namespace GamifyWork.MapperLayer.Mappers
{
    public interface IUserMapperD
    {
        UserEntity MapDtoToEntity(UserDto userDto);
        UserDto MapEntityToDto(UserEntity userEntity);
    }
}