using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration;

namespace CodeFirst
{
    public class CompanyContext : DbContext
    {
        public CompanyContext() : base("CompanyDatabase") { }

        public DbSet<Collaborator> Collaborators { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Manager> Managers { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Department>().Property(dp => dp.Name).IsRequired();
            modelBuilder.Entity<Manager>().HasKey(ma => ma.ManagerCode);
            modelBuilder.Entity<Manager>().Property(ma => ma.Name)
                .IsConcurrencyToken(true)
                .IsVariableLength()
                .HasMaxLength(20);

            //modelBuilder.Entity<Manager>()
            //    .HasRequired(d => d.Department)
            //    .WithMany()
            //    .HasForeignKey(d => d.DepartmentId)
            //    .WillCascadeOnDelete();
        }
    }
}
