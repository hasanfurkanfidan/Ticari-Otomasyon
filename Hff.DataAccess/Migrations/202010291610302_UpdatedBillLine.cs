namespace Hff.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdatedBillLine : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.BillLines", "Bill_BillId", "dbo.Bills");
            DropIndex("dbo.BillLines", new[] { "Bill_BillId" });
            RenameColumn(table: "dbo.BillLines", name: "Bill_BillId", newName: "BillId");
            AlterColumn("dbo.BillLines", "BillId", c => c.Int(nullable: false));
            CreateIndex("dbo.BillLines", "BillId");
            AddForeignKey("dbo.BillLines", "BillId", "dbo.Bills", "BillId", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.BillLines", "BillId", "dbo.Bills");
            DropIndex("dbo.BillLines", new[] { "BillId" });
            AlterColumn("dbo.BillLines", "BillId", c => c.Int());
            RenameColumn(table: "dbo.BillLines", name: "BillId", newName: "Bill_BillId");
            CreateIndex("dbo.BillLines", "Bill_BillId");
            AddForeignKey("dbo.BillLines", "Bill_BillId", "dbo.Bills", "BillId");
        }
    }
}
