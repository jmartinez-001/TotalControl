namespace TotalControl.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class newdatabase : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Employees",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FirstName = c.String(),
                        LastName = c.String(),
                        ManagerId = c.Int(),
                        UserId = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Employees", t => t.ManagerId)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId)
                .Index(t => t.ManagerId)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.AspNetUsers",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Email = c.String(maxLength: 256),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        PhoneNumber = c.String(),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        UserName = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.UserName, unique: true, name: "UserNameIndex");
            
            CreateTable(
                "dbo.AspNetUserClaims",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(nullable: false, maxLength: 128),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.AspNetUserLogins",
                c => new
                    {
                        LoginProvider = c.String(nullable: false, maxLength: 128),
                        ProviderKey = c.String(nullable: false, maxLength: 128),
                        UserId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.LoginProvider, t.ProviderKey, t.UserId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.AspNetUserRoles",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        RoleId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.UserId, t.RoleId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetRoles", t => t.RoleId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.RoleId);
            
            CreateTable(
                "dbo.Fields",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Subject = c.String(),
                        Entry = c.String(),
                        NonApplicable = c.Boolean(),
                        Form_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Forms", t => t.Form_Id)
                .Index(t => t.Form_Id);
            
            CreateTable(
                "dbo.Forms",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        SectionId = c.Int(nullable: false),
                        Name = c.String(),
                        DateCreated = c.DateTime(nullable: false),
                        DateConducted = c.DateTime(nullable: false),
                        PreparedBy = c.String(),
                        Version = c.Double(nullable: false),
                        Procedures = c.String(),
                        CorrectiveAction = c.String(),
                        ActionsTaken = c.String(),
                        Comments = c.String(),
                        Photo = c.Binary(),
                        Signature = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Sections", t => t.SectionId, cascadeDelete: true)
                .Index(t => t.SectionId);
            
            CreateTable(
                "dbo.Sections",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ParentId = c.Int(),
                        Name = c.String(),
                        TeamId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Sections", t => t.ParentId)
                .ForeignKey("dbo.Teams", t => t.TeamId, cascadeDelete: true)
                .Index(t => t.ParentId)
                .Index(t => t.TeamId);
            
            CreateTable(
                "dbo.Teams",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.AspNetRoles",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Name, unique: true, name: "RoleNameIndex");
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles");
            DropForeignKey("dbo.Forms", "SectionId", "dbo.Sections");
            DropForeignKey("dbo.Sections", "TeamId", "dbo.Teams");
            DropForeignKey("dbo.Sections", "ParentId", "dbo.Sections");
            DropForeignKey("dbo.Fields", "Form_Id", "dbo.Forms");
            DropForeignKey("dbo.Employees", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.Employees", "ManagerId", "dbo.Employees");
            DropIndex("dbo.AspNetRoles", "RoleNameIndex");
            DropIndex("dbo.Sections", new[] { "TeamId" });
            DropIndex("dbo.Sections", new[] { "ParentId" });
            DropIndex("dbo.Forms", new[] { "SectionId" });
            DropIndex("dbo.Fields", new[] { "Form_Id" });
            DropIndex("dbo.AspNetUserRoles", new[] { "RoleId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "UserId" });
            DropIndex("dbo.AspNetUserLogins", new[] { "UserId" });
            DropIndex("dbo.AspNetUserClaims", new[] { "UserId" });
            DropIndex("dbo.AspNetUsers", "UserNameIndex");
            DropIndex("dbo.Employees", new[] { "UserId" });
            DropIndex("dbo.Employees", new[] { "ManagerId" });
            DropTable("dbo.AspNetRoles");
            DropTable("dbo.Teams");
            DropTable("dbo.Sections");
            DropTable("dbo.Forms");
            DropTable("dbo.Fields");
            DropTable("dbo.AspNetUserRoles");
            DropTable("dbo.AspNetUserLogins");
            DropTable("dbo.AspNetUserClaims");
            DropTable("dbo.AspNetUsers");
            DropTable("dbo.Employees");
        }
    }
}
