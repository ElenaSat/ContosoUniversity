using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using ContosoUniversity.DTOs;
using ContosoUniversity.Services;
using Microsoft.AspNetCore.Mvc;

namespace ContosoUniversity.Controllers
{
    public class InstructorsController : Controller
    {
        private  ICourseService _courseService;
        private  IInstructorService _instructorService;
        private  IMapper _mapper;

        public InstructorsController(IInstructorService instructorService, ICourseService courseService, IMapper mapper)
        {
            _instructorService = instructorService;
            _courseService = courseService;
            _mapper = mapper;
        }
        public async Task<IActionResult> Index(int? id, int? courseID)
        {
            if (id != null)
            {
                var dataCourse = await _instructorService.GetCourseByInstructor(id.Value);
                ViewBag.Courses = dataCourse.Select(x => _mapper.Map<CoursesDTO>(x)).ToList();
                var instructor = await _instructorService.GetById(id.Value);
                var instr = _mapper.Map<InstructorDTO>(instructor);
                ViewBag.InstructorD = instr.LastName;
                ViewBag.Idins = id.Value;
                if (courseID != null)
                {
                    var dataCourseE = await _courseService.GetStudentsByCourseEnrollment(courseID.Value);
                   //  ViewBag.CoursesE = dataCourseE.Select(x => _mapper.Map<Enrol>(x)).ToList();
                    ViewBag.CoursesE = dataCourseE;
                }

            }
            var data = await _instructorService.GetAll();
            var listInstructor = data.Select(x => _mapper.Map<InstructorDTO>(x)).ToList();
            return View(listInstructor);
        }
    }
}