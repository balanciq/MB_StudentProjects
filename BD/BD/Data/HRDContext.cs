using BD.Models.HR;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace BD.Data
{
    public class HRDContext:DbContext
    {
        public HRDContext(): base("DefaultConnection")
        {

        }

        public DbSet<Country> Countries { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Job> Jobs { get; set; }
        public DbSet<Dismissal> Dismissals { get; set; }
    }
}