using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.SignalR;
using MVC01.Models;
using System.Threading.Tasks;

namespace MVC01.Hubs
{
    public class ChatHub : Hub
    {
        public void Send(string name, string message)
        {
            // Call the addNewMessageToPage method to update clients.
            Clients.All.addNewMessageToPage(name, message);
            MessagesHub.SendMessages(new Messages(Messages.CHAT,name, message));
        }
    }
}