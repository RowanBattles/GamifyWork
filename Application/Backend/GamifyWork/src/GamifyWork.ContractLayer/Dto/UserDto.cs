using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GamifyWork.ContractLayer.Dto
{
    public class UserDto
    {
        public Guid User_ID { get; private set; }
        public int Points { get; private set; }

        public UserDto(Guid user_ID, int points)
        {
            User_ID = user_ID;
            Points = points;
        }
    }
}
