using Cinema.Services.SessionAPI.Application.Services.Abstract.HubServices;
using Cinema.Services.SessionAPI.Infrastructure.Hubs;
using Microsoft.AspNetCore.SignalR;

namespace Cinema.Services.SessionAPI.Infrastructure.Services.Concrete.HubServices
{
    public class SeatStatusHubService : ISeatStatusHubService
    {
        private readonly IHubContext<SeatStatusHub> _hubContext;

        public SeatStatusHubService(IHubContext<SeatStatusHub> hubContext)
        {
            _hubContext = hubContext;
        }

        public async Task SendMessageToGroupAsync(int id, string message)
        {
            await _hubContext.Clients.Group(id.ToString()).SendAsync("receiveStatus",message);
        }
    }
}
