using App.Entities;
using System.Data.Entity;

namespace App.DAL.Mapeo
{
    public class RequisicionLineaMapper
    {
        public RequisicionLineaMapper(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<RequisicionLinea>().ToTable("TBL_RequisicionLinea");
            modelBuilder.Entity<RequisicionLinea>().HasKey(rl => rl.Id);

            modelBuilder.Entity<RequisicionLinea>().Property(rl => rl.Id).HasColumnName("RequisicionLinea_ID").HasMaxLength(10).IsRequired();
            modelBuilder.Entity<RequisicionLinea>().Property(rl => rl.RequisicionId).HasColumnName("Requisicion_ID").IsRequired();
            modelBuilder.Entity<RequisicionLinea>().Property(rl => rl.Linea).HasColumnName("Linea").IsRequired();
            modelBuilder.Entity<RequisicionLinea>().Property(rl => rl.ParteId).HasColumnName("C_Parte_ID").IsRequired();
            modelBuilder.Entity<RequisicionLinea>().Property(rl => rl.Cantidad).HasColumnName("Cantidad").IsRequired();
            modelBuilder.Entity<RequisicionLinea>().Property(rl => rl.PrecioVenta).HasColumnName("Precio_Venta").HasColumnType("Money").IsRequired();
            modelBuilder.Entity<RequisicionLinea>().Property(rl => rl.Descripcion).HasColumnName("Descipcion").HasMaxLength(500).IsRequired();
            modelBuilder.Entity<RequisicionLinea>().Property(rl => rl.CreadoPor).HasColumnName("CreatedBy").IsRequired();
            modelBuilder.Entity<RequisicionLinea>().Property(rl => rl.Creado).HasColumnName("Created").IsRequired();
            modelBuilder.Entity<RequisicionLinea>().Property(rl => rl.ActualizadoPor).HasColumnName("UpdatedBy").IsRequired();
            modelBuilder.Entity<RequisicionLinea>().Property(rl => rl.Actualizado).HasColumnName("Updated").IsRequired();

            modelBuilder.Entity<RequisicionLinea>()
                .HasRequired(rl => rl.Requisicion)
                .WithMany(r => r.Lineas)
                .HasForeignKey(fk => fk.RequisicionId);
        }
    }
}
