namespace BD.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangeDate3 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Employees", "BirthDate", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Employees", "СomeDate", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Employees", "СomeDate", c => c.DateTime());
            AlterColumn("dbo.Employees", "BirthDate", c => c.DateTime());
        }
    }
}
