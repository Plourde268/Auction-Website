namespace AuctionWarehouse.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class segundo : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Addresses", "CreatedUserId", c => c.String());
            AddColumn("dbo.Addresses", "UpdatedUserId", c => c.String());
            AddColumn("dbo.Bids", "CreatedUserId", c => c.String());
            AddColumn("dbo.Bids", "UpdatedUserId", c => c.String());
            AddColumn("dbo.Buyers", "UserId", c => c.String(maxLength: 128));
            AddColumn("dbo.Buyers", "CreatedUserId", c => c.String());
            AddColumn("dbo.Buyers", "UpdatedUserId", c => c.String());
            AddColumn("dbo.Items", "CreatedUserId", c => c.String());
            AddColumn("dbo.Items", "UpdatedUserId", c => c.String());
            AddColumn("dbo.Sellers", "UserId", c => c.String(maxLength: 128));
            AddColumn("dbo.Sellers", "CreatedUserId", c => c.String());
            AddColumn("dbo.Sellers", "UpdatedUserId", c => c.String());
            AddColumn("dbo.AspNetRoles", "Discriminator", c => c.String(nullable: false, maxLength: 128));
            AddColumn("dbo.Transactions", "CreatedUserId", c => c.String());
            AddColumn("dbo.Transactions", "UpdatedUserId", c => c.String());
            CreateIndex("dbo.Buyers", "UserId");
            CreateIndex("dbo.Sellers", "UserId");
            AddForeignKey("dbo.Sellers", "UserId", "dbo.AspNetUsers", "Id");
            AddForeignKey("dbo.Buyers", "UserId", "dbo.AspNetUsers", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Buyers", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.Sellers", "UserId", "dbo.AspNetUsers");
            DropIndex("dbo.Sellers", new[] { "UserId" });
            DropIndex("dbo.Buyers", new[] { "UserId" });
            DropColumn("dbo.Transactions", "UpdatedUserId");
            DropColumn("dbo.Transactions", "CreatedUserId");
            DropColumn("dbo.AspNetRoles", "Discriminator");
            DropColumn("dbo.Sellers", "UpdatedUserId");
            DropColumn("dbo.Sellers", "CreatedUserId");
            DropColumn("dbo.Sellers", "UserId");
            DropColumn("dbo.Items", "UpdatedUserId");
            DropColumn("dbo.Items", "CreatedUserId");
            DropColumn("dbo.Buyers", "UpdatedUserId");
            DropColumn("dbo.Buyers", "CreatedUserId");
            DropColumn("dbo.Buyers", "UserId");
            DropColumn("dbo.Bids", "UpdatedUserId");
            DropColumn("dbo.Bids", "CreatedUserId");
            DropColumn("dbo.Addresses", "UpdatedUserId");
            DropColumn("dbo.Addresses", "CreatedUserId");
        }
    }
}
