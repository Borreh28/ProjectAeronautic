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

        public IEnumerable<Period> GetAll()
        {
            return db.Periodos.ToList();
        }

        public IEnumerable<Period> GetByName(string name)
        {
            return db.Periodos.Where(w => w.Name == name).ToList();
        }
    }
}
