using App.DAL.Mapeo;
using App.Entities;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace App.DAL
{
    public class Contexto : DbContext
    {
        public DbSet<Requisicion> Requisiciones { get; set; }
        public DbSet<RequisicionLinea> Lineas { get; set; }
        public DbSet<Proveedor> Proveedores { get; set; }
        public DbSet<Departamento> Departamentos { get; set; }
        public DbSet<Periodo> Periodos { get; set; }
        public DbSet<Estatus> Estatus { get; set; }
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
