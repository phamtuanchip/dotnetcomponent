using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace MVC01.Models
{
    [DataContract]
    public class ReminderTask
    {
        public int ReminderTaskId { get; set; }
        public int GeoLocaltionId { get; set; }
        [DataMember]
        public String Title { get; set; }
        [DataMember]
        public DateTime RemindDate { get; set; }
        [DataMember]
        public GeoLocaltion GeoLocaltion { get; set; }
        [DataMember]
        public short Priority { get; set; }
        [DataMember]
        public bool isRemind { get; set; }
        [DataMember]
        public bool Remided { get; set; }

        public ReminderTask() {
            GeoLocaltion = new GeoLocaltion();
        }
         public string TaskOwner { get; set; }
         public bool isRepeat { get; set; }
}
    
}