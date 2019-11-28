namespace MissingPet.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Removed_Unnecessary_Foreign_Key : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.AdvertImage", "Advertisement_Id", "dbo.Adverts");
            DropIndex("dbo.AdvertImage", new[] { "Advertisement_Id" });
            DropColumn("dbo.AdvertImage", "AdvertId");
            RenameColumn(table: "dbo.AdvertImage", name: "Advertisement_Id", newName: "AdvertId");
            AlterColumn("dbo.AdvertImage", "AdvertId", c => c.Int(nullable: false));
            CreateIndex("dbo.AdvertImage", "AdvertId");
            AddForeignKey("dbo.AdvertImage", "AdvertId", "dbo.Adverts", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AdvertImage", "AdvertId", "dbo.Adverts");
            DropIndex("dbo.AdvertImage", new[] { "AdvertId" });
            AlterColumn("dbo.AdvertImage", "AdvertId", c => c.Int());
            RenameColumn(table: "dbo.AdvertImage", name: "AdvertId", newName: "Advertisement_Id");
            AddColumn("dbo.AdvertImage", "AdvertId", c => c.Int(nullable: false));
            CreateIndex("dbo.AdvertImage", "Advertisement_Id");
            AddForeignKey("dbo.AdvertImage", "Advertisement_Id", "dbo.Adverts", "Id");
        }
    }
}
