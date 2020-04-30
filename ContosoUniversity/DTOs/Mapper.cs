using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ContosoUniversity.DTOs;
using ContosoUniversity.Models;

namespace ContosoUniversity.DTOs
{
    public class Mapper: Profile
    {
        public Mapper()
        {
            CreateMap<StudentDTO, Student>();
            CreateMap<Student,StudentDTO>();

            CreateMap<CoursesDTO, Course>();
            CreateMap<Course, CoursesDTO>();
        }
    }
}
