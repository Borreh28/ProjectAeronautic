using App.Entities;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;

namespace App.DAL.Mapping
{
    public class RequisitionMapper
    {
        public RequisitionMapper(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Requisition>().ToTable("TBL_Requisition");
            modelBuilder.Entity<Requisition>().HasKey(requisition => requisition.Id);

            modelBuilder.Entity<Requisition>().Property(requisition => requisition.Id).HasColumnName("RequisitionID").HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            modelBuilder.Entity<Requisition>().Property(requisition => requisition.PeriodId).HasColumnName("PeriodID").IsRequired();
            modelBuilder.Entity<Requisition>().Property(requisition => requisition.DepartmentId).HasColumnName("DepartmentID").IsRequired();
            modelBuilder.Entity<Requisition>().Property(requisition => requisition.SupplierId).HasColumnName("SupplierID").IsRequired();
            modelBuilder.Entity<Requisition>().Property(requisition => requisition.StatusId).HasColumnName("StatusID").IsRequired();
            modelBuilder.Entity<Requisition>().Property(requisition => requisition.PriorityId).HasColumnName("PriorityID").IsRequired();
            modelBuilder.Entity<Requisition>().Property(requisition => requisition.Active).HasColumnName("Active").IsRequired();
            modelBuilder.Entity<Requisition>().Property(requisition => requisition.TotalLines).HasColumnName("TotalLines").IsRequired();
            modelBuilder.Entity<Requisition>().Property(requisition => requisition.SubTotal).HasColumnName("SubTotal").HasColumnType("Money").IsRequired();
            modelBuilder.Entity<Requisition>().Property(requisition => requisition.Interest).HasColumnName("Interest").HasColumnType("Money").IsRequired();
            modelBuilder.Entity<Requisition>().Property(requisition => requisition.Total).HasColumnName("Total").HasColumnType("Money").IsRequired();
            modelBuilder.Entity<Requisition>().Property(requisition => requisition.RequisitionDate).HasColumnName("RequisitionDate").IsRequired();
            modelBuilder.Entity<Requisition>().Property(requisition => requisition.DeliveryDate).HasColumnName("DeliveryDate").IsRequired();
            modelBuilder.Entity<Requisition>().Property(requisition => requisition.Description).HasColumnName("Description").HasMaxLength(500).IsRequired();
            modelBuilder.Entity<Requisition>().Property(requisition => requisition.Commentaries).HasColumnName("Commentaries").HasMaxLength(500).IsRequired();
            modelBuilder.Entity<Requisition>().Property(requisition => requisition.CreatedBy).HasColumnName("CreatedBy").IsRequired();
            modelBuilder.Entity<Requisition>().Property(requisition => requisition.Created).HasColumnName("Created").IsRequired();
            modelBuilder.Entity<Requisition>().Property(requisition => requisition.UpdatedBy).HasColumnName("UpdatedBy").IsRequired();
            modelBuilder.Entity<Requisition>().Property(requisition => requisition.Updated).HasColumnName("Updated").IsRequired();

            modelBuilder.Entity<Requisition>()
                .HasRequired(requisition => requisition.Supplier)
                .WithMany(supplier => supplier.Requisitions)
                .HasForeignKey(requisition => requisition.SupplierId);

            modelBuilder.Entity<Requisition>()
                .HasRequired(requisition => requisition.Department)
                .WithMany(department => department.Requisitions)
                .HasForeignKey(requisition => requisition.DepartmentId);

            modelBuilder.Entity<Requisition>()
                .HasRequired(requisition => requisition.Period)
                .WithMany(period => period.Requisitions)
                .HasForeignKey(requisition => requisition.PeriodId);

            modelBuilder.Entity<Requisition>()
                .HasRequired(requisition => requisition.Status)
                .WithMany(status => status.Requisitions)
                .HasForeignKey(requisition => requisition.StatusId);

            modelBuilder.Entity<Requisition>()
                .HasRequired(requisition => requisition.Priority)
                .WithMany(priority => priority.Requisitions)
                .HasForeignKey(requisition => requisition.PriorityId);
        }
    }
}
