using App.Entities;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace App.DAL.Repositories
{
    public class RequisitionRuleRepository
    {
        Context context;

        public RequisitionRuleRepository()
        {
            context = new Context();
        }

        public IEnumerable<RequisitionRule> GetAll()
        {
            return context.Rules.ToList();
        }

        public IEnumerable<RequisitionRule> GetAllByRequisitionId(int id)
        {
            return context.Rules.Where(w => w.RequisitionId == id).ToList();
        }

        public void Add(RequisitionRule data)
        {
            context.Rules.Add(data);
            context.SaveChanges();
        }

        public void Update(RequisitionRule data)
        {
            context.Entry(data).State = EntityState.Modified;
            context.SaveChanges();
        }

        public void Delete(int id)
        {
            RequisitionRule data = context.Rules.Find(id);
            context.Rules.Remove(data);
            context.SaveChanges();
        }
    }
}
