using GamifyWork.ContractLayer.Dto;
using GamifyWork.DataAccessLibrary.Entities;
using GamifyWork.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GamifyWork.DataAccessLibrary.Interfaces
{
    public interface IRewardMapperD
    {
        List<RewardDto> MapEntityToDtoList(List<RewardEntity> rewardEntities);
    }
}
