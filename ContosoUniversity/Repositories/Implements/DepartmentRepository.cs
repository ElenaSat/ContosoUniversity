using ContosoUniversity.Data;
using ContosoUniversity.Models;

namespace ContosoUniversity.Repositories.Implements
{
    public class DepartmentRepository : GenericRepository<Department>, IDepartmentRepository
    {
        private SchoolContext schoolContext;
        public DepartmentRepository(SchoolContext schoolContext) : base(schoolContext)
        {
            this.schoolContext = schoolContext;
        }
    }
}
