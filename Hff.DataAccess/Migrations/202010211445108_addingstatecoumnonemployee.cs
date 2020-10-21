namespace Hff.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addingstatecoumnonemployee : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Employees", "State", c => c.Boolean(nullable: false));
            AddColumn("dbo.Departments", "State", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Departments", "State");
            DropColumn("dbo.Employees", "State");
        }
    }
}
