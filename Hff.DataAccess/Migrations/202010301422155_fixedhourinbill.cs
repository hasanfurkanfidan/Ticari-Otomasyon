namespace Hff.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class fixedhourinbill : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Bills", "Hour", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Bills", "Hour", c => c.DateTime(nullable: false));
        }
    }
}
