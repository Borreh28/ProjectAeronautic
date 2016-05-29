namespace App.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DBv10 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.TBL_Requisicion", "Activo", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.TBL_Requisicion", "Activo");
        }
    }
}
