using App.Entities;
using System.Data.Entity;

namespace App.DAL.Mapeo
{
    public class PrioridadMapper
    {
        public PrioridadMapper(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Priority>().ToTable("TBL_Prioridad");
            modelBuilder.Entity<Priority>().HasKey(p => p.Id);

            modelBuilder.Entity<Priority>().Property(p => p.Id).HasColumnName("Prioridad_ID").HasMaxLength(60).IsRequired();
        }
    }
}
