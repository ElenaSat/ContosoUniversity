using ContosoUniversity.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ContosoUniversity.Repositories
{
    public  interface IInstructorRepository : IGenericRepository<Instructor>
    {
     Task<IEnumerable<Course>> GetCourseByInstructor(int id);
    }
}
