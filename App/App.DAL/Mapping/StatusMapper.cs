using App.Entities;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;

namespace App.DAL.Mapping
{
    public class StatusMapper
    {
        public StatusMapper(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Status>().ToTable("TBL_Status");
            modelBuilder.Entity<Status>().HasKey(status => status.Id);

            modelBuilder.Entity<Status>().Property(status => status.Id).HasColumnName("StatusID").HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            modelBuilder.Entity<Status>().Property(status => status.Name).HasColumnName("Name").HasMaxLength(60).IsRequired();
            modelBuilder.Entity<Status>().Property(status => status.CreatedBy).HasColumnName("CreatedBy").IsRequired();
            modelBuilder.Entity<Status>().Property(status => status.Created).HasColumnName("Created").IsRequired();
            modelBuilder.Entity<Status>().Property(status => status.UpdatedBy).HasColumnName("UpdatedBy").IsRequired();
            modelBuilder.Entity<Status>().Property(status => status.Updated).HasColumnName("Updated").IsRequired();
        }
    }
}
