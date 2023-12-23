using GamifyWork.ContractLayer.Dto;
using GamifyWork.ContractLayer.Interfaces;
using GamifyWork.ServiceLibrary.Exceptions;
using GamifyWork.ServiceLibrary.Helpers;
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
        private readonly IKeycloakLogic _keycloakLogic;
        private readonly ILogger<UserService> _logger;
        
        public UserService(IKeycloakLogic keycloakLogic, IUserRepository userRepository, IUserMapperS userMapperS, ILogger<UserService> logger)
        {
            _userRepository = userRepository;
            _userMapper = userMapperS;
            _keycloakLogic = keycloakLogic;
            _logger = logger;
        }

        public async Task CreateUser(Guid id)
        {
            try
            {
                await _userRepository.CreateUser(_userMapper.MapModelToDto(new UserModel(id, 0)));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "User could not be created in servicde");
                throw new UserException("User could not be created", (int)HttpStatusCode.InternalServerError);
            }
        }

        public async Task<List<UserModel>> GetAllUsers()
        {
            try
            {
                var userDtos = await _userRepository.GetAllUsers();
                var userModels = _userMapper.MapDtosToModels(userDtos);
                var userModels2  = await _keycloakLogic.AddUsernamesForUsers(userModels);
                return userModels2;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Users could not be found in service");
                throw new UserException("Users could not be found", (int)HttpStatusCode.NotFound);
            }
        }

        public async Task<UserModel> GetUserById(Guid Id)
        {
            try
            {
                return _userMapper.MapDtoToModel(await _userRepository.GetUserById(Id));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "User not found in service");
                throw new UserException("User not found", (int)HttpStatusCode.NotFound);
            }
        }
    }
}
