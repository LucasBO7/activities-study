namespace ClientTryWebApi.Hub
{
    public interface IChatHub
    {
        Task SendMessageForAll(string message);
    }
}
