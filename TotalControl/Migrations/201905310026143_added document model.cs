namespace TotalControl.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addeddocumentmodel : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Forms", "DateConducted");
            DropColumn("dbo.Forms", "PreparedBy");
            DropColumn("dbo.Forms", "ActionsTaken");
            DropColumn("dbo.Forms", "Comments");
            DropColumn("dbo.Forms", "Photo");
            DropColumn("dbo.Forms", "Signature");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Forms", "Signature", c => c.String());
            AddColumn("dbo.Forms", "Photo", c => c.Binary());
            AddColumn("dbo.Forms", "Comments", c => c.String());
            AddColumn("dbo.Forms", "ActionsTaken", c => c.String());
            AddColumn("dbo.Forms", "PreparedBy", c => c.String());
            AddColumn("dbo.Forms", "DateConducted", c => c.DateTime());
        }
    }
}
