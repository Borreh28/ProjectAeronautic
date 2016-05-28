using App.Entities;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;

namespace App.DAL.Mapeo
{
    public class DepartamentoMapper
    {
        public DepartamentoMapper(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Departamento>().ToTable("TBL_Departamento");
            modelBuilder.Entity<Departamento>().HasKey(d => d.Id);

            modelBuilder.Entity<Departamento>().Property(d => d.Id).HasColumnName("Departamento_ID").HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            modelBuilder.Entity<Departamento>().Property(d => d.EdificioId).HasColumnName("Edificio_ID").IsRequired();
            modelBuilder.Entity<Departamento>().Property(d => d.Activo).HasColumnName("Activo").IsRequired();
            modelBuilder.Entity<Departamento>().Property(d => d.Nombre).HasColumnName("Nombre").HasMaxLength(60).IsRequired();
            modelBuilder.Entity<Departamento>().Property(d => d.CreadoPor).HasColumnName("CreatedBy").IsRequired();
            modelBuilder.Entity<Departamento>().Property(d => d.Creado).HasColumnName("Created").IsRequired();
            modelBuilder.Entity<Departamento>().Property(d => d.ActualizadoPor).HasColumnName("UpdatedBy").IsRequired();
            modelBuilder.Entity<Departamento>().Property(d => d.Actualizado).HasColumnName("Updated").IsRequired();
        }
    }
}
