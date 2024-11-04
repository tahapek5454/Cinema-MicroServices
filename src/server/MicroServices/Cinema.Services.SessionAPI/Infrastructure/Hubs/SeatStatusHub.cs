using Microsoft.AspNetCore.SignalR;

namespace Cinema.Services.SessionAPI.Infrastructure.Hubs
{
    public class SeatStatusHub:Hub
    {
        public override async Task OnConnectedAsync()
        {
            var sessionId = Context.GetHttpContext().Request.Query["sessionId"].ToString();

            if (sessionId == null)
                return;


            Console.WriteLine(Context.ConnectionId + " Has joined");
            await Groups.AddToGroupAsync(Context.ConnectionId, sessionId); 
        }

        public override async Task OnDisconnectedAsync(Exception? exception)
        {
            var sessionId = Context.GetHttpContext().Request.Query["sessionId"].ToString();

            Console.WriteLine(Context.ConnectionId + " Has leaved");

            if (!string.IsNullOrEmpty(sessionId))
            {
                await Groups.RemoveFromGroupAsync(Context.ConnectionId, sessionId);
            }
        }
    }
}
