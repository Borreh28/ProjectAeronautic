namespace App.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Init : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.TBL_Department",
                c => new
                    {
                        DepartmentID = c.Int(nullable: false, identity: true),
                        BuildingID = c.Int(nullable: false),
                        Active = c.Boolean(nullable: false),
                        Name = c.String(nullable: false, maxLength: 60),
                        CreatedBy = c.Int(nullable: false),
                        Created = c.DateTime(nullable: false),
                        UpdatedBy = c.Int(nullable: false),
                        Updated = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.DepartmentID);
            
            CreateTable(
                "dbo.TBL_Requisition",
                c => new
                    {
                        RequisitionID = c.Int(nullable: false, identity: true),
                        PeriodID = c.Int(nullable: false),
                        DepartmentID = c.Int(nullable: false),
                        SupplierID = c.Int(nullable: false),
                        StatusID = c.Int(nullable: false),
                        PriorityID = c.Int(nullable: false),
                        Active = c.Boolean(nullable: false),
                        TotalLines = c.Int(nullable: false),
                        SubTotal = c.Decimal(nullable: false, storeType: "money"),
                        Interest = c.Decimal(nullable: false, storeType: "money"),
                        Total = c.Decimal(nullable: false, storeType: "money"),
                        RequisitionDate = c.DateTime(nullable: false),
                        DeliveryDate = c.DateTime(nullable: false),
                        Description = c.String(nullable: false, maxLength: 500),
                        Commentaries = c.String(nullable: false, maxLength: 500),
                        CreatedBy = c.Int(nullable: false),
                        Created = c.DateTime(nullable: false),
                        UpdatedBy = c.Int(nullable: false),
                        Updated = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.RequisitionID)
                .ForeignKey("dbo.TBL_Department", t => t.DepartmentID, cascadeDelete: true)
                .ForeignKey("dbo.TBL_Period", t => t.PeriodID, cascadeDelete: true)
                .ForeignKey("dbo.TBL_Priority", t => t.PriorityID, cascadeDelete: true)
                .ForeignKey("dbo.TBL_Status", t => t.StatusID, cascadeDelete: true)
                .ForeignKey("dbo.TBL_Supplier", t => t.SupplierID, cascadeDelete: true)
                .Index(t => t.PeriodID)
                .Index(t => t.DepartmentID)
                .Index(t => t.SupplierID)
                .Index(t => t.StatusID)
                .Index(t => t.PriorityID);
            
            CreateTable(
                "dbo.TBL_RequisitionLine",
                c => new
                    {
                        RequisitionLineID = c.Int(nullable: false, identity: true),
                        RequisitionID = c.Int(nullable: false),
                        ProductID = c.Int(nullable: false),
                        Line = c.Int(nullable: false),
                        Quantity = c.Int(nullable: false),
                        SalePrice = c.Decimal(nullable: false, storeType: "money"),
                        Description = c.String(nullable: false, maxLength: 500),
                        CreatedBy = c.Int(nullable: false),
                        Created = c.DateTime(nullable: false),
                        UpdatedBy = c.Int(nullable: false),
                        Updated = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.RequisitionLineID)
                .ForeignKey("dbo.TBL_Product", t => t.ProductID, cascadeDelete: true)
                .ForeignKey("dbo.TBL_Requisition", t => t.RequisitionID, cascadeDelete: true)
                .Index(t => t.RequisitionID)
                .Index(t => t.ProductID);
            
            CreateTable(
                "dbo.TBL_Product",
                c => new
                    {
                        ProductID = c.Int(nullable: false, identity: true),
                        SupplierID = c.Int(nullable: false),
                        CategoryID = c.Int(nullable: false),
                        Name = c.String(nullable: false, maxLength: 60),
                        UnitPrice = c.Decimal(nullable: false, storeType: "money"),
                        CostPrice = c.Decimal(nullable: false, storeType: "money"),
                        BudgetPrice = c.Decimal(nullable: false, storeType: "money"),
                        UnitPerPack = c.Short(nullable: false),
                        UM = c.String(nullable: false, maxLength: 60),
                        UnitInStock = c.Short(nullable: false),
                        UnitOnOrder = c.Short(nullable: false),
                        ReOrderLevel = c.Short(nullable: false),
                        Discontinued = c.Boolean(nullable: false),
                        CreatedBy = c.Int(nullable: false),
                        Created = c.DateTime(nullable: false),
                        UpdatedBy = c.Int(nullable: false),
                        Updated = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.ProductID)
                .ForeignKey("dbo.TBL_Supplier", t => t.SupplierID)
                .Index(t => t.SupplierID);
            
            CreateTable(
                "dbo.TBL_Supplier",
                c => new
                    {
                        SupplierID = c.Int(nullable: false, identity: true),
                        Active = c.Boolean(nullable: false),
                        Name = c.String(nullable: false, maxLength: 60),
                        CreatedBy = c.Int(nullable: false),
                        Created = c.DateTime(nullable: false),
                        UpdatedBy = c.Int(nullable: false),
                        Updated = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.SupplierID);
            
            CreateTable(
                "dbo.TBL_Period",
                c => new
                    {
                        PeriodID = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 60),
                        CreatedBy = c.Int(nullable: false),
                        Created = c.DateTime(nullable: false),
                        UpdatedBy = c.Int(nullable: false),
                        Updated = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.PeriodID);
            
            CreateTable(
                "dbo.TBL_Priority",
                c => new
                    {
                        PriorityID = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 60),
                        CreatedBy = c.Int(nullable: false),
                        Created = c.DateTime(nullable: false),
                        UpdatedBy = c.Int(nullable: false),
                        Updated = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.PriorityID);
            
            CreateTable(
                "dbo.TBL_Status",
                c => new
                    {
                        StatusID = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 60),
                        CreatedBy = c.Int(nullable: false),
                        Created = c.DateTime(nullable: false),
                        UpdatedBy = c.Int(nullable: false),
                        Updated = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.StatusID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.TBL_Requisition", "SupplierID", "dbo.TBL_Supplier");
            DropForeignKey("dbo.TBL_Requisition", "StatusID", "dbo.TBL_Status");
            DropForeignKey("dbo.TBL_Requisition", "PriorityID", "dbo.TBL_Priority");
            DropForeignKey("dbo.TBL_Requisition", "PeriodID", "dbo.TBL_Period");
            DropForeignKey("dbo.TBL_RequisitionLine", "RequisitionID", "dbo.TBL_Requisition");
            DropForeignKey("dbo.TBL_RequisitionLine", "ProductID", "dbo.TBL_Product");
            DropForeignKey("dbo.TBL_Product", "SupplierID", "dbo.TBL_Supplier");
            DropForeignKey("dbo.TBL_Requisition", "DepartmentID", "dbo.TBL_Department");
            DropIndex("dbo.TBL_Product", new[] { "SupplierID" });
            DropIndex("dbo.TBL_RequisitionLine", new[] { "ProductID" });
            DropIndex("dbo.TBL_RequisitionLine", new[] { "RequisitionID" });
            DropIndex("dbo.TBL_Requisition", new[] { "PriorityID" });
            DropIndex("dbo.TBL_Requisition", new[] { "StatusID" });
            DropIndex("dbo.TBL_Requisition", new[] { "SupplierID" });
            DropIndex("dbo.TBL_Requisition", new[] { "DepartmentID" });
            DropIndex("dbo.TBL_Requisition", new[] { "PeriodID" });
            DropTable("dbo.TBL_Status");
            DropTable("dbo.TBL_Priority");
            DropTable("dbo.TBL_Period");
            DropTable("dbo.TBL_Supplier");
            DropTable("dbo.TBL_Product");
            DropTable("dbo.TBL_RequisitionLine");
            DropTable("dbo.TBL_Requisition");
            DropTable("dbo.TBL_Department");
        }
    }
}
