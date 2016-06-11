using App.Entities;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;

namespace App.DAL.Mapeo
{
    public class RequisicionLineaMapper
    {
        public RequisicionLineaMapper(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<RequisitionLine>().ToTable("TBL_RequisicionLinea");
            modelBuilder.Entity<RequisitionLine>().HasKey(rl => rl.Id);

            modelBuilder.Entity<RequisitionLine>().Property(rl => rl.Id).HasColumnName("RequisicionLinea_ID").HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            modelBuilder.Entity<RequisitionLine>().Property(rl => rl.RequisitionId).HasColumnName("Requisicion_ID").IsRequired();
            modelBuilder.Entity<RequisitionLine>().Property(rl => rl.Line).HasColumnName("Linea").IsRequired();
            modelBuilder.Entity<RequisitionLine>().Property(rl => rl.ProductId).HasColumnName("C_Parte_ID").IsRequired();
            modelBuilder.Entity<RequisitionLine>().Property(rl => rl.Quantity).HasColumnName("Cantidad").IsRequired();
            modelBuilder.Entity<RequisitionLine>().Property(rl => rl.SalePrice).HasColumnName("Precio_Venta").HasColumnType("Money").IsRequired();
            modelBuilder.Entity<RequisitionLine>().Property(rl => rl.Description).HasColumnName("Descipcion").HasMaxLength(500).IsRequired();
            modelBuilder.Entity<RequisitionLine>().Property(rl => rl.CreatedBy).HasColumnName("CreatedBy").IsRequired();
            modelBuilder.Entity<RequisitionLine>().Property(rl => rl.Created).HasColumnName("Created").IsRequired();
            modelBuilder.Entity<RequisitionLine>().Property(rl => rl.UpdatedBy).HasColumnName("UpdatedBy").IsRequired();
            modelBuilder.Entity<RequisitionLine>().Property(rl => rl.Updated).HasColumnName("Updated").IsRequired();

            modelBuilder.Entity<RequisitionLine>()
                .HasRequired(rl => rl.Requisition)
                .WithMany(r => r.Lines)
                .HasForeignKey(fk => fk.RequisitionId);
        }
    }
}
