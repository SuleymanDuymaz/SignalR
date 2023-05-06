using Microsoft.AspNetCore.SignalR;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SıgnalRServerExample.Hubs
{
    public class MessageHub:Hub
    {
        public async Task SendMessageAsync(string message,IEnumerable<string> connnectionIds)
        {

            // await Clients.Others.SendAsync("receiveMessage", message);
            await Clients.AllExcept(connnectionIds).SendAsync("receiveMessage", message);
        }

        public override async Task OnConnectedAsync()
        {
            await Clients.Caller.SendAsync("getConnectionId", Context.ConnectionId);
            //21.10
        }

    }
}
