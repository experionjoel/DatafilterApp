using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace DataFilterWebApp.DataLayer
{
    public class AppContext: DbContext
    {
        public AppContext() : base("name = DataFilterConnectionString")
        { }

        public DbSet<Employee> EmployeesDb { get; set; } // Represent Employee Table in DB
        public DbSet<FieldOperator> FieldOperatorDb { get; set; } // Represent Fieldname & Operators Mapping Table in DB
        public DbSet<Users> UsersDb { get; set; } // Represent User Table in DB
        public DbSet<Operator> OperatorsDb { get; set; } // Represent Operator Table in DB

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Operator>().HasKey(c => c.Id);
            modelBuilder.Entity<FieldOperator>().HasKey(c => c.Id);
            modelBuilder.Entity<Employee>().HasKey(c => c.Id);
            modelBuilder.Entity<Users>().HasKey(c => c.Id);

            // Setting Foreign Key Relation
            modelBuilder.Entity<FieldOperator>()
            .HasRequired(c => c.Operator)
            .WithMany(s => s.FieldOperators)
            .HasForeignKey(s => s.OperatorId);

        }
    }
}