namespace Hff.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class fixedempoyee : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Employees", "Department_DepartmentId", "dbo.Departments");
            DropIndex("dbo.Employees", new[] { "Department_DepartmentId" });
            RenameColumn(table: "dbo.Employees", name: "Department_DepartmentId", newName: "DepartmentId");
            AlterColumn("dbo.Employees", "DepartmentId", c => c.Int(nullable: false));
            CreateIndex("dbo.Employees", "DepartmentId");
            AddForeignKey("dbo.Employees", "DepartmentId", "dbo.Departments", "DepartmentId", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Employees", "DepartmentId", "dbo.Departments");
            DropIndex("dbo.Employees", new[] { "DepartmentId" });
            AlterColumn("dbo.Employees", "DepartmentId", c => c.Int());
            RenameColumn(table: "dbo.Employees", name: "DepartmentId", newName: "Department_DepartmentId");
            CreateIndex("dbo.Employees", "Department_DepartmentId");
            AddForeignKey("dbo.Employees", "Department_DepartmentId", "dbo.Departments", "DepartmentId");
        }
    }
}
