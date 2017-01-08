namespace ABSM.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Listed : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Cities",
                c => new
                    {
                        CityID = c.Int(nullable: false, identity: true),
                        CityName = c.String(),
                    })
                .PrimaryKey(t => t.CityID);
            
            CreateTable(
                "dbo.RateLists",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        CategoryID = c.Int(nullable: false),
                        ProductID = c.Int(nullable: false),
                        Price = c.Int(nullable: false),
                        CityID = c.Int(nullable: false),
                        UpdatedDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Categories", t => t.CategoryID, cascadeDelete: false)
                .ForeignKey("dbo.Cities", t => t.CityID, cascadeDelete: false)
                .ForeignKey("dbo.Products", t => t.ProductID, cascadeDelete: false)
                .Index(t => t.CategoryID)
                .Index(t => t.ProductID)
                .Index(t => t.CityID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.RateLists", "ProductID", "dbo.Products");
            DropForeignKey("dbo.RateLists", "CityID", "dbo.Cities");
            DropForeignKey("dbo.RateLists", "CategoryID", "dbo.Categories");
            DropIndex("dbo.RateLists", new[] { "CityID" });
            DropIndex("dbo.RateLists", new[] { "ProductID" });
            DropIndex("dbo.RateLists", new[] { "CategoryID" });
            DropTable("dbo.RateLists");
            DropTable("dbo.Cities");
        }
    }
}
