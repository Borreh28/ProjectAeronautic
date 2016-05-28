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

        public IEnumerable<Proveedor> GetAll()
        {
            return db.Proveedores.ToList();
        }

        public IEnumerable<Proveedor> GetByName(string name)
        {
            return db.Proveedores.Where(w => w.Nombre == name).ToList();
        }
    }
}
