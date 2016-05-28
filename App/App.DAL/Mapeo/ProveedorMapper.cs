using App.Entities;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;

namespace App.DAL.Mapeo
{
    public class ProveedorMapper
    {
        public ProveedorMapper(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Proveedor>().ToTable("TBL_Proveedor");
            modelBuilder.Entity<Proveedor>().HasKey(p => p.Id);

            modelBuilder.Entity<Proveedor>().Property(p => p.Id).HasColumnName("Proveedor_ID").HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            modelBuilder.Entity<Proveedor>().Property(p => p.Activo).HasColumnName("Activo").IsRequired();
            modelBuilder.Entity<Proveedor>().Property(p => p.Nombre).HasColumnName("Nombre").HasMaxLength(60).IsRequired();
            modelBuilder.Entity<Proveedor>().Property(p => p.CreadoPor).HasColumnName("CreatedBy").IsRequired();
            modelBuilder.Entity<Proveedor>().Property(p => p.Creado).HasColumnName("Created").IsRequired();
            modelBuilder.Entity<Proveedor>().Property(p => p.ActualizadoPor).HasColumnName("UpdatedBy").IsRequired();
            modelBuilder.Entity<Proveedor>().Property(p => p.Actualizado).HasColumnName("Updated").IsRequired();
        }
    }
}
