using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SıgnalRServerExample.Hubs
{
    public class MyHub:Hub
    {
        static List<string> AllConnectionId=new List<string>();
        
        public async Task SendMessageAsync(string message)
        {
          await  Clients.All.SendAsync("receiveMessage",message);
        }


        public override async Task OnConnectedAsync()
        {
            AllConnectionId.Add(Context.ConnectionId);
            await Clients.All.SendAsync("clients", AllConnectionId);
            await Clients.All.SendAsync("userJoined",Context.ConnectionId);
            
        }

        public override async Task OnDisconnectedAsync(Exception exception)
        {
            AllConnectionId.Remove(Context.ConnectionId);
            await Clients.All.SendAsync("clients", AllConnectionId);
            await Clients.All.SendAsync("userLeaved", Context.ConnectionId);
        }

    }
}
