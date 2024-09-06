using Microsoft.AspNetCore.SignalR;

namespace ClientTryWebApi.Hub
{
    public class ChatHub : Hub<IChatHub>
    {
        public async Task SendMessageForAll(string message)
        {
            await Clients.All.SendMessageForAll(message);
        }
    }
}
