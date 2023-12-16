using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GamifyWork.Dto
{
    public class RewardDto
    {
        public RewardDto(int reward_ID, string title, string? description, int? cost, Guid user)
        {
            Reward_ID = reward_ID;
            Title = title;
            Description = description;
            Cost = cost;
            User = user;
        }

        public int Reward_ID { get; set; }
        public string Title { get; set; }
        public string? Description { get; set; }
        public int? Cost { get; set; }
        public Guid User { get; private set; }
    }
}
