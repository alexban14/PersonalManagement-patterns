namespace PersonalManagement.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddDeductionTypeEntity : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.DeductionType",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            AddColumn("dbo.Deduction", "DeductionTypeID", c => c.Int(nullable: false));
            CreateIndex("dbo.Deduction", "DeductionTypeID");
            AddForeignKey("dbo.Deduction", "DeductionTypeID", "dbo.DeductionType", "ID", cascadeDelete: true);
            DropColumn("dbo.Deduction", "DeductionType");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Deduction", "DeductionType", c => c.String());
            DropForeignKey("dbo.Deduction", "DeductionTypeID", "dbo.DeductionType");
            DropIndex("dbo.Deduction", new[] { "DeductionTypeID" });
            DropColumn("dbo.Deduction", "DeductionTypeID");
            DropTable("dbo.DeductionType");
        }
    }
}
