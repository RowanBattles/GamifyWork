using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GamifyWork.ServiceLibrary.Models
{
    public class UserModel
    {
        public Guid User_ID { get; private set; }
        public int Points { get; private set; }
        public string? Username { get; private set; }

        public UserModel(Guid user_ID, int points)
        {
            User_ID = user_ID;
            Points = points;
        }

        public void SetUsername(string? username)
        {
            Username = username;
        }
    }
}
