namespace App.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Init : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.TBL_Departamento",
                c => new
                    {
                        Departamento_ID = c.Int(nullable: false, identity: true),
                        Edificio_ID = c.Int(nullable: false),
                        Activo = c.Boolean(nullable: false),
                        Nombre = c.String(nullable: false, maxLength: 60),
                        CreatedBy = c.Int(nullable: false),
                        Created = c.DateTime(nullable: false),
                        UpdatedBy = c.Int(nullable: false),
                        Updated = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Departamento_ID);
            
            CreateTable(
                "dbo.TBL_Requisicion",
                c => new
                    {
                        Requisicion_ID = c.Int(nullable: false, identity: true),
                        C_Period_ID = c.Int(nullable: false),
                        Departamento_ID = c.Int(nullable: false),
                        C_Proveedor_ID = c.Int(nullable: false),
                        C_Moneda_ID = c.Int(nullable: false),
                        C_Estatus_ID = c.Int(nullable: false),
                        Total_Lineas = c.Int(nullable: false),
                        SubTotal = c.Decimal(nullable: false, storeType: "money"),
                        Interes = c.Decimal(nullable: false, storeType: "money"),
                        GranTotal = c.Decimal(nullable: false, storeType: "money"),
                        CreatedBy = c.Int(nullable: false),
                        Created = c.DateTime(nullable: false),
                        UpdatedBy = c.Int(nullable: false),
                        Updated = c.DateTime(nullable: false),
                        Descipcion = c.String(nullable: false, maxLength: 500),
                        FechaReq = c.DateTime(nullable: false),
                        FechaEntrega = c.DateTime(nullable: false),
                        Comentarios = c.String(nullable: false, maxLength: 500),
                        C_Prioridad_ID = c.String(nullable: false, maxLength: 60),
                        Activo = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Requisicion_ID)
                .ForeignKey("dbo.TBL_Departamento", t => t.Departamento_ID, cascadeDelete: true)
                .ForeignKey("dbo.TBL_Estatus", t => t.C_Estatus_ID, cascadeDelete: true)
                .ForeignKey("dbo.TBL_Periodo", t => t.C_Period_ID, cascadeDelete: true)
                .ForeignKey("dbo.TBL_Prioridad", t => t.C_Prioridad_ID, cascadeDelete: true)
                .ForeignKey("dbo.TBL_Proveedor", t => t.C_Proveedor_ID, cascadeDelete: true)
                .Index(t => t.C_Period_ID)
                .Index(t => t.Departamento_ID)
                .Index(t => t.C_Proveedor_ID)
                .Index(t => t.C_Estatus_ID)
                .Index(t => t.C_Prioridad_ID);
            
            CreateTable(
                "dbo.TBL_Estatus",
                c => new
                    {
                        Estatus_ID = c.Int(nullable: false, identity: true),
                        Nombre = c.String(nullable: false, maxLength: 60),
                    })
                .PrimaryKey(t => t.Estatus_ID);
            
            CreateTable(
                "dbo.TBL_RequisicionLinea",
                c => new
                    {
                        RequisicionLinea_ID = c.Int(nullable: false, identity: true),
                        Requisicion_ID = c.Int(nullable: false),
                        Linea = c.Int(nullable: false),
                        C_Parte_ID = c.Int(nullable: false),
                        Cantidad = c.Int(nullable: false),
                        Precio_Venta = c.Decimal(nullable: false, storeType: "money"),
                        Descipcion = c.String(nullable: false, maxLength: 500),
                        CreatedBy = c.Int(nullable: false),
                        Created = c.DateTime(nullable: false),
                        UpdatedBy = c.Int(nullable: false),
                        Updated = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.RequisicionLinea_ID)
                .ForeignKey("dbo.TBL_Requisicion", t => t.Requisicion_ID, cascadeDelete: true)
                .Index(t => t.Requisicion_ID);
            
            CreateTable(
                "dbo.TBL_Periodo",
                c => new
                    {
                        Periodo_ID = c.Int(nullable: false, identity: true),
                        Nombre = c.String(nullable: false, maxLength: 60),
                    })
                .PrimaryKey(t => t.Periodo_ID);
            
            CreateTable(
                "dbo.TBL_Prioridad",
                c => new
                    {
                        Prioridad_ID = c.String(nullable: false, maxLength: 60),
                    })
                .PrimaryKey(t => t.Prioridad_ID);
            
            CreateTable(
                "dbo.TBL_Proveedor",
                c => new
                    {
                        Proveedor_ID = c.Int(nullable: false, identity: true),
                        Activo = c.Boolean(nullable: false),
                        Nombre = c.String(nullable: false, maxLength: 60),
                        CreatedBy = c.Int(nullable: false),
                        Created = c.DateTime(nullable: false),
                        UpdatedBy = c.Int(nullable: false),
                        Updated = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Proveedor_ID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.TBL_Requisicion", "C_Proveedor_ID", "dbo.TBL_Proveedor");
            DropForeignKey("dbo.TBL_Requisicion", "C_Prioridad_ID", "dbo.TBL_Prioridad");
            DropForeignKey("dbo.TBL_Requisicion", "C_Period_ID", "dbo.TBL_Periodo");
            DropForeignKey("dbo.TBL_RequisicionLinea", "Requisicion_ID", "dbo.TBL_Requisicion");
            DropForeignKey("dbo.TBL_Requisicion", "C_Estatus_ID", "dbo.TBL_Estatus");
            DropForeignKey("dbo.TBL_Requisicion", "Departamento_ID", "dbo.TBL_Departamento");
            DropIndex("dbo.TBL_RequisicionLinea", new[] { "Requisicion_ID" });
            DropIndex("dbo.TBL_Requisicion", new[] { "C_Prioridad_ID" });
            DropIndex("dbo.TBL_Requisicion", new[] { "C_Estatus_ID" });
            DropIndex("dbo.TBL_Requisicion", new[] { "C_Proveedor_ID" });
            DropIndex("dbo.TBL_Requisicion", new[] { "Departamento_ID" });
            DropIndex("dbo.TBL_Requisicion", new[] { "C_Period_ID" });
            DropTable("dbo.TBL_Proveedor");
            DropTable("dbo.TBL_Prioridad");
            DropTable("dbo.TBL_Periodo");
            DropTable("dbo.TBL_RequisicionLinea");
            DropTable("dbo.TBL_Estatus");
            DropTable("dbo.TBL_Requisicion");
            DropTable("dbo.TBL_Departamento");
        }
    }
}
