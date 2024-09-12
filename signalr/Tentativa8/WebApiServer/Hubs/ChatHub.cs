using Microsoft.AspNetCore.SignalR;
using WebApiServer.Models;

namespace WebApiServer.Hubs
{
    public class ChatHub : Hub
    {
        public async Task JoinChat(UserConnection conn)
        {
            await Clients.All.SendAsync("ReceiveMessage", "admin", $"{conn.Username} has joined!");
        }

        public async Task JoinSpecificChatRoom(UserConnection conn)
        {
            await Groups.AddToGroupAsync(Context.ConnectionId, conn.ChatRoom);
            await Clients.Group(conn.ChatRoom).SendAsync("ReceiveMessage", "admin", $"{conn.Username} has joined {conn.ChatRoom}");
        }

        public override async Task<Task> OnConnectedAsync()
        {
            await Clients.All.SendAsync("ReceiveMessage", "adimn", "An user has connected");
            return base.OnConnectedAsync();
        }

        public async Task SendMessageForAll(string message)
        {
            await Clients.All.SendAsync("ReceiveMessage", "admin", message);
        }
    }
}
