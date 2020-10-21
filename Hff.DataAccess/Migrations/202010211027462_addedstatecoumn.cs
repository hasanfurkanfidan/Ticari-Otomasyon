namespace Hff.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addedstatecoumn : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Customers", "State", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Customers", "State");
        }
    }
}
