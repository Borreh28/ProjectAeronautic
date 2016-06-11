using App.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.DAL
{
    public class DepartamentoRepository
    {
        Contexto db;

        public DepartamentoRepository()
        {
            db = new Contexto();
        }

        public IEnumerable<Department> GetAll()
        {
            return db.Departamentos.ToList();
        }

        public IEnumerable<Department> GetByName(string name)
        {
            return db.Departamentos.Where(w => w.Name == name).ToList();
        }
    }
}
