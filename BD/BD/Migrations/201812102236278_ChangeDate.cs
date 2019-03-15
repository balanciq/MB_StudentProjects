namespace BD.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangeDate : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Dismissals", "BirthDate", c => c.DateTime());
            AlterColumn("dbo.Dismissals", "СomeDate", c => c.DateTime());
            AlterColumn("dbo.Dismissals", "DisDate", c => c.DateTime());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Dismissals", "DisDate", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Dismissals", "СomeDate", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Dismissals", "BirthDate", c => c.DateTime(nullable: false));
        }
    }
}
