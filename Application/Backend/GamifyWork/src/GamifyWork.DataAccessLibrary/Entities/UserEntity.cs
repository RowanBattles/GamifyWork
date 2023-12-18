using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GamifyWork.DataAccessLibrary.Entities
{
    public class UserEntity
    {
        public UserEntity(Guid user_ID, int points)
        {
            User_ID = user_ID;
            Points = points;
        }

        [Key]
        public Guid User_ID { get; private set; }
        public int Points { get; private set; }
    }
}
