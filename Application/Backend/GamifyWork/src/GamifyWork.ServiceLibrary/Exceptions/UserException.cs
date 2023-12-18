using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GamifyWork.ServiceLibrary.Exceptions
{
    public class UserException : Exception
    {
        public int ErrorCode { get; private set; }
        public UserException(string message, int errorCode) : base(message)
        {
            ErrorCode = errorCode;
        }
    }
}
