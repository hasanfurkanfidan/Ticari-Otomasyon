namespace Hff.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class fixedsalesprocess : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.SalesProcesses", "Product_ProductId", "dbo.Products");
            DropForeignKey("dbo.SalesProcesses", "Customer_CustomerId", "dbo.Customers");
            DropForeignKey("dbo.SalesProcesses", "Employee_EmployeeId", "dbo.Employees");
            DropIndex("dbo.SalesProcesses", new[] { "Customer_CustomerId" });
            DropIndex("dbo.SalesProcesses", new[] { "Employee_EmployeeId" });
            DropIndex("dbo.SalesProcesses", new[] { "Product_ProductId" });
            RenameColumn(table: "dbo.SalesProcesses", name: "Product_ProductId", newName: "ProductId");
            RenameColumn(table: "dbo.SalesProcesses", name: "Customer_CustomerId", newName: "CustomerId");
            RenameColumn(table: "dbo.SalesProcesses", name: "Employee_EmployeeId", newName: "EmployeeId");
            AlterColumn("dbo.SalesProcesses", "CustomerId", c => c.Int(nullable: false));
            AlterColumn("dbo.SalesProcesses", "EmployeeId", c => c.Int(nullable: false));
            AlterColumn("dbo.SalesProcesses", "ProductId", c => c.Int(nullable: false));
            CreateIndex("dbo.SalesProcesses", "ProductId");
            CreateIndex("dbo.SalesProcesses", "CustomerId");
            CreateIndex("dbo.SalesProcesses", "EmployeeId");
            AddForeignKey("dbo.SalesProcesses", "ProductId", "dbo.Products", "ProductId", cascadeDelete: true);
            AddForeignKey("dbo.SalesProcesses", "CustomerId", "dbo.Customers", "CustomerId", cascadeDelete: true);
            AddForeignKey("dbo.SalesProcesses", "EmployeeId", "dbo.Employees", "EmployeeId", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.SalesProcesses", "EmployeeId", "dbo.Employees");
            DropForeignKey("dbo.SalesProcesses", "CustomerId", "dbo.Customers");
            DropForeignKey("dbo.SalesProcesses", "ProductId", "dbo.Products");
            DropIndex("dbo.SalesProcesses", new[] { "EmployeeId" });
            DropIndex("dbo.SalesProcesses", new[] { "CustomerId" });
            DropIndex("dbo.SalesProcesses", new[] { "ProductId" });
            AlterColumn("dbo.SalesProcesses", "ProductId", c => c.Int());
            AlterColumn("dbo.SalesProcesses", "EmployeeId", c => c.Int());
            AlterColumn("dbo.SalesProcesses", "CustomerId", c => c.Int());
            RenameColumn(table: "dbo.SalesProcesses", name: "EmployeeId", newName: "Employee_EmployeeId");
            RenameColumn(table: "dbo.SalesProcesses", name: "CustomerId", newName: "Customer_CustomerId");
            RenameColumn(table: "dbo.SalesProcesses", name: "ProductId", newName: "Product_ProductId");
            CreateIndex("dbo.SalesProcesses", "Product_ProductId");
            CreateIndex("dbo.SalesProcesses", "Employee_EmployeeId");
            CreateIndex("dbo.SalesProcesses", "Customer_CustomerId");
            AddForeignKey("dbo.SalesProcesses", "Employee_EmployeeId", "dbo.Employees", "EmployeeId");
            AddForeignKey("dbo.SalesProcesses", "Customer_CustomerId", "dbo.Customers", "CustomerId");
            AddForeignKey("dbo.SalesProcesses", "Product_ProductId", "dbo.Products", "ProductId");
        }
    }
}
