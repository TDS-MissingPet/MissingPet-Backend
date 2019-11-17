namespace MissingPet.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Init : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.AdvertAddressDetails",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        City = c.String(),
                        Street = c.String(),
                        AdvertId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Adverts", t => t.AdvertId, cascadeDelete: true)
                .Index(t => t.AdvertId);
            
            CreateTable(
                "dbo.Adverts",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        Text = c.String(),
                        Reward = c.Double(nullable: false),
                        IsClosed = c.Boolean(nullable: false),
                        CreationDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.AdvertImages",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Url = c.String(),
                        Name = c.String(),
                        AdvertId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Adverts", t => t.AdvertId, cascadeDelete: true)
                .Index(t => t.AdvertId);
            
            CreateTable(
                "dbo.ContactPersonDetails",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FirstName = c.String(),
                        LastName = c.String(),
                        PhoneNumber = c.String(),
                        AdvertId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Adverts", t => t.AdvertId, cascadeDelete: true)
                .Index(t => t.AdvertId);
            
            CreateTable(
                "dbo.Tags",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Value = c.String(),
                        AdvertId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Adverts", t => t.AdvertId, cascadeDelete: true)
                .Index(t => t.AdvertId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AdvertAddressDetails", "AdvertId", "dbo.Adverts");
            DropForeignKey("dbo.Tags", "AdvertId", "dbo.Adverts");
            DropForeignKey("dbo.ContactPersonDetails", "AdvertId", "dbo.Adverts");
            DropForeignKey("dbo.AdvertImages", "AdvertId", "dbo.Adverts");
            DropIndex("dbo.Tags", new[] { "AdvertId" });
            DropIndex("dbo.ContactPersonDetails", new[] { "AdvertId" });
            DropIndex("dbo.AdvertImages", new[] { "AdvertId" });
            DropIndex("dbo.AdvertAddressDetails", new[] { "AdvertId" });
            DropTable("dbo.Tags");
            DropTable("dbo.ContactPersonDetails");
            DropTable("dbo.AdvertImages");
            DropTable("dbo.Adverts");
            DropTable("dbo.AdvertAddressDetails");
        }
    }
}
