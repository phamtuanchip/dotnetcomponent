using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace MVC01.Models
{
    public class MessagesEntities : DbContext
    {
        public MessagesEntities()

           : base("DefaultConnection")
        { }
        private static MessagesEntities _instance;
        public static MessagesEntities Instance()
        {
            _instance = new MessagesEntities();

            return _instance;
        }
        public DbSet<Messages> Messages { get; set; }

        

        /**
        internal Task saveAsync()
        {
            throw new NotImplementedException();
        }
        **/
    }
}