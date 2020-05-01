using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using ContosoUniversity.Models;
using ContosoUniversity.Services;
using Microsoft.AspNetCore.Mvc;

namespace ContosoUniversity.Controllers
{
    public class EnrollmentsController : Controller
    {
        private IEnrollmentService enrollmentService;
        private IStudentService studentService;
        private ICourseService courseService;
        private readonly IMapper _mapper;

        public EnrollmentsController(IEnrollmentService enrollmentService, IStudentService studentService, ICourseService courseService, IMapper mapper)
        {
            this.enrollmentService = enrollmentService;
            this.courseService = courseService;
            this.studentService = studentService;
            _mapper = mapper;
        }
        public async Task<IActionResult> Index()
        {
            var listEnrollments = await enrollmentService.GetAll();
            return View(listEnrollments);
        }

        public async Task<IActionResult> Create()
        {
            ViewBag.Courses = await courseService.GetAll();
            ViewBag.Students = await studentService.GetAll();
            //List<string> listGrades = new List<string>{ "A", "B", "C", "D", "E", "F" };
            //ViewBag.Grades = listGrades;
            return View();
        }
        [HttpPost]
        public async Task<ActionResult> Create(Enrollment model)
        {
            if (!ModelState.IsValid)
                return View(model);
            await enrollmentService.Insert(model);
            ViewBag.Courses = await courseService.GetAll();
            ViewBag.Students = await studentService.GetAll();
            return RedirectToAction("Index");
        }
    }
}