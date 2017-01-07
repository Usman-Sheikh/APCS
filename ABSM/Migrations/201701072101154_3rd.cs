namespace ABSM.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _3rd : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.PriceComplains",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Email = c.String(nullable: false),
                        Phone = c.String(nullable: false),
                        ProductID = c.Int(nullable: false),
                        ExpectedPrice = c.Int(nullable: false),
                        ShopID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Products", t => t.ProductID, cascadeDelete: true)
                .ForeignKey("dbo.Shops", t => t.ShopID, cascadeDelete: false)
                .Index(t => t.ProductID)
                .Index(t => t.ShopID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.PriceComplains", "ShopID", "dbo.Shops");
            DropForeignKey("dbo.PriceComplains", "ProductID", "dbo.Products");
            DropIndex("dbo.PriceComplains", new[] { "ShopID" });
            DropIndex("dbo.PriceComplains", new[] { "ProductID" });
            DropTable("dbo.PriceComplains");
        }
    }
}
