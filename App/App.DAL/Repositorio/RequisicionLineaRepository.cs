using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using App.Entities;
using System.Data.Entity;

namespace App.DAL
{
    public class RequisicionLineaRepository
    {
        Contexto db;

        public RequisicionLineaRepository()
        {
            db = new Contexto();
        }

        public IEnumerable<RequisitionLine> GetAll()
        {
            return db.Lineas.ToList();
        }

        public IEnumerable<RequisitionLine> GetByIdRequisicion(int id)
        {
            return db.Lineas.Where(w => w.RequisicionId == id).ToList();
        }

        public void Add(RequisitionLine data)
        {
            db.Lineas.Add(data);
            db.SaveChanges();
        }

        public void Update(RequisitionLine data)
        {
            db.Entry(data).State = EntityState.Modified;
            db.SaveChanges();
        }

        public void Delete(int id)
        {
            RequisitionLine data = db.Lineas.Find(id);
            db.Lineas.Remove(data);
            db.SaveChanges();
        }
    }
}
