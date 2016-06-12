using App.Entities;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace App.DAL
{
    public class RequisitionRepository
    {
        Context context;

        public RequisitionRepository()
        {
            context = new Context();
        }

        public IEnumerable<Requisition> GetAll()
        {
            return context.Requisitions.ToList();
        }

        public IEnumerable<Requisition> GetAllActive()
        {
            return context.Requisitions.Where(w => w.Active == true).ToList();
        }

        public IEnumerable<Requisition> GetById(int id)
        {
            return context.Requisitions.Where(w => w.Id == id).ToList();
        }

        public void Add(Requisition data)
        {
            context.Requisitions.Add(data);
            context.SaveChanges();
        }

        public void Update(Requisition data)
        {
            context.Entry(data).State = EntityState.Modified;
            context.SaveChanges();
        }

        public void Delete(int id)
        {
            Requisition data = context.Requisitions.Find(id);
            context.Requisitions.Remove(data);
            context.SaveChanges();
        }
    }
}
