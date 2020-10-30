namespace Hff.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class deletedMyProperty : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Bills", "MyProperty");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Bills", "MyProperty", c => c.Int(nullable: false));
        }
    }
}
