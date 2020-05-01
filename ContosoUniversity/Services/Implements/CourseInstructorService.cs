using ContosoUniversity.Models;
using ContosoUniversity.Repositories;

namespace ContosoUniversity.Services.Implements
{
    public class CourseInstructorService : GenericService<CourseInstructor>, ICourseInstructorService
    {
        private ICourseInstructorRepository CourseInstructorRepository;
        public CourseInstructorService(ICourseInstructorRepository _courseInstructorRepository) : base(_courseInstructorRepository)
        {
            this.CourseInstructorRepository = _courseInstructorRepository;
        }
    }
}
