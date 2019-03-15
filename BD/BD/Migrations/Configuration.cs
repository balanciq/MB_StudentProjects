namespace BD.Migrations
{
    using BD.Data;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<BD.Data.HRDContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(BD.Data.HRDContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.
            context.Countries.AddOrUpdate(t => t.CountryId, DummyData.GetCountries().ToArray());
            context.SaveChanges();
            context.Departments.AddOrUpdate(p => p.DepartmentId, DummyData.GetDepartments().ToArray());
            context.SaveChanges();
            context.Employees.AddOrUpdate(k => k.EmployeeId, DummyData.GetEmployees().ToArray());
            context.SaveChanges();
            context.Jobs.AddOrUpdate(f => f.JobId, DummyData.GetJobs().ToArray());
            context.SaveChanges();
        }
    }
}
