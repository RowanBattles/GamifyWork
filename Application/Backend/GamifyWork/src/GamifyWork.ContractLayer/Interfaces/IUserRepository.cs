using GamifyWork.ContractLayer.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GamifyWork.ContractLayer.Interfaces
{
    public interface IUserRepository
    {
        Task CreateUser(UserDto userDto);
        Task<UserDto> GetUserById(Guid Id);
    }
}
