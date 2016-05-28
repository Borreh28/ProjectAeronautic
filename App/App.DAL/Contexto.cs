using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using App.Entities;
using System.Data.Entity.ModelConfiguration.Conventions;
using App.DAL.Mapeo;

namespace App.DAL
{
    public class Contexto : DbContext
    {
        public DbSet<Requisicion> Requisiciones { get; set; }
        public DbSet<RequisicionLinea> Lineas { get; set; }
        public DbSet<Proveedor> Proveedores { get; set; }
        public DbSet<Departamento> Departamentos { get; set; }

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
        }
    }
}
