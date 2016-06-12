using App.Entities;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;

namespace App.DAL.Mapping
{
    public class RequisitionLineMapper
    {
        public RequisitionLineMapper(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<RequisitionLine>().ToTable("TBL_RequisitionLine");
            modelBuilder.Entity<RequisitionLine>().HasKey(line => line.Id);

            modelBuilder.Entity<RequisitionLine>().Property(line => line.Id).HasColumnName("RequisitionLineID").HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            modelBuilder.Entity<RequisitionLine>().Property(line => line.RequisitionId).HasColumnName("RequisitionID").IsRequired();
            modelBuilder.Entity<RequisitionLine>().Property(line => line.Line).HasColumnName("Line").IsRequired();
            modelBuilder.Entity<RequisitionLine>().Property(line => line.ProductId).HasColumnName("ProductID").IsRequired();
            modelBuilder.Entity<RequisitionLine>().Property(line => line.Quantity).HasColumnName("Quantity").IsRequired();
            modelBuilder.Entity<RequisitionLine>().Property(line => line.SalePrice).HasColumnName("SalePrice").HasColumnType("Money").IsRequired();
            modelBuilder.Entity<RequisitionLine>().Property(line => line.Description).HasColumnName("Description").HasMaxLength(500).IsRequired();
            modelBuilder.Entity<RequisitionLine>().Property(line => line.CreatedBy).HasColumnName("CreatedBy").IsRequired();
            modelBuilder.Entity<RequisitionLine>().Property(line => line.Created).HasColumnName("Created").IsRequired();
            modelBuilder.Entity<RequisitionLine>().Property(line => line.UpdatedBy).HasColumnName("UpdatedBy").IsRequired();
            modelBuilder.Entity<RequisitionLine>().Property(line => line.Updated).HasColumnName("Updated").IsRequired();

            modelBuilder.Entity<RequisitionLine>()
                .HasRequired(line => line.Requisition)
                .WithMany(requisition => requisition.Lines)
                .HasForeignKey(line => line.RequisitionId);

            modelBuilder.Entity<RequisitionLine>()
                .HasRequired(line => line.Product)
                .WithMany(product => product.Lines)
                .HasForeignKey(line => line.ProductId);
        }
    }
}
