using App.Entities;
using System.Collections.Generic;
using System.Linq;

namespace App.DAL
{
    public class StatusRepository
    {
        Context context;

        public StatusRepository()
        {
            context = new Context();
        }

        public IEnumerable<Status> GetAll()
        {
            return context.Status.ToList();
        }

        public IEnumerable<Status> GetByName(string name)
        {
            return context.Status.Where(w => w.Name == name).ToList();
        }
    }
}
