namespace App.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DBv10 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.TBL_RequisitionRule",
                c => new
                    {
                        RequisitionRuleID = c.Int(nullable: false, identity: true),
                        RequisitionID = c.Int(nullable: false),
                        AuthorizationState = c.String(nullable: false, maxLength: 60),
                        CreatedBy = c.Int(nullable: false),
                        Created = c.DateTime(nullable: false),
                        UpdatedBy = c.Int(nullable: false),
                        Updated = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.RequisitionRuleID)
                .ForeignKey("dbo.TBL_Requisition", t => t.RequisitionID, cascadeDelete: true)
                .Index(t => t.RequisitionID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.TBL_RequisitionRule", "RequisitionID", "dbo.TBL_Requisition");
            DropIndex("dbo.TBL_RequisitionRule", new[] { "RequisitionID" });
            DropTable("dbo.TBL_RequisitionRule");
        }
    }
}
