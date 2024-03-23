namespace PersonalManagement.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Deduction",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        DeductionType = c.String(),
                        Sum = c.Int(nullable: false),
                        Employee_ID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Employee", t => t.Employee_ID)
                .Index(t => t.Employee_ID);
            
            CreateTable(
                "dbo.Employee",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        LastName = c.String(),
                        Profession = c.String(),
                        EmployedDate = c.DateTime(nullable: false),
                        BirthDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Deduction", "Employee_ID", "dbo.Employee");
            DropIndex("dbo.Deduction", new[] { "Employee_ID" });
            DropTable("dbo.Employee");
            DropTable("dbo.Deduction");
        }
    }
}
