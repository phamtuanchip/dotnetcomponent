using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Quartz.Job;
using Quartz;
using MVC01.Hubs;
using MVC01.Models;
using Microsoft.AspNet.Identity;
using System.Data.Entity;

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
          
           List<ReminderTask> remider=  db.Tasks.Where(a => a.RemindDate.Equals(DateTime.Today) && a.isRemind == true && a.Remided == false).ToList();
            foreach(ReminderTask r in remider) { 
                MessagesHub.SendMessages(new Messages(Messages.TODO,r.Title, r.Assignee));
                r.Remided = !r.isRepeat;
                db.Entry(r).State = EntityState.Modified;                
            }
            db.SaveChanges();

        }
    }
}