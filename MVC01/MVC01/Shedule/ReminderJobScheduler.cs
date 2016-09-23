using Quartz;
using Quartz.Impl;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVC01.Shedule
{
    public class ReminderJobScheduler
    {
        public static void Start()
        {
            try { 

            IScheduler scheduler = StdSchedulerFactory.GetDefaultScheduler(); scheduler.Start();
            IJobDetail job = JobBuilder.Create<ReminderJob>().Build();
            ITrigger trigger = TriggerBuilder.Create().WithIdentity("ReminderJob1", "Users1").StartNow().WithSimpleSchedule(s => s.WithIntervalInSeconds(60).RepeatForever()).Build();
            scheduler.ScheduleJob(job, trigger);
            }
            catch (ObjectAlreadyExistsException eae)
            {
                System.Console.Write(eae.Message);
            }
        } 

    }
}