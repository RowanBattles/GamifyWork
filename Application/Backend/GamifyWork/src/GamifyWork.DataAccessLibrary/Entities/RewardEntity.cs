using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GamifyWork.DataAccessLibrary.Entities
{
    public class RewardEntity
    {
        public RewardEntity(int reward_ID, string title, string? description, int cost, Guid user)
        {
            Reward_ID = reward_ID;
            Title = title;
            Description = description;
            Cost = cost; 
            User = user;
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Reward_ID { get; private set; }

        [Required]
        [StringLength(60)]
        public string Title { get; private set; }

        [StringLength(255)]
        public string? Description { get; private set; }

        [Required]
        public int Cost { get; private set; }

        [Required]
        public Guid User { get; private set; }
    }
}
