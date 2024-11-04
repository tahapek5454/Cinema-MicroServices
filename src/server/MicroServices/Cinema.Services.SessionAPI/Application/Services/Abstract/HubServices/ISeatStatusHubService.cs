namespace Cinema.Services.SessionAPI.Application.Services.Abstract.HubServices
{
    public interface ISeatStatusHubService
    {
        Task SendMessageToGroupAsync(int id, object message);
    }
}
