using System;
using System.ComponentModel.DataAnnotations;

namespace ContosoUniversity.API.DTOs
{
    public class StudentDTO
    {
        public int ID { get; set; }
        [Required(ErrorMessage = "The is LastName requerid ")]
        [Display(Name = "LastName")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "The is FirstMidName requerid ")]
        [Display(Name = "First MidName")]
        public string FirstMidName { get; set; }

        [Required(ErrorMessage = "The is EnrollmentDate requerid ")]
        [Display(Name = "EnrollmentDate")]
        public DateTime EnrollmentDate { get; set; }
    }
}
