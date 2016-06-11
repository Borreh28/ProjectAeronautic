using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using App.Entities;

namespace App.DAL
{
    public class PrioridadRepository
    {
        Contexto db;

        public PrioridadRepository()
        {
            db = new Contexto();
        }

        public IEnumerable<Priority> GetAll()
        {
            return db.Prioridad.ToList();
        }

        public IEnumerable<Priority> GetById(string id)
        {
            return db.Prioridad.Where(w => w.Id == id).ToList();
        }
    }
}
