using ContosoUniversity.Data;
using ContosoUniversity.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ContosoUniversity.Repositories.Implements
{
    public class StudentRepository : GenericRepository<Student>, IStudentRepository
    {
        private SchoolContext schoolContext;
        public StudentRepository(SchoolContext schoolContext) : base(schoolContext)
        {
            this.schoolContext = schoolContext;
        }
        public async Task<IEnumerable<Course>> GetCourseByStudents(int id)
        {
          
            var listCourses = await ( from enrollment in schoolContext.Enrollments
                                         join student in schoolContext.Students on enrollment.StudentID equals student.ID
                                         join cursos in schoolContext.Courses on enrollment.CourseID equals cursos.CourseID
                                         where enrollment.StudentID==id                 
                                         select cursos).ToListAsync();
            return listCourses;


        }
        public new async Task Delete(int id)
        {
            var entity = await GetById(id);

            if (entity == null)
                throw new System.Exception("The entity is null");
            var flag = schoolContext.Enrollments.Any(x => x.StudentID == id);
            if (flag)
                throw new System.Exception("The course have Students");

            schoolContext.Students.Remove(entity);
            await schoolContext.SaveChangesAsync();
        }
    }
}
