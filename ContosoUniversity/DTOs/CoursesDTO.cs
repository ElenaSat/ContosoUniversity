using System.ComponentModel.DataAnnotations;

namespace ContosoUniversity.DTOs
{
    public class CoursesDTO
    {
        public int CourseID { get; set; }
        [Required(ErrorMessage = "The is Title requerid ")]
        [Display(Name = "Title")]
        public string Title { get; set; }
        [Required(ErrorMessage = "The is Credits requerid ")]
        [Display(Name = "Credits")]
        public int Credits { get; set; }

    }
}
