using GamifyWork.ContractLayer.Dto;
using GamifyWork.DataAccessLibrary.Entities;

namespace GamifyWork.MapperLayer.Mappers
{
    public interface IUserMapperD
    {
        UserEntity MapDtoToEntity(UserDto userDto);
        List<UserDto> MapEntitiesToDtos(List<UserEntity> users);
        UserDto MapEntityToDto(UserEntity userEntity);
    }
}