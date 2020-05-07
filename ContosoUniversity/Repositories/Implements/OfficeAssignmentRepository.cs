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

        public new async Task<OfficeAssignment> Insert(OfficeAssignment office)
        {
             var flag = schoolContext.OfficeAssignments.Any(x => x.InstructorID == office.InstructorID);
            if (flag)
                throw new System.Exception("The Instructors have Office");
            schoolContext.OfficeAssignments.Add(office);
            await schoolContext.SaveChangesAsync();
            return office;
        }
    }
}
