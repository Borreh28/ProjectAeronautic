using App.Entities;
using System.Collections.Generic;
using System.Linq;

namespace App.DAL
{
    public class DepartmentRepository
    {
        Context context;

        public DepartmentRepository()
        {
            context = new Context();
        }

        public IEnumerable<Department> GetAll()
        {
            return context.Departments.ToList();
        }

        public IEnumerable<Department> GetByName(string name)
        {
            return context.Departments.Where(w => w.Name == name).ToList();
        }
    }
}
