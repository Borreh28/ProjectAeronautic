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
            modelBuilder.Entity<Requisition>().Property(r => r.PeriodId).HasColumnName("C_Period_ID").IsRequired();
            modelBuilder.Entity<Requisition>().Property(r => r.DepartmentId).HasColumnName("Departamento_ID").IsRequired();
            modelBuilder.Entity<Requisition>().Property(r => r.SupplierId).HasColumnName("C_Proveedor_ID").IsRequired();
            modelBuilder.Entity<Requisition>().Property(r => r.MonedaId).HasColumnName("C_Moneda_ID").IsRequired();
            modelBuilder.Entity<Requisition>().Property(r => r.StatusId).HasColumnName("C_Estatus_ID").IsRequired();
            modelBuilder.Entity<Requisition>().Property(r => r.TotalLines).HasColumnName("Total_Lineas").IsRequired();
            modelBuilder.Entity<Requisition>().Property(r => r.SubTotal).HasColumnName("SubTotal").HasColumnType("Money").IsRequired();
            modelBuilder.Entity<Requisition>().Property(r => r.Interest).HasColumnName("Interes").HasColumnType("Money").IsRequired();
            modelBuilder.Entity<Requisition>().Property(r => r.Total).HasColumnName("GranTotal").HasColumnType("Money").IsRequired();
            modelBuilder.Entity<Requisition>().Property(r => r.CreatedBy).HasColumnName("CreatedBy").IsRequired();
            modelBuilder.Entity<Requisition>().Property(r => r.Created).HasColumnName("Created").IsRequired();
            modelBuilder.Entity<Requisition>().Property(r => r.UpdatedBy).HasColumnName("UpdatedBy").IsRequired();
            modelBuilder.Entity<Requisition>().Property(r => r.Updated).HasColumnName("Updated").IsRequired();
            modelBuilder.Entity<Requisition>().Property(r => r.Description).HasColumnName("Descipcion").HasMaxLength(500).IsRequired();
            modelBuilder.Entity<Requisition>().Property(r => r.RequisitionDate).HasColumnName("FechaReq").IsRequired();
            modelBuilder.Entity<Requisition>().Property(r => r.DeliveryDate).HasColumnName("FechaEntrega").IsRequired();
            modelBuilder.Entity<Requisition>().Property(r => r.Commentaries).HasColumnName("Comentarios").HasMaxLength(500).IsRequired();
            modelBuilder.Entity<Requisition>().Property(r => r.PriorityId).HasColumnName("C_Prioridad_ID").IsRequired();
            modelBuilder.Entity<Requisition>().Property(r => r.Active).HasColumnName("Activo").IsRequired();

            modelBuilder.Entity<Requisition>()
                .HasRequired(r => r.Supplier)
                .WithMany(p => p.Requisitions)
                .HasForeignKey(fk => fk.SupplierId);

            modelBuilder.Entity<Requisition>()
                .HasRequired(r => r.Department)
                .WithMany(d => d.Requisitions)
                .HasForeignKey(fk => fk.DepartmentId);

            modelBuilder.Entity<Requisition>()
                .HasRequired(r => r.Period)
                .WithMany(p => p.Requisitions)
                .HasForeignKey(fk => fk.PeriodId);

            modelBuilder.Entity<Requisition>()
                .HasRequired(r => r.Status)
                .WithMany(e => e.Requisitions)
                .HasForeignKey(fk => fk.StatusId);

            modelBuilder.Entity<Requisition>()
                .HasRequired(r => r.Priority)
                .WithMany(p => p.Requisitions)
                .HasForeignKey(fk => fk.PriorityId);
        }
    }
}
