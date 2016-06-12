using App.Entities;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;

namespace App.DAL.Mapping
{
    public class DepartmentMapper
    {
        public DepartmentMapper(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Department>().ToTable("TBL_Department");
            modelBuilder.Entity<Department>().HasKey(department => department.Id);

            modelBuilder.Entity<Department>().Property(department => department.Id).HasColumnName("DepartmentID").HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            modelBuilder.Entity<Department>().Property(department => department.BuildingId).HasColumnName("BuildingID").IsRequired();
            modelBuilder.Entity<Department>().Property(department => department.Active).HasColumnName("Active").IsRequired();
            modelBuilder.Entity<Department>().Property(department => department.Name).HasColumnName("Name").HasMaxLength(60).IsRequired();
            modelBuilder.Entity<Department>().Property(department => department.CreatedBy).HasColumnName("CreatedBy").IsRequired();
            modelBuilder.Entity<Department>().Property(department => department.Created).HasColumnName("Created").IsRequired();
            modelBuilder.Entity<Department>().Property(department => department.UpdatedBy).HasColumnName("UpdatedBy").IsRequired();
            modelBuilder.Entity<Department>().Property(department => department.Updated).HasColumnName("Updated").IsRequired();
        }
    }
}
