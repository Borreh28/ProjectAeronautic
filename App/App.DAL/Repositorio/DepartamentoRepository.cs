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

        public IEnumerable<Departamento> GetAll()
        {
            return db.Departamentos.ToList();
        }

        public IEnumerable<Departamento> GetByName(string name)
        {
            return db.Departamentos.Where(w => w.Nombre == name).ToList();
        }
    }
}
