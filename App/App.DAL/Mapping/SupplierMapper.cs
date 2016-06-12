using App.Entities;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;

namespace App.DAL.Mapping
{
    public class SupplierMapper
    {
        public SupplierMapper(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Supplier>().ToTable("TBL_Supplier");
            modelBuilder.Entity<Supplier>().HasKey(supplier => supplier.Id);

            modelBuilder.Entity<Supplier>().Property(supplier => supplier.Id).HasColumnName("SupplierID").HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            modelBuilder.Entity<Supplier>().Property(supplier => supplier.Active).HasColumnName("Active").IsRequired();
            modelBuilder.Entity<Supplier>().Property(supplier => supplier.Name).HasColumnName("Name").HasMaxLength(60).IsRequired();
            modelBuilder.Entity<Supplier>().Property(supplier => supplier.CreatedBy).HasColumnName("CreatedBy").IsRequired();
            modelBuilder.Entity<Supplier>().Property(supplier => supplier.Created).HasColumnName("Created").IsRequired();
            modelBuilder.Entity<Supplier>().Property(supplier => supplier.UpdatedBy).HasColumnName("UpdatedBy").IsRequired();
            modelBuilder.Entity<Supplier>().Property(supplier => supplier.Updated).HasColumnName("Updated").IsRequired();
        }
    }
}
