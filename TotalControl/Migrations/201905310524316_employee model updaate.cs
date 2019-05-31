namespace TotalControl.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class employeemodelupdaate : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Employees", "TeamId", c => c.Int());
            AddColumn("dbo.Employees", "SectionId", c => c.Int());
            CreateIndex("dbo.Employees", "TeamId");
            CreateIndex("dbo.Employees", "SectionId");
            AddForeignKey("dbo.Employees", "SectionId", "dbo.Sections", "Id");
            AddForeignKey("dbo.Employees", "TeamId", "dbo.Teams", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Employees", "TeamId", "dbo.Teams");
            DropForeignKey("dbo.Employees", "SectionId", "dbo.Sections");
            DropIndex("dbo.Employees", new[] { "SectionId" });
            DropIndex("dbo.Employees", new[] { "TeamId" });
            DropColumn("dbo.Employees", "SectionId");
            DropColumn("dbo.Employees", "TeamId");
        }
    }
}
