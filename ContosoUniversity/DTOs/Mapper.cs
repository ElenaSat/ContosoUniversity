using AutoMapper;
using ContosoUniversity.Models;

namespace ContosoUniversity.DTOs
{
    public class Mapper: Profile
    {
        public Mapper()
        {  
            CreateMap<CoursesDTO, Course>();
            CreateMap<Course, CoursesDTO>();

            CreateMap<DepartmentDTO, Department>();
            CreateMap<Department, DepartmentDTO>();

            CreateMap<InstructorDTO, Instructor>();
            CreateMap<Instructor, InstructorDTO>();

            CreateMap<OfficeAssignmentDTO, OfficeAssignment>();
            CreateMap<OfficeAssignment, OfficeAssignmentDTO>();

            CreateMap<StudentDTO, Student>();
            CreateMap<Student, StudentDTO>();
        }
    }
}
