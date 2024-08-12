using Microsoft.AspNetCore.SignalR;

namespace SignalRChat_Server.Hubs
{
    public class ChatHub : Hub
    {
        /// <summary>
        /// Pega o Id do usuário e retorna
        /// </summary>
        /// <returns></returns>
        public string GetUserConnectionId()
        {
            return Context.ConnectionId;
        }

        /// <summary>
        /// Envia uma mensagem ao usuário do id inserido
        /// </summary>
        /// <param name="userId">Id do usuário destinatário</param>
        /// <param name="message">Mensagem a ser enviada</param>
        /// <returns></returns>
        public async Task SendMessage(string userId, string message)
        {
            await Clients.Client(userId).SendAsync("ReceiveMessage", message);
        }
    }
}
