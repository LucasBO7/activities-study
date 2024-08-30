using Microsoft.AspNetCore.SignalR;

namespace Signal.WebServer.Hubs
{
    public class ChatHub : Hub<IChatHub>
    {
        public async Task SendMessageForAll(string message)
        {
            await Clients.All.SendMessageForAll(message);
        }

        public override Task OnConnectedAsync()
        {
            return base.OnConnectedAsync();
        }
    }
}
