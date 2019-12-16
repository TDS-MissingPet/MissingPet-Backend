namespace MissingPet.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedGuid : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Accounts", "IdentityId", c => c.Guid(nullable: true));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Accounts", "IdentityId");
        }
    }
}
