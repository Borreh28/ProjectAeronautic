using App.DAL.Mapping;
using App.Entities;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace App.DAL
{
    public class Context : DbContext
    {
        public DbSet<Department> Departments { get; set; }
        public DbSet<Period> Periods { get; set; }
        public DbSet<Priority> Priorities { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Requisition> Requisitions { get; set; }
        public DbSet<RequisitionLine> Lines { get; set; }
        public DbSet<Status> Status { get; set; }
        public DbSet<Supplier> Suppliers { get; set; }

        public Context() : base("DataBaseConnection")
        {
            
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();

            new DepartmentMapper(modelBuilder);
            new PeriodMapper(modelBuilder);
            new PriorityMapper(modelBuilder);
            new ProductMapper(modelBuilder);
            new RequisitionMapper(modelBuilder);
            new RequisitionLineMapper(modelBuilder);
            new StatusMapper(modelBuilder);
            new SupplierMapper(modelBuilder);
        }
    }
}
