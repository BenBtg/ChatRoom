using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.SignalR;
[Authorize]
public class Chat : Hub
{
    public void BroadcastMessage(string message)
    {
        Clients.All.SendAsync("broadcastMessage", Context.User.Identity.Name, message);
    }

    public void Echo(string message)
    {
        Clients.Client(Context.ConnectionId).SendAsync("echo", Context.User.Identity.Name, message + " (echo from server)");
    }
}