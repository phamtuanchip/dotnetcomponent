using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVC01.Models
{
    public class Messages
    {
        public static string TODO = "TODO";
        public static string CHAT = "CHAT";
        public static string NOTIFY = "NOTIFY";
        public static string LOG = "LOG";
        public static string TO_ALL = "ALL";
        public static string OWNER_DEFAULT = "SYSTEM";

        public Messages() { }
        public Messages(string type, string owner, string message, string to) {
            Type = type == null? NOTIFY: type;
            Owner = owner == null ? OWNER_DEFAULT: owner;
            Message = message;
            To = to  == null ? TO_ALL : to;
            MessageDate = DateTime.Now;
        }
        public Messages(string name, string message)

            : this(null, name, message, null) { }

        public Messages(string type, string name, string message)

            : this(type, name, message, null) { }
        

        public int MessagesId { get; set; }

        public string Type { get; set; }
        public string Message { get; set; }
        public string Owner { get; set; }
        public string To { get; set; }
        public string EmptyMessage { get; set; }

        public DateTime MessageDate { get; set; }
    }
}