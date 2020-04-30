using ContosoUniversity.Models;
using ContosoUniversity.Repositories.Implements;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ContosoUniversity.Services.Implements
{
    public class StudentService : GenericService<Student>, IStudentService
    {
        private IStudentRepository StudentRepository;
        public StudentService(IStudentRepository _studentRepository) : base(_studentRepository)
        {
            this.StudentRepository = _studentRepository;
        }
        public async Task<IEnumerable<Course>> GetCourseByStudents(int id)
        {
            return await StudentRepository.GetCourseByStudents(id);
        }
    }
}
