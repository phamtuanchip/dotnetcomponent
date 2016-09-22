﻿using System;
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
        public DbSet<Album> Albums { get; set; }
        public DbSet<Genre> Genres { get; set; }
        public DbSet<Artist> Artists { get; set; }
        public DbSet<ReminderTask> Tasks { get; set; }
    }
}