using App.Entities;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;

namespace App.DAL.Mapping
{
    public class PeriodMapper
    {
        public PeriodMapper(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Period>().ToTable("TBL_Period");
            modelBuilder.Entity<Period>().HasKey(period => period.Id);

            modelBuilder.Entity<Period>().Property(period => period.Id).HasColumnName("PeriodID").HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            modelBuilder.Entity<Period>().Property(period => period.Name).HasColumnName("Name").HasMaxLength(60).IsRequired();
            modelBuilder.Entity<Period>().Property(period => period.CreatedBy).HasColumnName("CreatedBy").IsRequired();
            modelBuilder.Entity<Period>().Property(period => period.Created).HasColumnName("Created").IsRequired();
            modelBuilder.Entity<Period>().Property(period => period.UpdatedBy).HasColumnName("UpdatedBy").IsRequired();
            modelBuilder.Entity<Period>().Property(period => period.Updated).HasColumnName("Updated").IsRequired();
        }
    }
}
