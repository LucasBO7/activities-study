using Microsoft.AspNetCore.SignalR;

namespace SignalRChat.Server.Hubs
{
    public class ChatHub : Hub
    {
        public async Task SendMessage(string user, string message){
            await Clients.All.SendAsync("ReceiveMessage", user, message);
        }

        public override async Task<Task> OnConnectedAsync()
        {
            var connectionId = Context.ConnectionId;
            await Clients.All.SendAsync("ReceiveMessage", "SISTEMA", "Conectado com sucesso!");
            return base.OnConnectedAsync();
        }
    }
}