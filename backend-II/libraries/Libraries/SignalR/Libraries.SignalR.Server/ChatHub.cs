using Microsoft.AspNetCore.SignalR;

namespace Libraries.SignalR.Server;

public class ChatHub : Hub
{
    public async Task SendMessage(string user, string message)
    {
        await Clients.All.SendAsync("ReceiveMessage", user, message);
    }
    public override Task OnConnectedAsync()
    {
        // Logic when a client connects
        return base.OnConnectedAsync();
    }
    public override Task OnDisconnectedAsync(Exception? exception)
    {
        // Logic when a client disconnects
        return base.OnDisconnectedAsync(exception);
    }
}
