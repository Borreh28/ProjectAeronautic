using App.Entities;
using System.Collections.Generic;
using System.Linq;

namespace App.DAL
{
    public class SupplierRepository
    {
        Context context;

        public SupplierRepository()
        {
            context = new Context();
        }

        public IEnumerable<Supplier> GetAll()
        {
            return context.Suppliers.ToList();
        }

        public IEnumerable<Supplier> GetByName(string name)
        {
            return context.Suppliers.Where(w => w.Name == name).ToList();
        }
    }
}
