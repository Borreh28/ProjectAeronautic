using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using App.Entities;
using System.Data.Entity;

namespace App.DAL
{
    public class RequisicionRepository
    {
        Contexto db;

        public RequisicionRepository()
        {
            db = new Contexto();
        }

        public IEnumerable<Requisition> GetAll()
        {
            return db.Requisiciones.ToList();
        }

        public IEnumerable<Requisition> GetAllActive()
        {
            return db.Requisiciones.Where(w => w.Active == true).ToList();
        }

        public IEnumerable<Requisition> GetById(int id)
        {
            return db.Requisiciones.Where(w => w.Id == id).ToList();
        }

        public void Add(Requisition data)
        {
            db.Requisiciones.Add(data);
            db.SaveChanges();
        }

        public void Update(Requisition data)
        {
            db.Entry(data).State = EntityState.Modified;
            db.SaveChanges();
        }

        public void Delete(int id)
        {
            Requisition data = db.Requisiciones.Find(id);
            db.Requisiciones.Remove(data);
            db.SaveChanges();
        }
    }
}
