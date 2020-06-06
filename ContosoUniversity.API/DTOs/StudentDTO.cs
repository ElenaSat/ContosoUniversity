using System;
using System.ComponentModel.DataAnnotations;

namespace ContosoUniversity.API.DTOs
{
    public class StudentDTO
    {
        public int ID { get; set; }
        [Required(ErrorMessage ="The is LastName requerid ")]
        public string LastName { get; set; }
        [Required(ErrorMessage = "The is FirstMidName requerid ")]
        public string FirstMidName { get; set; }
        [Required(ErrorMessage = "The is EnrollmentDate requerid ")]
        public DateTime EnrollmentDate { get; set; }
    }
}
