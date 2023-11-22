using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GamifyWork.ServiceLibrary.Exceptions
{
    public class RewardException : Exception
    {
        public int ErrorCode { get; private set; }
        public RewardException(string message, int errorCode) : base(message)
        {
            ErrorCode = errorCode;
        }
    }
}
