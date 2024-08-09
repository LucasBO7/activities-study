using Microsoft.AspNetCore.SignalR;
using System.Net.Mail;

namespace SignalRSimpleChat.Hubs
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


        public override async Task OnConnectedAsync()
        {
            string? connectionId = GetUserConnectionId();
            await Clients.All.SendAsync("ReceiveMessage", connectionId);

            // Chame a base para continuar o fluxo de conexão padrão
            await base.OnConnectedAsync();
        }

        // Evento executado quando um cliente se desconecta
        public override async Task OnDisconnectedAsync(Exception exception)
        {
            var connectionId = Context.ConnectionId;
            await Clients.All.SendAsync("ReceiveMessage", "Um usuário se desconectou: " + connectionId);

            await base.OnDisconnectedAsync(exception);
        }

    }
}