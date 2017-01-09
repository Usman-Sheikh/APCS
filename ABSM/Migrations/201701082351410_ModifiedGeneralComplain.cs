namespace ABSM.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ModifiedGeneralComplain : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.GeneralComplains", "Email", c => c.String(nullable: false));
            DropColumn("dbo.GeneralComplains", "Address");
        }
        
        public override void Down()
        {
            AddColumn("dbo.GeneralComplains", "Address", c => c.String());
            DropColumn("dbo.GeneralComplains", "Email");
        }
    }
}
