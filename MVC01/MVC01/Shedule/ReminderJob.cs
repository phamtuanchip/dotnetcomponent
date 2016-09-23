using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Quartz.Job;
using Quartz;
using MVC01.Hubs;
using MVC01.Models;
namespace MVC01.Shedule
{
    public class ReminderJob : IJob
    {
        string id = "Reminder:";
        string message = "Task todo!";
        MusicStoreEntities db = new MusicStoreEntities();
        /**
        public ReminderJob(string id, string message) {
            this.id = id;
            this.message = message;
        }
    */
        public void Execute(IJobExecutionContext context)
        {
           // db.Tasks.Include(a => ).Where(a=> a.)
           MessagesHub.SendMessages(id, message);
            System.Console.WriteLine("Job execute " + id +" : "+ message + "");
        }
    }
}