using Microsoft.AspNet.SignalR.Hubs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;

namespace SignalRChat.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SignalRChatController : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> GetUserConnectionId()
        {
            try
            {
                const string url = "https://localhost:7216/chatHub";
                await using var connection = new HubConnectionContext
            }
            catch (Exception exc)
            {
                return BadRequest(exc.Message);
            }
        }
    }
}
