namespace Emarket.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Update_tables : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Carts", "ProductId", "dbo.Products");
            DropPrimaryKey("dbo.Carts");
            AddPrimaryKey("dbo.Carts", "ProductId");
            AddForeignKey("dbo.Carts", "ProductId", "dbo.Products", "ProductId");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Carts", "ProductId", "dbo.Products");
            DropPrimaryKey("dbo.Carts");
            AddPrimaryKey("dbo.Carts", "added_at");
            AddForeignKey("dbo.Carts", "ProductId", "dbo.Products", "ProductId", cascadeDelete: true);
        }
    }
}
