namespace GamifyWork.API.Hubs
{
    public interface IChatClient
    {
        Task ReceiveMessage(MessageModel message);
    }
}
