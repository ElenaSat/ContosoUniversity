using ContosoUniversity.API.Models;
using System;
using System.ComponentModel.DataAnnotations;

namespace ContosoUniversity.API.DTOs
{
    public class InstructorDTO
    {
    
        [Required(ErrorMessage = "The is ID requerid ")]
        public int ID { get; set; }
        [Required(ErrorMessage = "The is LastName requerid ")]
        public string LastName { get; set; }
        [Required(ErrorMessage = "The is FirstMidName requerid ")]
        public string FirstMidName { get; set; }
        [Required(ErrorMessage = "The is HireDate requerid ")]
        public DateTime HireDate { get; set; }
        public OfficeAssignment OfficeAssignment { get; set; }
    }
}
