namespace TotalControl.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class documents : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Documents",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        DateConducted = c.DateTime(),
                        PreparedBy = c.String(),
                        ActionsTaken = c.String(),
                        Comments = c.String(),
                        Photo = c.Binary(),
                        Signature = c.String(),
                        FormId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Forms", t => t.FormId, cascadeDelete: true)
                .Index(t => t.FormId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Documents", "FormId", "dbo.Forms");
            DropIndex("dbo.Documents", new[] { "FormId" });
            DropTable("dbo.Documents");
        }
    }
}
