namespace TotalControl.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class changes : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Fields", "Index", c => c.String());
            AlterColumn("dbo.Forms", "DateConducted", c => c.DateTime());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Forms", "DateConducted", c => c.DateTime(nullable: false));
            DropColumn("dbo.Fields", "Index");
        }
    }
}
