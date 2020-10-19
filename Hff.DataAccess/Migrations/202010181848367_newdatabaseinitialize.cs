namespace Hff.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class newdatabaseinitialize : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Admins",
                c => new
                    {
                        AdminId = c.Int(nullable: false, identity: true),
                        UserName = c.String(),
                        Password = c.String(),
                        Role = c.String(maxLength: 8000, fixedLength: true, unicode: false),
                    })
                .PrimaryKey(t => t.AdminId);
            
            CreateTable(
                "dbo.BillLines",
                c => new
                    {
                        BillLineId = c.Int(nullable: false, identity: true),
                        Description = c.String(),
                        Quantity = c.Int(nullable: false),
                        UnitPrice = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Bill_BillId = c.Int(),
                    })
                .PrimaryKey(t => t.BillLineId)
                .ForeignKey("dbo.Bills", t => t.Bill_BillId)
                .Index(t => t.Bill_BillId);
            
            CreateTable(
                "dbo.Bills",
                c => new
                    {
                        BillId = c.Int(nullable: false, identity: true),
                        SerialNumber = c.String(),
                        RowNumber = c.String(),
                        Date = c.DateTime(nullable: false),
                        MyProperty = c.Int(nullable: false),
                        TaxAdministration = c.String(),
                        Hour = c.DateTime(nullable: false),
                        Deliverer = c.String(),
                        Receiver = c.String(),
                    })
                .PrimaryKey(t => t.BillId);
            
            CreateTable(
                "dbo.Categories",
                c => new
                    {
                        CategoryId = c.Int(nullable: false, identity: true),
                        CategoryName = c.String(),
                    })
                .PrimaryKey(t => t.CategoryId);
            
            CreateTable(
                "dbo.Products",
                c => new
                    {
                        ProductId = c.Int(nullable: false, identity: true),
                        ProductName = c.String(),
                        TradeMark = c.String(),
                        Stock = c.Short(nullable: false),
                        PurchasePrice = c.Decimal(nullable: false, precision: 18, scale: 2),
                        SalePrice = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Picture = c.String(),
                        Status = c.Boolean(nullable: false),
                        Category_CategoryId = c.Int(),
                    })
                .PrimaryKey(t => t.ProductId)
                .ForeignKey("dbo.Categories", t => t.Category_CategoryId)
                .Index(t => t.Category_CategoryId);
            
            CreateTable(
                "dbo.SalesProcesses",
                c => new
                    {
                        SaleId = c.Int(nullable: false, identity: true),
                        Date = c.DateTime(nullable: false),
                        Quantity = c.Int(nullable: false),
                        Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Total = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Customer_CustomerId = c.Int(),
                        Employee_EmployeeId = c.Int(),
                        Product_ProductId = c.Int(),
                    })
                .PrimaryKey(t => t.SaleId)
                .ForeignKey("dbo.Customers", t => t.Customer_CustomerId)
                .ForeignKey("dbo.Employees", t => t.Employee_EmployeeId)
                .ForeignKey("dbo.Products", t => t.Product_ProductId)
                .Index(t => t.Customer_CustomerId)
                .Index(t => t.Employee_EmployeeId)
                .Index(t => t.Product_ProductId);
            
            CreateTable(
                "dbo.Customers",
                c => new
                    {
                        CustomerId = c.Int(nullable: false, identity: true),
                        CustomerName = c.String(),
                        CustomerSurname = c.String(),
                        CustomerMail = c.String(),
                    })
                .PrimaryKey(t => t.CustomerId);
            
            CreateTable(
                "dbo.Employees",
                c => new
                    {
                        EmployeeId = c.Int(nullable: false, identity: true),
                        EmployeeName = c.String(),
                        EmployeeSurname = c.String(),
                        Picture = c.String(),
                        Department_DepartmentId = c.Int(),
                    })
                .PrimaryKey(t => t.EmployeeId)
                .ForeignKey("dbo.Departments", t => t.Department_DepartmentId)
                .Index(t => t.Department_DepartmentId);
            
            CreateTable(
                "dbo.Departments",
                c => new
                    {
                        DepartmentId = c.Int(nullable: false, identity: true),
                        DepartmentName = c.String(),
                    })
                .PrimaryKey(t => t.DepartmentId);
            
            CreateTable(
                "dbo.Expenses",
                c => new
                    {
                        ExpenseId = c.Int(nullable: false, identity: true),
                        Description = c.String(),
                        Date = c.DateTime(nullable: false),
                        Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.ExpenseId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.SalesProcesses", "Product_ProductId", "dbo.Products");
            DropForeignKey("dbo.SalesProcesses", "Employee_EmployeeId", "dbo.Employees");
            DropForeignKey("dbo.Employees", "Department_DepartmentId", "dbo.Departments");
            DropForeignKey("dbo.SalesProcesses", "Customer_CustomerId", "dbo.Customers");
            DropForeignKey("dbo.Products", "Category_CategoryId", "dbo.Categories");
            DropForeignKey("dbo.BillLines", "Bill_BillId", "dbo.Bills");
            DropIndex("dbo.Employees", new[] { "Department_DepartmentId" });
            DropIndex("dbo.SalesProcesses", new[] { "Product_ProductId" });
            DropIndex("dbo.SalesProcesses", new[] { "Employee_EmployeeId" });
            DropIndex("dbo.SalesProcesses", new[] { "Customer_CustomerId" });
            DropIndex("dbo.Products", new[] { "Category_CategoryId" });
            DropIndex("dbo.BillLines", new[] { "Bill_BillId" });
            DropTable("dbo.Expenses");
            DropTable("dbo.Departments");
            DropTable("dbo.Employees");
            DropTable("dbo.Customers");
            DropTable("dbo.SalesProcesses");
            DropTable("dbo.Products");
            DropTable("dbo.Categories");
            DropTable("dbo.Bills");
            DropTable("dbo.BillLines");
            DropTable("dbo.Admins");
        }
    }
}
