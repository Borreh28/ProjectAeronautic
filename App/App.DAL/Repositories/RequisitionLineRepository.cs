using App.Entities;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace App.DAL
{
    public class RequisitionLineRepository
    {
        Context context;

        public RequisitionLineRepository()
        {
            context = new Context();
        }

        public IEnumerable<RequisitionLine> GetAll()
        {
            return context.Lines.ToList();
        }

        public IEnumerable<RequisitionLine> GetByRequisitionId(int id)
        {
            return context.Lines.Where(w => w.RequisitionId == id).ToList();
        }

        public void Add(RequisitionLine data)
        {
            context.Lines.Add(data);
            context.SaveChanges();
        }

        public void Update(RequisitionLine data)
        {
            context.Entry(data).State = EntityState.Modified;
            context.SaveChanges();
        }

        public void Delete(int id)
        {
            RequisitionLine data = context.Lines.Find(id);
            context.Lines.Remove(data);
            context.SaveChanges();
        }
    }
}
