using Microsoft.AspNetCore.SignalR;

namespace GamifyWork.API.Hubs
{
    public class ChatHub : Hub<IChatClient>
    {
        public async Task SendMessage(MessageModel message)
        {
            await Clients.All.ReceiveMessage(message);
        }
    }
}
