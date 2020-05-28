using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ContosoUniversity.API.Models
{
    public class Student
    {
        public int ID { get; set; }
        public string LastName { get; set; }
        public string FirstMidName { get; set; }
        public DateTime EnrollmentDate { get; set; }

        public string FullName {
            get { return string.Format("{0} {1}",LastName, FirstMidName); }
        }
        public ICollection<Enrollment> Enrollments { get; set; }
    }
}