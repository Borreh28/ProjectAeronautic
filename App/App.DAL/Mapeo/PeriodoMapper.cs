using App.Entities;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;

namespace App.DAL.Mapeo
{
    public class PeriodoMapper
    {
        public PeriodoMapper(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Period>().ToTable("TBL_Periodo");
            modelBuilder.Entity<Period>().HasKey(p => p.Id);

            modelBuilder.Entity<Period>().Property(p => p.Id).HasColumnName("Periodo_ID").HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            modelBuilder.Entity<Period>().Property(p => p.Name).HasColumnName("Nombre").HasMaxLength(60).IsRequired();
        }
    }
}
