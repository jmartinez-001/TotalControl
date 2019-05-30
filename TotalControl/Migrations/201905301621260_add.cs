namespace TotalControl.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class add : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Fields", "Index");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Fields", "Index", c => c.String());
        }
    }
}
