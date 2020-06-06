using System.ComponentModel.DataAnnotations;

namespace ContosoUniversity.API.DTOs
{
    public class CoursesDTO
    {
        [Required(ErrorMessage = "The is CouseID requerid ")]
        public int CourseID { get; set; }
        [Required(ErrorMessage = "The is Title requerid ")]
        public string Title { get; set; }
        [Required(ErrorMessage = "The is Credits requerid ")]
        public int Credits { get; set; }

    }
}
