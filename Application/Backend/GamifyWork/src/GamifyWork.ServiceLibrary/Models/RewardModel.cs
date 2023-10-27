﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GamifyWork.ServiceLibrary.Models
{
    public class RewardModel
    {
        public RewardModel(int reward_ID, string title, string? description, int? cost, int user_ID)
        {
            Reward_ID = reward_ID;
            Title = title;
            Description = description;
            Cost = cost;
            User_ID = user_ID;
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Reward_ID { get; set; }

        [Required]
        [StringLength(60)]
        public string Title { get; set; }

        [StringLength(255)]
        public string? Description { get; set; }

        public int? Cost { get; set; }

        [Required]
        public int User_ID { get; private set; }
    }
}
