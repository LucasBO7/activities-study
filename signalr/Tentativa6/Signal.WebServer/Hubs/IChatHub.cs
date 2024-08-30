namespace Signal.WebServer.Hubs
{
    public interface IChatHub
    {
        Task SendMessageForAll(string message);
    }
}
