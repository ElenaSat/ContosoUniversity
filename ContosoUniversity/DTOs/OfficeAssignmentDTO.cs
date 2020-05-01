using ContosoUniversity.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ContosoUniversity.DTOs
{
    public class OfficeAssignmentDTO
    {
       [Key]
        [ForeignKey("Instructor")]
        public int InstructorID { get; set; }
        [Required(ErrorMessage = "The is Office requerid ")]
        [Display(Name = "Office")]
        public string Location { get; set; }
       public virtual Instructor Instructor { get; set; }
    }
}
