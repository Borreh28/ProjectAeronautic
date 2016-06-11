using App.Entities;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;

namespace App.DAL.Mapeo
{
    public class RequisicionMapper
    {
        public RequisicionMapper(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Requisition>().ToTable("TBL_Requisicion");
            modelBuilder.Entity<Requisition>().HasKey(r => r.Id);

            modelBuilder.Entity<Requisition>().Property(r => r.Id).HasColumnName("Requisicion_ID").HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            modelBuilder.Entity<Requisition>().Property(r => r.PeriodoId).HasColumnName("C_Period_ID").IsRequired();
            modelBuilder.Entity<Requisition>().Property(r => r.DepartamentoId).HasColumnName("Departamento_ID").IsRequired();
            modelBuilder.Entity<Requisition>().Property(r => r.ProveedorId).HasColumnName("C_Proveedor_ID").IsRequired();
            modelBuilder.Entity<Requisition>().Property(r => r.MonedaId).HasColumnName("C_Moneda_ID").IsRequired();
            modelBuilder.Entity<Requisition>().Property(r => r.EstatusId).HasColumnName("C_Estatus_ID").IsRequired();
            modelBuilder.Entity<Requisition>().Property(r => r.TotalLineas).HasColumnName("Total_Lineas").IsRequired();
            modelBuilder.Entity<Requisition>().Property(r => r.SubTotal).HasColumnName("SubTotal").HasColumnType("Money").IsRequired();
            modelBuilder.Entity<Requisition>().Property(r => r.Interes).HasColumnName("Interes").HasColumnType("Money").IsRequired();
            modelBuilder.Entity<Requisition>().Property(r => r.GranTotal).HasColumnName("GranTotal").HasColumnType("Money").IsRequired();
            modelBuilder.Entity<Requisition>().Property(r => r.CreadoPor).HasColumnName("CreatedBy").IsRequired();
            modelBuilder.Entity<Requisition>().Property(r => r.Creado).HasColumnName("Created").IsRequired();
            modelBuilder.Entity<Requisition>().Property(r => r.ActualizadoPor).HasColumnName("UpdatedBy").IsRequired();
            modelBuilder.Entity<Requisition>().Property(r => r.Actualizado).HasColumnName("Updated").IsRequired();
            modelBuilder.Entity<Requisition>().Property(r => r.Descripcion).HasColumnName("Descipcion").HasMaxLength(500).IsRequired();
            modelBuilder.Entity<Requisition>().Property(r => r.FechaRequisicion).HasColumnName("FechaReq").IsRequired();
            modelBuilder.Entity<Requisition>().Property(r => r.FechaEntrega).HasColumnName("FechaEntrega").IsRequired();
            modelBuilder.Entity<Requisition>().Property(r => r.Comentarios).HasColumnName("Comentarios").HasMaxLength(500).IsRequired();
            modelBuilder.Entity<Requisition>().Property(r => r.PrioridadId).HasColumnName("C_Prioridad_ID").IsRequired();
            modelBuilder.Entity<Requisition>().Property(r => r.Activo).HasColumnName("Activo").IsRequired();

            modelBuilder.Entity<Requisition>()
                .HasRequired(r => r.Proveedor)
                .WithMany(p => p.Requisiciones)
                .HasForeignKey(fk => fk.ProveedorId);

            modelBuilder.Entity<Requisition>()
                .HasRequired(r => r.Departamento)
                .WithMany(d => d.Requisitions)
                .HasForeignKey(fk => fk.DepartamentoId);

            modelBuilder.Entity<Requisition>()
                .HasRequired(r => r.Periodo)
                .WithMany(p => p.Requisiciones)
                .HasForeignKey(fk => fk.PeriodoId);

            modelBuilder.Entity<Requisition>()
                .HasRequired(r => r.Estatus)
                .WithMany(e => e.Requisitions)
                .HasForeignKey(fk => fk.EstatusId);

            modelBuilder.Entity<Requisition>()
                .HasRequired(r => r.Prioridad)
                .WithMany(p => p.Requisiciones)
                .HasForeignKey(fk => fk.PrioridadId);
        }
    }
}
