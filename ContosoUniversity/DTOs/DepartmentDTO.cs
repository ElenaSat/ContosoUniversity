using ContosoUniversity.Models;
using System;
using System.ComponentModel.DataAnnotations;

namespace ContosoUniversity.DTOs
{
    public class DepartmentDTO
    {
        public int DepartmentID { get; set; }
        [Required(ErrorMessage = "The is Name requerid ")]
        [Display(Name = "Name")]
        public string Name { get; set; }
        [Required(ErrorMessage = "The is Budget requerid ")]
        [Display(Name = "Budget")]
        public decimal Budget { get; set; }
        [Required(ErrorMessage = "The is StartDate requerid ")]
        [Display(Name = "StartDate")]
        public DateTime StartDate { get; set; }
        [Required(ErrorMessage = "The is Instructor requerid ")]
        [Display(Name = "Instructor")]
        public int InstructorID { get; set; }
        public Instructor Instructor { get; set; }
    }
}
