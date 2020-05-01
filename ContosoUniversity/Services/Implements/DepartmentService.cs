using ContosoUniversity.Models;

using ContosoUniversity.Repositories;

namespace ContosoUniversity.Services.Implements
{
    public class DepartmentService : GenericService<Department>, IDepartmentService
    {
        private IDepartmentRepository DepartmentRepository;
        public DepartmentService(IDepartmentRepository _departmentRepository) : base(_departmentRepository)
        {
            this.DepartmentRepository = _departmentRepository;
        }
    }
}
