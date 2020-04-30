using ContosoUniversity.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ContosoUniversity.Repositories.Implements
{
    public interface IStudentRepository : IGenericRepository<Student> {
        Task<IEnumerable<Course>> GetCourseByStudents(int id);
    }
}
