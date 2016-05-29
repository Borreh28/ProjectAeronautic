using App.Entities;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;

namespace App.DAL.Mapeo
{
    public class RequisicionMapper
    {
        public RequisicionMapper(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Requisicion>().ToTable("TBL_Requisicion");
            modelBuilder.Entity<Requisicion>().HasKey(r => r.Id);

            modelBuilder.Entity<Requisicion>().Property(r => r.Id).HasColumnName("Requisicion_ID").HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            modelBuilder.Entity<Requisicion>().Property(r => r.PeriodoId).HasColumnName("C_Period_ID").IsRequired();
            modelBuilder.Entity<Requisicion>().Property(r => r.DepartamentoId).HasColumnName("Departamento_ID").IsRequired();
            modelBuilder.Entity<Requisicion>().Property(r => r.ProveedorId).HasColumnName("C_Proveedor_ID").IsRequired();
            modelBuilder.Entity<Requisicion>().Property(r => r.MonedaId).HasColumnName("C_Moneda_ID").IsRequired();
            modelBuilder.Entity<Requisicion>().Property(r => r.EstatusId).HasColumnName("C_Estatus_ID").IsRequired();
            modelBuilder.Entity<Requisicion>().Property(r => r.TotalLineas).HasColumnName("Total_Lineas").IsRequired();
            modelBuilder.Entity<Requisicion>().Property(r => r.SubTotal).HasColumnName("SubTotal").HasColumnType("Money").IsRequired();
            modelBuilder.Entity<Requisicion>().Property(r => r.Interes).HasColumnName("Interes").HasColumnType("Money").IsRequired();
            modelBuilder.Entity<Requisicion>().Property(r => r.GranTotal).HasColumnName("GranTotal").HasColumnType("Money").IsRequired();
            modelBuilder.Entity<Requisicion>().Property(r => r.CreadoPor).HasColumnName("CreatedBy").IsRequired();
            modelBuilder.Entity<Requisicion>().Property(r => r.Creado).HasColumnName("Created").IsRequired();
            modelBuilder.Entity<Requisicion>().Property(r => r.ActualizadoPor).HasColumnName("UpdatedBy").IsRequired();
            modelBuilder.Entity<Requisicion>().Property(r => r.Actualizado).HasColumnName("Updated").IsRequired();
            modelBuilder.Entity<Requisicion>().Property(r => r.Descripcion).HasColumnName("Descipcion").HasMaxLength(500).IsRequired();
            modelBuilder.Entity<Requisicion>().Property(r => r.FechaRequisicion).HasColumnName("FechaReq").IsRequired();
            modelBuilder.Entity<Requisicion>().Property(r => r.FechaEntrega).HasColumnName("FechaEntrega").IsRequired();
            modelBuilder.Entity<Requisicion>().Property(r => r.Comentarios).HasColumnName("Comentarios").HasMaxLength(500).IsRequired();
            modelBuilder.Entity<Requisicion>().Property(r => r.PrioridadId).HasColumnName("C_Prioridad_ID").IsRequired();
            modelBuilder.Entity<Requisicion>().Property(r => r.Activo).HasColumnName("Activo").IsRequired();

            modelBuilder.Entity<Requisicion>()
                .HasRequired(r => r.Proveedor)
                .WithMany(p => p.Requisiciones)
                .HasForeignKey(fk => fk.ProveedorId);

            modelBuilder.Entity<Requisicion>()
                .HasRequired(r => r.Departamento)
                .WithMany(d => d.Requisiciones)
                .HasForeignKey(fk => fk.DepartamentoId);
        }
    }
}
