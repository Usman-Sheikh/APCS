namespace ABSM.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class GeneralComplain : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.GeneralComplains",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Subject = c.String(nullable: false),
                        ImageUrl = c.String(),
                        Address = c.String(),
                        Description = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.GeneralComplains");
        }
    }
}
