using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.SignalR;
using Microsoft.AspNet.SignalR.Hubs;
using System.Configuration;
using MVC01.Models;
using System.Threading.Tasks;

namespace MVC01.Hubs
{
    public class MessagesHub : Hub
    {
        private static string conString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ToString();
        private static MessagesEntities db = MessagesEntities.Instance();
        public void Hello()
        {
            Clients.All.hello();
        }


        [HubMethodName("sendMessages")]
        public static void SendMessages(Messages m)
        {
           IHubContext context = GlobalHost.ConnectionManager.GetHubContext<MessagesHub>();            
            context.Clients.All.updateMessages(m);
            //db.Messages.Add(m);
            //await db.SaveChangesAsync();
        }


    }
}