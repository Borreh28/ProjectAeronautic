using App.Entities;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;

namespace App.DAL.Mapeo
{
    public class EstatusMapper
    {
        public EstatusMapper(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Estatus>().ToTable("TBL_Estatus");
            modelBuilder.Entity<Estatus>().HasKey(e => e.Id);

            modelBuilder.Entity<Estatus>().Property(e => e.Id).HasColumnName("Estatus_ID").HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            modelBuilder.Entity<Estatus>().Property(e => e.Nombre).HasColumnName("Nombre").HasMaxLength(60).IsRequired();
        }
    }
}
