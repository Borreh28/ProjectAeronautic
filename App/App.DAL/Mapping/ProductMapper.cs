using App.Entities;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;

namespace App.DAL.Mapping
{
    public class ProductMapper
    {
        public ProductMapper(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>().ToTable("TBL_Product");
            modelBuilder.Entity<Product>().HasKey(product => product.Id);

            modelBuilder.Entity<Product>().Property(product => product.Id).HasColumnName("ProductID").HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            modelBuilder.Entity<Product>().Property(product => product.SupplierId).HasColumnName("SupplierID").IsRequired();
            modelBuilder.Entity<Product>().Property(product => product.CategoryId).HasColumnName("CategoryID").IsRequired();
            modelBuilder.Entity<Product>().Property(product => product.Name).HasColumnName("Name").HasMaxLength(60).IsRequired();
            modelBuilder.Entity<Product>().Property(product => product.UnitPrice).HasColumnName("UnitPrice").HasColumnType("Money").IsRequired();
            modelBuilder.Entity<Product>().Property(product => product.CostPrice).HasColumnName("CostPrice").HasColumnType("Money").IsRequired();
            modelBuilder.Entity<Product>().Property(product => product.BudgetPrice).HasColumnName("BudgetPrice").HasColumnType("Money").IsRequired();
            modelBuilder.Entity<Product>().Property(product => product.UnitPerPack).HasColumnName("UnitPerPack").HasColumnType("SmallInt").IsRequired();
            modelBuilder.Entity<Product>().Property(product => product.UM).HasColumnName("UM").HasMaxLength(60).IsRequired();
            modelBuilder.Entity<Product>().Property(product => product.UnitInStock).HasColumnName("UnitInStock").HasColumnType("SmallInt").IsRequired();
            modelBuilder.Entity<Product>().Property(product => product.UnitOnOrder).HasColumnName("UnitOnOrder").HasColumnType("SmallInt").IsRequired();
            modelBuilder.Entity<Product>().Property(product => product.ReOrderLevel).HasColumnName("ReOrderLevel").HasColumnType("SmallInt").IsRequired();
            modelBuilder.Entity<Product>().Property(product => product.Discontinued).HasColumnName("Discontinued").IsRequired();
            modelBuilder.Entity<Product>().Property(product => product.CreatedBy).HasColumnName("CreatedBy").IsRequired();
            modelBuilder.Entity<Product>().Property(product => product.Created).HasColumnName("Created").IsRequired();
            modelBuilder.Entity<Product>().Property(product => product.UpdatedBy).HasColumnName("UpdatedBy").IsRequired();
            modelBuilder.Entity<Product>().Property(product => product.Updated).HasColumnName("Updated").IsRequired();

            modelBuilder.Entity<Product>()
                .HasRequired(product => product.Supplier)
                .WithMany(supplier => supplier.Products)
                .HasForeignKey(product => product.SupplierId)
                .WillCascadeOnDelete(false);
        }
    }
}
