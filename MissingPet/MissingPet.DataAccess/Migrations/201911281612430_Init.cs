namespace MissingPet.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Init : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.AccountPhoneNumbers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        PhoneNumber = c.String(),
                        IsPrimary = c.Boolean(nullable: false),
                        AccountId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Accounts", t => t.AccountId, cascadeDelete: true)
                .Index(t => t.AccountId);
            
            CreateTable(
                "dbo.Accounts",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FirstName = c.String(),
                        LastName = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
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
                        AdvertAddressDetailsId = c.Int(nullable: false),
                        AccountId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Accounts", t => t.AccountId, cascadeDelete: true)
                .Index(t => t.AccountId);
            
            CreateTable(
                "dbo.AdvertAddressDetails",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        City = c.String(),
                        Street = c.String(),
                        AdvertId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Adverts", t => t.Id)
                .Index(t => t.Id);
            
            CreateTable(
                "dbo.AdvertImage",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Url = c.String(),
                        Name = c.String(),
                        AdvertId = c.Int(nullable: false),
                        Advertisement_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Adverts", t => t.Advertisement_Id)
                .Index(t => t.Advertisement_Id);
            
            CreateTable(
                "dbo.Tags",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Value = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.AdvertTags",
                c => new
                    {
                        AdvertEntity_Id = c.Int(nullable: false),
                        TagEntity_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.AdvertEntity_Id, t.TagEntity_Id })
                .ForeignKey("dbo.Adverts", t => t.AdvertEntity_Id, cascadeDelete: true)
                .ForeignKey("dbo.Tags", t => t.TagEntity_Id, cascadeDelete: true)
                .Index(t => t.AdvertEntity_Id)
                .Index(t => t.TagEntity_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AdvertTags", "TagEntity_Id", "dbo.Tags");
            DropForeignKey("dbo.AdvertTags", "AdvertEntity_Id", "dbo.Adverts");
            DropForeignKey("dbo.AdvertImage", "Advertisement_Id", "dbo.Adverts");
            DropForeignKey("dbo.AdvertAddressDetails", "Id", "dbo.Adverts");
            DropForeignKey("dbo.Adverts", "AccountId", "dbo.Accounts");
            DropForeignKey("dbo.AccountPhoneNumbers", "AccountId", "dbo.Accounts");
            DropIndex("dbo.AdvertTags", new[] { "TagEntity_Id" });
            DropIndex("dbo.AdvertTags", new[] { "AdvertEntity_Id" });
            DropIndex("dbo.AdvertImage", new[] { "Advertisement_Id" });
            DropIndex("dbo.AdvertAddressDetails", new[] { "Id" });
            DropIndex("dbo.Adverts", new[] { "AccountId" });
            DropIndex("dbo.AccountPhoneNumbers", new[] { "AccountId" });
            DropTable("dbo.AdvertTags");
            DropTable("dbo.Tags");
            DropTable("dbo.AdvertImage");
            DropTable("dbo.AdvertAddressDetails");
            DropTable("dbo.Adverts");
            DropTable("dbo.Accounts");
            DropTable("dbo.AccountPhoneNumbers");
        }
    }
}
