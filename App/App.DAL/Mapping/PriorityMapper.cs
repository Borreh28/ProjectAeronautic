using App.Entities;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;

namespace App.DAL.Mapping
{
    public class PriorityMapper
    {
        public PriorityMapper(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Priority>().ToTable("TBL_Priority");
            modelBuilder.Entity<Priority>().HasKey(priority => priority.Id);

            modelBuilder.Entity<Priority>().Property(priority => priority.Id).HasColumnName("PriorityID").HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            modelBuilder.Entity<Priority>().Property(priority => priority.Name).HasColumnName("Name").HasMaxLength(60).IsRequired();
            modelBuilder.Entity<Priority>().Property(priority => priority.CreatedBy).HasColumnName("CreatedBy").IsRequired();
            modelBuilder.Entity<Priority>().Property(priority => priority.Created).HasColumnName("Created").IsRequired();
            modelBuilder.Entity<Priority>().Property(priority => priority.UpdatedBy).HasColumnName("UpdatedBy").IsRequired();
            modelBuilder.Entity<Priority>().Property(priority => priority.Updated).HasColumnName("Updated").IsRequired();
        }
    }
}
