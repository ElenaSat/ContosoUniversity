using ContosoUniversity.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ContosoUniversity.Repositories.Implements
{
  public  interface ICourseRepository:IGenericRepository<Course> {
        Task<IEnumerable<Student>> GetStudentsByCourse(int id);
    }
}
