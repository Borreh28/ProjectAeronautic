using App.Entities;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;

namespace App.DAL.Mapeo
{
    public class PeriodoMapper
    {
        public PeriodoMapper(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Periodo>().ToTable("TBL_Periodo");
            modelBuilder.Entity<Periodo>().HasKey(p => p.Id);

            modelBuilder.Entity<Periodo>().Property(p => p.Id).HasColumnName("Periodo_ID").HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            modelBuilder.Entity<Periodo>().Property(p => p.Nombre).HasColumnName("Nombre").HasMaxLength(60).IsRequired();
        }
    }
}
