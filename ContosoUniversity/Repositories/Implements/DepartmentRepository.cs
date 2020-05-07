using ContosoUniversity.Data;
using ContosoUniversity.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ContosoUniversity.Repositories.Implements
{
    public class DepartmentRepository : GenericRepository<Department>, IDepartmentRepository
    {
        private SchoolContext schoolContext;
        public DepartmentRepository(SchoolContext schoolContext) : base(schoolContext)
        {
            this.schoolContext = schoolContext;
        }

        public new async Task<List<Department>> GetAll()
        {
            var listDeparments = await schoolContext.Departments.Include(o => o.Instructor).ToListAsync();
            return listDeparments;
        }
        
        public new async Task<Department> GetById(int id)
        {
          return  await schoolContext.Departments
                .Include(d => d.Instructor)
                .FirstOrDefaultAsync(m => m.DepartmentID == id);
        }
    }
}
