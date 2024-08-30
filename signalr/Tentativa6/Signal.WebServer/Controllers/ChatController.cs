using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using Signal.WebServer.Hubs;

namespace Signal.WebServer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ChatController : ControllerBase
    {
        private IHubContext<ChatHub, IChatHub> chatHub;

        public ChatController(IHubContext<ChatHub, IChatHub> _chatHub)
        {
            chatHub = _chatHub;
        }

        [HttpPost]
        [Route("sendMessage")]
        public string Get(string message)
        {
            if (String.IsNullOrEmpty(message))
                return "...";
            else
            {
                chatHub.Clients.All.SendMessageForAll(message);
                return "Mensagem enviada com sucesso!";
            }
        }
    }
}
