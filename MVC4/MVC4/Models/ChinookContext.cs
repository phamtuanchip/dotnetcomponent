﻿using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace MVC4.Models
{
    public class ChinookContext : DbContext
    {
        public DbSet<Artist> Artists { get; set; }
        public DbSet<Album> Albums { get; set; }
        public ChinookContext() : base("DefaultConnection") {

        }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            // Chinook Database does not pluralize table names
            //modelBuilder.Conventions
            //    .Remove<PluralizingTableNameConvention>();
        }
    }
}