using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace MVC01.Models
{
    public class MusicStoreEntities : DbContext
    {

        public MusicStoreEntities()
       
           : base("DefaultConnection")
        { }

        private static MusicStoreEntities _instance = new MusicStoreEntities();
        public static MusicStoreEntities Instance()
        {
            // Uses lazy initialization.
            // Note: this is not thread safe.
            //if (_instance == null)
            //{
             //   _instance = new MusicStoreEntities();
           // }

            return new MusicStoreEntities();
        }

        public DbSet<Album> Albums { get; set; }
        public DbSet<Genre> Genres { get; set; }
        public DbSet<Artist> Artists { get; set; }
        public DbSet<ReminderTask> Tasks { get; set; }
    }
}