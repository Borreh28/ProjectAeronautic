using App.DAL.Mapeo;
using App.Entities;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace App.DAL
{
    public class Contexto : DbContext
    {
        public DbSet<Requisition> Requisiciones { get; set; }
        public DbSet<RequisitionLine> Lineas { get; set; }
        public DbSet<Proveedor> Proveedores { get; set; }
        public DbSet<Department> Departamentos { get; set; }
        public DbSet<Periodo> Periodos { get; set; }
        public DbSet<Status> Estatus { get; set; }
        public DbSet<Prioridad> Prioridad { get; set; }

        public Contexto() : base("DefaultConnection")
        {
            
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();

            new RequisicionMapper(modelBuilder);
            new RequisicionLineaMapper(modelBuilder);
            new ProveedorMapper(modelBuilder);
            new DepartamentoMapper(modelBuilder);
            new PeriodoMapper(modelBuilder);
            new EstatusMapper(modelBuilder);
            new PrioridadMapper(modelBuilder);
        }
    }
}
