using App.Entities;
using System.Collections.Generic;
using System.Linq;

namespace App.DAL
{
    public class PriorityRepository
    {
        Context context;

        public PriorityRepository()
        {
            context = new Context();
        }

        public IEnumerable<Priority> GetAll()
        {
            return context.Priorities.ToList();
        }

        public IEnumerable<Priority> GetByName(string name)
        {
            return context.Priorities.Where(w => w.Name == name).ToList();
        }
    }
}
