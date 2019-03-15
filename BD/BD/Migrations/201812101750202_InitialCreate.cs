namespace BD.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Countries",
                c => new
                    {
                        CountryId = c.Int(nullable: false, identity: true),
                        CountryName = c.String(),
                        CountryCode = c.String(),
                        DepQuant = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.CountryId);
            
            CreateTable(
                "dbo.Departments",
                c => new
                    {
                        DepartmentId = c.Int(nullable: false, identity: true),
                        DepartmentName = c.Int(nullable: false),
                        DepartmentCity = c.String(),
                        DepartmentAddress = c.String(),
                        EmplQuant = c.String(),
                        CountryId = c.Int(),
                    })
                .PrimaryKey(t => t.DepartmentId)
                .ForeignKey("dbo.Countries", t => t.CountryId)
                .Index(t => t.CountryId);
            
            CreateTable(
                "dbo.Employees",
                c => new
                    {
                        EmployeeId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Surname = c.String(),
                        MiddleName = c.String(),
                        PasportData = c.String(),
                        PhoneNumber = c.String(),
                        Graduate = c.String(),
                        BirthDate = c.DateTime(nullable: false),
                        Address = c.String(),
                        Languages = c.String(),
                        LastJob = c.String(),
                        СomeDate = c.DateTime(nullable: false),
                        ContractTerm = c.Int(nullable: false),
                        DepartmentId = c.Int(),
                    })
                .PrimaryKey(t => t.EmployeeId)
                .ForeignKey("dbo.Departments", t => t.DepartmentId)
                .Index(t => t.DepartmentId);
            
            CreateTable(
                "dbo.Jobs",
                c => new
                    {
                        JobId = c.String(nullable: false, maxLength: 128),
                        JobTitle = c.String(),
                        Salary = c.Int(nullable: false),
                        EmployeeId = c.Int(),
                    })
                .PrimaryKey(t => t.JobId)
                .ForeignKey("dbo.Employees", t => t.EmployeeId)
                .Index(t => t.EmployeeId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Jobs", "EmployeeId", "dbo.Employees");
            DropForeignKey("dbo.Employees", "DepartmentId", "dbo.Departments");
            DropForeignKey("dbo.Departments", "CountryId", "dbo.Countries");
            DropIndex("dbo.Jobs", new[] { "EmployeeId" });
            DropIndex("dbo.Employees", new[] { "DepartmentId" });
            DropIndex("dbo.Departments", new[] { "CountryId" });
            DropTable("dbo.Jobs");
            DropTable("dbo.Employees");
            DropTable("dbo.Departments");
            DropTable("dbo.Countries");
        }
    }
}
