using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using App.Entities;

namespace App.DAL
{
    public class PeriodoRepository
    {
        Contexto db;

        public PeriodoRepository()
        {
            db = new Contexto();
        }

        public IEnumerable<Periodo> GetAll()
        {
            return db.Periodos.ToList();
        }

        public IEnumerable<Periodo> GetByName(string name)
        {
            return db.Periodos.Where(w => w.Nombre == name).ToList();
        }
    }
}
