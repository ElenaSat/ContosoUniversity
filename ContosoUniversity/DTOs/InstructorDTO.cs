using ContosoUniversity.Models;
using System;
using System.ComponentModel.DataAnnotations;

namespace ContosoUniversity.DTOs
{
    public class InstructorDTO
    {
       // [Key]
        public int ID { get; set; }
        [Required(ErrorMessage = "The is LastName requerid ")]
        [Display(Name = "LastName")]
        public string LastName { get; set; }
        [Required(ErrorMessage = "The is FirstMidName requerid ")]
        [Display(Name = "FirstMidName")]
        public string FirstMidName { get; set; }
        [Required(ErrorMessage = "The is HireDate requerid ")]
        [Display(Name = "HireDate")]
        public DateTime HireDate { get; set; }

        [Required(ErrorMessage = "The is OfficeAssignmentDTO requerid ")]
        [Display(Name = "OfficeAssignmentDTO")]
        public OfficeAssignment OfficeAssignment { get; set; }
    }
}
