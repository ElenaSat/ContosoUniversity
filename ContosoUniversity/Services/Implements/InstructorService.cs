using ContosoUniversity.Data;
using ContosoUniversity.Models;
using ContosoUniversity.Repositories;

namespace ContosoUniversity.Services.Implements
{
    public class InstructorService : GenericService<Instructor>, IInstructorService
    {
        private IInstructorRepository IinstructorRepository;
        public InstructorService(IInstructorRepository _instructorRepository) : base(_instructorRepository)
        {
            this.IinstructorRepository = _instructorRepository;
        }
    }
}
