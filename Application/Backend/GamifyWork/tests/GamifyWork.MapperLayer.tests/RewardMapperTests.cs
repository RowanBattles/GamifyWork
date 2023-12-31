﻿using AutoMapper;
using GamifyWork.ContractLayer.Dto;
using GamifyWork.DataAccessLibrary.Entities;
using GamifyWork.Dto;
using GamifyWork.MapperLayer.Mappers;
using GamifyWork.ServiceLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace GamifyWork.MapperLayer.tests
{
    public class RewardMapperTests
    {
        Guid user = new("6B29FC40-CA47-1067-B31D-00DD010662DA");

        [Fact]
        public void MapEntityToDtoList_ShouldMapCorrectly()
        {
            // Arrange
            var config = new MapperConfiguration(cfg => cfg.AddProfile<MappingProfile>());
            var mapper = config.CreateMapper();
            var rewardMapper = new RewardMapper(mapper);

            var rewardEntities = new List<RewardEntity>
            {
                new RewardEntity(1, "Reward 1", null, 10, user),
                new RewardEntity(2, "Reward 2", null, 20, user),
            };

            // Act
            var rewardDtos = rewardMapper.MapEntityToDtoList(rewardEntities);

            // Assert
            Assert.Equal(rewardEntities.Count, rewardDtos.Count);

            for (int i = 0; i < rewardEntities.Count; i++)
            {
                Assert.Equal(rewardEntities[i].Reward_ID, rewardDtos[i].Reward_ID);
                Assert.Equal(rewardEntities[i].Title, rewardDtos[i].Title);
                Assert.Equal(rewardEntities[i].Cost, rewardDtos[i].Cost);
                Assert.Equal(rewardEntities[i].User, rewardDtos[i].User);
            }
        }

        [Fact]
        public void MapDtoToModelList_ShouldMapCorrectly()
        {
            // Arrange
            var config = new MapperConfiguration(cfg => cfg.AddProfile<MappingProfile>());
            var mapper = config.CreateMapper();
            var rewardMapper = new RewardMapper(mapper);

            var rewardDtos = new List<RewardDto>
            {
                new RewardDto(1, "Reward 1", null, 10, user),
                new RewardDto(1, "Reward 2", null, 10, user),
            };

            // Act
            var rewardModels = rewardMapper.MapDtoToModelList(rewardDtos);

            // Assert
            Assert.Equal(rewardDtos.Count, rewardModels.Count);

            for (int i = 0; i < rewardDtos.Count; i++)
            {
                Assert.Equal(rewardModels[i].Reward_ID, rewardDtos[i].Reward_ID);
                Assert.Equal(rewardModels[i].Title, rewardDtos[i].Title);
                Assert.Equal(rewardModels[i].Cost, rewardDtos[i].Cost);
                Assert.Equal(rewardModels[i].User, rewardDtos[i].User);
            }
        }
    }

}
