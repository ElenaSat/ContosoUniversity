using ContosoUniversity.Data;
using ContosoUniversity.Models;

namespace ContosoUniversity.Repositories.Implements
{
    public class CourseInstructorRepository : GenericRepository<CourseInstructor>, ICourseInstructorRepository
    {
        private SchoolContext schoolContext;
        public CourseInstructorRepository(SchoolContext schoolContext) : base(schoolContext)
        {
            this.schoolContext = schoolContext;
        }
    }
}
