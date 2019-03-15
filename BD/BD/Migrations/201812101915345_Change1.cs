namespace BD.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Change1 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Departments", "DepartmentName", c => c.String());
            AlterColumn("dbo.Departments", "EmplQuant", c => c.Int(nullable: false));
            DropColumn("dbo.Jobs", "JobTitle");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Jobs", "JobTitle", c => c.String());
            AlterColumn("dbo.Departments", "EmplQuant", c => c.String());
            AlterColumn("dbo.Departments", "DepartmentName", c => c.Int(nullable: false));
        }
    }
}
