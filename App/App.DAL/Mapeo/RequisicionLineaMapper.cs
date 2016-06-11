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
            modelBuilder.Entity<RequisitionLine>().Property(rl => rl.RequisicionId).HasColumnName("Requisicion_ID").IsRequired();
            modelBuilder.Entity<RequisitionLine>().Property(rl => rl.Linea).HasColumnName("Linea").IsRequired();
            modelBuilder.Entity<RequisitionLine>().Property(rl => rl.ParteId).HasColumnName("C_Parte_ID").IsRequired();
            modelBuilder.Entity<RequisitionLine>().Property(rl => rl.Cantidad).HasColumnName("Cantidad").IsRequired();
            modelBuilder.Entity<RequisitionLine>().Property(rl => rl.PrecioVenta).HasColumnName("Precio_Venta").HasColumnType("Money").IsRequired();
            modelBuilder.Entity<RequisitionLine>().Property(rl => rl.Descripcion).HasColumnName("Descipcion").HasMaxLength(500).IsRequired();
            modelBuilder.Entity<RequisitionLine>().Property(rl => rl.CreadoPor).HasColumnName("CreatedBy").IsRequired();
            modelBuilder.Entity<RequisitionLine>().Property(rl => rl.Creado).HasColumnName("Created").IsRequired();
            modelBuilder.Entity<RequisitionLine>().Property(rl => rl.ActualizadoPor).HasColumnName("UpdatedBy").IsRequired();
            modelBuilder.Entity<RequisitionLine>().Property(rl => rl.Actualizado).HasColumnName("Updated").IsRequired();

            modelBuilder.Entity<RequisitionLine>()
                .HasRequired(rl => rl.Requisicion)
                .WithMany(r => r.Lineas)
                .HasForeignKey(fk => fk.RequisicionId);
        }
    }
}
