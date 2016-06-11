using App.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.DAL
{
    public class ProveedorRepository
    {
        Contexto db;

        public ProveedorRepository()
        {
            db = new Contexto();
        }

        public IEnumerable<Supplier> GetAll()
        {
            return db.Proveedores.ToList();
        }

        public IEnumerable<Supplier> GetByName(string name)
        {
            return db.Proveedores.Where(w => w.Name == name).ToList();
        }
    }
}
