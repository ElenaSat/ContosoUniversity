using ContosoUniversity.API.Models;
using System;
using System.ComponentModel.DataAnnotations;

namespace ContosoUniversity.API.DTOs
{
    public class DepartmentDTO
    {
        [Required(ErrorMessage = "The is Name requerid ")]
        public int DepartmentID { get; set; }
        [Required(ErrorMessage = "The is Name requerid ")]
        public string Name { get; set; }
        [Required(ErrorMessage = "The is Budget requerid ")]
        public decimal Budget { get; set; }
        [Required(ErrorMessage = "The is StartDate requerid ")]
        public DateTime StartDate { get; set; }
        [Required(ErrorMessage = "The is Instructor requerid ")]
        public int InstructorID { get; set; }
        public Instructor Instructor { get; set; }
    }
}
