using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR;

namespace LIBRARY.Websocket.AspNetCore
{
    public class ChatHub : Hub
    {
        public async Task SendMessage(string user, string message)
        {
            await Clients.All.SendAsync("ReceiveMessage", user, message);
        }
    }
}