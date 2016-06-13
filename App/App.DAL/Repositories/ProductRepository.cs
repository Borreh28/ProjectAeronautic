using App.Entities;
using System.Collections.Generic;
using System.Linq;

namespace App.DAL
{
    public class ProductRepository
    {
        Context context;

        public ProductRepository()
        {
            context = new Context();
        }

        public IEnumerable<Product> GetAll()
        {
            return context.Products.ToList();
        }

        public IEnumerable<Product> GetAllBySupplierId(int id)
        {
            return context.Products.Where(w => w.SupplierId == id).ToList();
        }

        public IEnumerable<Product> GetByName(string name)
        {
            return context.Products.Where(w => w.Name == name).ToList();
        }
    }
}
