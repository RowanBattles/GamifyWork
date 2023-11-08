using AutoMapper;
using GamifyWork.ContractLayer.Dto;
using GamifyWork.DataAccessLibrary.Entities;
using GamifyWork.DataAccessLibrary.Interfaces;
using GamifyWork.Dto;
using GamifyWork.ServiceLibrary.Interfaces;
using GamifyWork.ServiceLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GamifyWork.MapperLayer.Mappers
{
    public class RewardMapper : IRewardMapperS, IRewardMapperD
    {
        private IMapper _mapper;
        public RewardMapper(IMapper mapper)
        {
            _mapper = mapper;
        }

        public List<RewardDto> MapEntityToDtoList(List<RewardEntity> rewardEntities)
        {
            return _mapper.Map<List<RewardDto>>(rewardEntities);
        }

        public List<RewardModel> MapDtoToModelList(List<RewardDto> rewardDtos)
        {
            return _mapper.Map<List<RewardModel>>(rewardDtos);
        }
    }
}
