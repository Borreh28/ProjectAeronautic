using App.Entities;
using System.Collections.Generic;
using System.Linq;

namespace App.DAL
{
    public class PeriodRepository
    {
        Context context;

        public PeriodRepository()
        {
            context = new Context();
        }

        public IEnumerable<Period> GetAll()
        {
            return context.Periods.ToList();
        }

        public IEnumerable<Period> GetByName(string name)
        {
            return context.Periods.Where(w => w.Name == name).ToList();
        }
    }
}
