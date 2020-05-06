using ContosoUniversity.Data;
using ContosoUniversity.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ContosoUniversity.Repositories.Implements
{
    public class OfficeAssignmentRepository : GenericRepository<OfficeAssignment>, IOfficeAssignmentRepository
    {
        private SchoolContext schoolContext;
        public OfficeAssignmentRepository(SchoolContext schoolContext) : base(schoolContext)
        {
            this.schoolContext = schoolContext;
        }

        public new async Task<List<OfficeAssignment>> GetAll()
        {
            var listOfficeA = await schoolContext.OfficeAssignments.Include(o => o.Instructor).ToListAsync();   
            return  listOfficeA;
        }

        //public new async Task Delete(int id)
        //{
        //    var entity = await GetById(id);

        //    if (entity == null)
        //        throw new System.Exception("The entity is null");
        //    var flag = schoolContext.OfficeAssignments.Any(x => x.InstructorID == id);
        //    if (flag)
        //        throw new System.Exception("The Office have Instructors");

        //    schoolContext.OfficeAssignments.Remove(entity);
        //    await schoolContext.SaveChangesAsync();
        //}
    }
}
