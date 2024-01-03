namespace GamifyWork.API.Hubs
{
    public class MessageModel
    {
        public Guid UserSender { get; set; }

        public Guid UserReceiver { get; set;}

        public string Message { get; set; }
    }
}
