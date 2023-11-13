namespace GamifyWork.API.Middleware
{
    public class Error
    {
        public string Message { get; set; }
        public int ErrorCode { get; set; }
        public Error(string message, int errorCode)
        {
            Message = message;
            ErrorCode = errorCode;
        }
    }
}
