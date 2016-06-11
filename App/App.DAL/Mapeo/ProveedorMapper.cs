using App.Entities;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;

namespace App.DAL.Mapeo
{
    public class ProveedorMapper
    {
        public ProveedorMapper(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Supplier>().ToTable("TBL_Proveedor");
            modelBuilder.Entity<Supplier>().HasKey(p => p.Id);

            modelBuilder.Entity<Supplier>().Property(p => p.Id).HasColumnName("Proveedor_ID").HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            modelBuilder.Entity<Supplier>().Property(p => p.Active).HasColumnName("Activo").IsRequired();
            modelBuilder.Entity<Supplier>().Property(p => p.Name).HasColumnName("Nombre").HasMaxLength(60).IsRequired();
            modelBuilder.Entity<Supplier>().Property(p => p.CreatedBy).HasColumnName("CreatedBy").IsRequired();
            modelBuilder.Entity<Supplier>().Property(p => p.Created).HasColumnName("Created").IsRequired();
            modelBuilder.Entity<Supplier>().Property(p => p.UpdatedBy).HasColumnName("UpdatedBy").IsRequired();
            modelBuilder.Entity<Supplier>().Property(p => p.Updated).HasColumnName("Updated").IsRequired();
        }
    }
}
