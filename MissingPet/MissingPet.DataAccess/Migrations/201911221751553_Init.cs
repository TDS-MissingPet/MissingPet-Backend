namespace MissingPet.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Init : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Tags", "Advertisements_Id", "dbo.Adverts");
            DropIndex("dbo.Tags", new[] { "Advertisements_Id" });
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
            
            DropColumn("dbo.Tags", "AdvertId");
            DropColumn("dbo.Tags", "Advertisements_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Tags", "Advertisements_Id", c => c.Int());
            AddColumn("dbo.Tags", "AdvertId", c => c.Int(nullable: false));
            DropForeignKey("dbo.AdvertTags", "TagEntity_Id", "dbo.Tags");
            DropForeignKey("dbo.AdvertTags", "AdvertEntity_Id", "dbo.Adverts");
            DropIndex("dbo.AdvertTags", new[] { "TagEntity_Id" });
            DropIndex("dbo.AdvertTags", new[] { "AdvertEntity_Id" });
            DropTable("dbo.AdvertTags");
            CreateIndex("dbo.Tags", "Advertisements_Id");
            AddForeignKey("dbo.Tags", "Advertisements_Id", "dbo.Adverts", "Id");
        }
    }
}
