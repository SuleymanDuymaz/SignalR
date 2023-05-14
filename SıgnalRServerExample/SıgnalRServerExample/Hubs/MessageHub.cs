using Microsoft.AspNetCore.SignalR;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SıgnalRServerExample.Hubs
{
    public class MessageHub:Hub
    {
        /*
        public async Task SendMessageAsync(string message,IEnumerable<string> connnectionIds)
        {

           // await Clients.Others.SendAsync("receiveMessage", message);
          // await Clients.AllExcept(connnectionIds).SendAsync("receiveMessage", message);
         // await Clients.Client(connnectionIds.First()).SendAsync("receiveMessage", message);
          await Clients.Clients(connnectionIds).SendAsync("receiveMessage", message);
           
        }
        */

        public async Task SendMessageAsync(string message,string groupName,IEnumerable<string> connnectionIds)
        {
            await Clients.GroupExcept(groupName, connnectionIds).SendAsync("receiveMessage",message);
            //GroupExcept
            
        }

        public  async Task addGroup(string connectionId,string groupName)
        {
            await Groups.AddToGroupAsync(connectionId, groupName);
        }
        public override async Task OnConnectedAsync()
        {
            await Clients.Caller.SendAsync("getConnectionId", Context.ConnectionId);
            //group
        }

    }
}
