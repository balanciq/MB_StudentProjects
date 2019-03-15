namespace BD.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddDisAct1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Dismissals",
                c => new
                    {
                        DismissalId = c.Int(nullable: false, identity: true),
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
                        DisDate = c.DateTime(nullable: false),
                        EmployeeId = c.Int(),
                    })
                .PrimaryKey(t => t.DismissalId)
                .ForeignKey("dbo.Employees", t => t.EmployeeId)
                .Index(t => t.EmployeeId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Dismissals", "EmployeeId", "dbo.Employees");
            DropIndex("dbo.Dismissals", new[] { "EmployeeId" });
            DropTable("dbo.Dismissals");
        }
    }
}
