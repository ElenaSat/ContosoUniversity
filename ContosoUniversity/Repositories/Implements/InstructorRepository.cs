using ContosoUniversity.Data;
using ContosoUniversity.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ContosoUniversity.Repositories.Implements
{
    public class InstructorRepository : GenericRepository<Instructor>,IInstructorRepository
    {
        private SchoolContext schoolContext;
        public InstructorRepository(SchoolContext schoolContext) : base(schoolContext)
        {
            this.schoolContext = schoolContext;
        }
        public new async Task<List<Instructor>> GetAll()
        {
            var listInstructor = await schoolContext.Instructors.Include(x => x.OfficeAssignment).ToListAsync();
            return listInstructor;
        }

        public async Task<IEnumerable<Course>> GetCourseByInstructor(int id)
        {
            var listCourses = await schoolContext.CourseInstructors
               .Include(x => x.Instructor)
               .Where(x => x.InstructorID == id)
               .Select(x => x.Course)
               .ToListAsync();

            //var listCourses = await (from _courseInstructor in schoolContext.CourseInstructors
            //                         join _course in schoolContext.Courses on _courseInstructor.CourseID equals _course.CourseID
            //                         where _courseInstructor.InstructorID == id
            //                         select _course).ToListAsync();
            return listCourses;
        }
    }
}
