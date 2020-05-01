using ContosoUniversity.Models;
using ContosoUniversity.Repositories;
namespace ContosoUniversity.Services.Implements
{
    public class OfficeAssignmentService : GenericService<OfficeAssignment>, IOfficeAssignmentService
    {
        private IOfficeAssignmentRepository OfficeAssignmentRepository;
        public OfficeAssignmentService(IOfficeAssignmentRepository _officeAssignmentRepository) : base(_officeAssignmentRepository)
        {
            this.OfficeAssignmentRepository = _officeAssignmentRepository;
        }
    }
}
