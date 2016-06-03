using App.Entities;
using System.Data.Entity;

namespace App.DAL.Mapeo
{
    public class PrioridadMapper
    {
        public PrioridadMapper(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Prioridad>().ToTable("TBL_Prioridad");
            modelBuilder.Entity<Prioridad>().HasKey(p => p.Id);

            modelBuilder.Entity<Prioridad>().Property(p => p.Id).HasColumnName("Prioridad_ID").HasMaxLength(60).IsRequired();
        }
    }
}
