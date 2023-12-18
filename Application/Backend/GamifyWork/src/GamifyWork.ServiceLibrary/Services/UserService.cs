using GamifyWork.ContractLayer.Dto;
using GamifyWork.ContractLayer.Interfaces;
using GamifyWork.ServiceLibrary.Exceptions;
using GamifyWork.ServiceLibrary.Interfaces;
using GamifyWork.ServiceLibrary.Models;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace GamifyWork.ServiceLibrary.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IUserMapperS _userMapper;
        private readonly ILogger<UserService> _logger;

        public UserService(IUserRepository userRepository, IUserMapperS userMapperS, ILogger<UserService> logger)
        {
            _userRepository = userRepository;
            _userMapper = userMapperS;
            _logger = logger;
        }

        public async Task<UserModel> GetUserById(Guid Id)
        {
            try
            {
                UserDto user = await _userRepository.GetUserById(Id);
                UserModel uer2 = _userMapper.MapDtoToModel(user);
                return uer2;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "User not found in service");
                throw new UserException("User not found", (int)HttpStatusCode.NotFound);
            }
        }
    }
}
