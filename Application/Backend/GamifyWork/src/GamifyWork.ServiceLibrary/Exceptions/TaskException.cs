using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GamifyWork.ServiceLibrary.Exceptions
{
    public class TaskException : Exception
    {
        public int ErrorCode { get; private set; }
        public TaskException(string message, int errorCode) : base(message)
        {
            ErrorCode = errorCode;
        }
    }
}
