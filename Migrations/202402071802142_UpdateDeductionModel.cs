namespace PersonalManagement.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateDeductionModel : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Deduction", "Employee_ID", "dbo.Employee");
            DropIndex("dbo.Deduction", new[] { "Employee_ID" });
            RenameColumn(table: "dbo.Deduction", name: "Employee_ID", newName: "EmployeeID");
            AlterColumn("dbo.Deduction", "EmployeeID", c => c.Int(nullable: false));
            CreateIndex("dbo.Deduction", "EmployeeID");
            AddForeignKey("dbo.Deduction", "EmployeeID", "dbo.Employee", "ID", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Deduction", "EmployeeID", "dbo.Employee");
            DropIndex("dbo.Deduction", new[] { "EmployeeID" });
            AlterColumn("dbo.Deduction", "EmployeeID", c => c.Int());
            RenameColumn(table: "dbo.Deduction", name: "EmployeeID", newName: "Employee_ID");
            CreateIndex("dbo.Deduction", "Employee_ID");
            AddForeignKey("dbo.Deduction", "Employee_ID", "dbo.Employee", "ID");
        }
    }
}
