using ContosoUniversity.Models;
using ContosoUniversity.Repositories;
using ContosoUniversity.Repositories.Implements;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ContosoUniversity.Services.Implements
{
    public class InstructorService : GenericService<Instructor>, IInstructorService
    {
        private IInstructorRepository IinstructorRepository;
        public InstructorService(IInstructorRepository _instructorRepository) : base(_instructorRepository)
        {
            this.IinstructorRepository = _instructorRepository;
        }

        public async Task<IEnumerable<Course>> GetCourseByInstructor(int id)
        {
            return await IinstructorRepository.GetCourseByInstructor(id);
        }
    }
}
