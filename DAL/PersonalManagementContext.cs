using PersonalManagement.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Web;

namespace PersonalManagement.DAL
{
    public class PersonalManagementContext: DbContext
    {
        public PersonalManagementContext() :
            base("PersonalManagement")
        {
        }

        public DbSet<Employee> Employees { get; set; }
        public DbSet<DeductionType> DeductionTypes { get; set; }
        public DbSet<Deduction> Deductions { get; set; }


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}