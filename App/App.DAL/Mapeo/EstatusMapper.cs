using App.Entities;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;

namespace App.DAL.Mapeo
{
    public class EstatusMapper
    {
        public EstatusMapper(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Status>().ToTable("TBL_Estatus");
            modelBuilder.Entity<Status>().HasKey(e => e.Id);

            modelBuilder.Entity<Status>().Property(e => e.Id).HasColumnName("Estatus_ID").HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            modelBuilder.Entity<Status>().Property(e => e.Name).HasColumnName("Nombre").HasMaxLength(60).IsRequired();
        }
    }
}
