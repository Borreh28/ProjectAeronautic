using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using App.Entities;

namespace App.DAL
{
    public class EstatusRepository
    {
        Contexto db;

        public EstatusRepository()
        {
            db = new Contexto();
        }

        public IEnumerable<Status> GetAll()
        {
            return db.Estatus.ToList();
        }

        public IEnumerable<Status> GetByName(string name)
        {
            return db.Estatus.Where(w => w.Name == name).ToList();
        }
    }
}
