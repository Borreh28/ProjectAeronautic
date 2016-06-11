using App.Entities;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;

namespace App.DAL.Mapeo
{
    public class DepartamentoMapper
    {
        public DepartamentoMapper(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Department>().ToTable("TBL_Departamento");
            modelBuilder.Entity<Department>().HasKey(d => d.Id);

            modelBuilder.Entity<Department>().Property(d => d.Id).HasColumnName("Departamento_ID").HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            modelBuilder.Entity<Department>().Property(d => d.BuildingId).HasColumnName("Edificio_ID").IsRequired();
            modelBuilder.Entity<Department>().Property(d => d.Active).HasColumnName("Activo").IsRequired();
            modelBuilder.Entity<Department>().Property(d => d.Name).HasColumnName("Nombre").HasMaxLength(60).IsRequired();
            modelBuilder.Entity<Department>().Property(d => d.CreatedBy).HasColumnName("CreatedBy").IsRequired();
            modelBuilder.Entity<Department>().Property(d => d.Created).HasColumnName("Created").IsRequired();
            modelBuilder.Entity<Department>().Property(d => d.UpdatedBy).HasColumnName("UpdatedBy").IsRequired();
            modelBuilder.Entity<Department>().Property(d => d.Updated).HasColumnName("Updated").IsRequired();
        }
    }
}
