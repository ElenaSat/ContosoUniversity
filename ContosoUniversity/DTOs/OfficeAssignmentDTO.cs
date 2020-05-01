using System.ComponentModel.DataAnnotations;

namespace ContosoUniversity.DTOs
{
    public class OfficeAssignmentDTO
    {
        public int InstructorID { get; set; }
        [Required(ErrorMessage = "The is Location requerid ")]
        [Display(Name = "Location")]
        public string Location { get; set; }
    }
}
