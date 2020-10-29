namespace Hff.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdatedProduct : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Products", "Stock", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Products", "Stock", c => c.Short(nullable: false));
        }
    }
}
