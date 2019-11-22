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
                        AccountId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Accounts", t => t.AccountId, cascadeDelete: true)
                .Index(t => t.AccountId);
            
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
                        AdvertId = c.Int(nullable: false),
                        Advertisements_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Adverts", t => t.Advertisements_Id)
                .Index(t => t.Advertisements_Id);
            
            CreateTable(
                "dbo.AdvertAddressDetails",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        City = c.String(),
                        Street = c.String(),
                        AdvertId = c.Int(nullable: false),
                        Advertisement_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Adverts", t => t.Advertisement_Id)
                .Index(t => t.Advertisement_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AdvertAddressDetails", "Advertisement_Id", "dbo.Adverts");
            DropForeignKey("dbo.Tags", "Advertisements_Id", "dbo.Adverts");
            DropForeignKey("dbo.AdvertImage", "Advertisement_Id", "dbo.Adverts");
            DropForeignKey("dbo.Adverts", "AccountId", "dbo.Accounts");
            DropForeignKey("dbo.AccountPhoneNumbers", "AccountId", "dbo.Accounts");
            DropIndex("dbo.AdvertAddressDetails", new[] { "Advertisement_Id" });
            DropIndex("dbo.Tags", new[] { "Advertisements_Id" });
            DropIndex("dbo.AdvertImage", new[] { "Advertisement_Id" });
            DropIndex("dbo.Adverts", new[] { "AccountId" });
            DropIndex("dbo.AccountPhoneNumbers", new[] { "AccountId" });
            DropTable("dbo.AdvertAddressDetails");
            DropTable("dbo.Tags");
            DropTable("dbo.AdvertImage");
            DropTable("dbo.Adverts");
            DropTable("dbo.Accounts");
            DropTable("dbo.AccountPhoneNumbers");
        }
    }
}
