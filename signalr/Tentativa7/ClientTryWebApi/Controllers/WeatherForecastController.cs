using ClientTryWebApi.Hub;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;

namespace ClientTryWebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {

        private IHubContext<ChatHub, IChatHub> chat;

        public WeatherForecastController(IHubContext<ChatHub, IChatHub> _chat)
        {
            chat = _chat;
        }

        [HttpPost]
        [Route("sendForAll")]
        public string GetAll(string message)
        {
            chat.Clients.All.SendMessageForAll(message);
            return "Mensagem enviada com sucesso!";
        }
    }
}
