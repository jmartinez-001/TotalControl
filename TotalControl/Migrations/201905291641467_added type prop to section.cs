namespace TotalControl.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addedtypeproptosection : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Sections", "Type", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Sections", "Type");
        }
    }
}
