using GamifyWork.ContractLayer.Dto;
using GamifyWork.ContractLayer.Interfaces;
using GamifyWork.DataAccessLibrary.Data;
using GamifyWork.DataAccessLibrary.Entities;
using GamifyWork.MapperLayer.Mappers;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GamifyWork.DataAccessLibrary.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly dbContext _dbContext;
        private readonly IUserMapperD _userMapper;
        private readonly ILogger<UserRepository> _logger;

        public UserRepository(dbContext dbContext, IUserMapperD userMapperD, ILogger<UserRepository> logger)
        {
            _dbContext = dbContext;
            _userMapper = userMapperD;
            _logger = logger;
        }

        public async Task CreateUser(UserDto userDto)
        {
            try
            {
                UserEntity userEntity = _userMapper.MapDtoToEntity(userDto);
                await _dbContext.user.AddAsync(userEntity);
                await _dbContext.SaveChangesAsync();
            }
            catch
            {
                _logger.LogError("An unexpected error occurred while creating an user in repository");
                throw;
            }
        }

        public async Task<List<UserDto>> GetAllFriendsByUser()
        {
            try
            {
                var users = await _dbContext.user.ToListAsync();
                return _userMapper.MapEntitiesToDtos(users);
            }
            catch
            {
                _logger.LogError("An unexpected error occurred while retrieving users in repository");
                throw;
            }
        }

        public async Task<UserDto> GetUserById(Guid Id)
        {
            try
            {
                return _userMapper.MapEntityToDto(await _dbContext.user.FindAsync(Id) ?? throw new Exception("User not found"));
            }
            catch
            {
                _logger.LogError("An unexpected error occurred while retrieving an user in repository");
                throw;
            }
        }
    }
}
