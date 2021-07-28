using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace DeptEmployeeMVC.Models
{
        public class DataContext : DbContext
        {
            public DataContext() : base("data")
            {
                Database.SetInitializer<DataContext>(new CreateDatabaseIfNotExists<DataContext>());
            }
            public DbSet<Department> departments { get; set; }
            public DbSet<Employee> employees { get; set; }
            public DbSet<Salary> salaries { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
     // configures one-to-many relationship

      modelBuilder.Entity<Department>()
     .HasMany<Employee>(g => g.employees)
     .WithRequired(s => s.Department)
     .WillCascadeOnDelete();




        }
    }

}