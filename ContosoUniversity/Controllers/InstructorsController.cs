using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using ContosoUniversity.DTOs;
using ContosoUniversity.Models;
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

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(InstructorDTO instructorDTO)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var instructor = _mapper.Map<Instructor>(instructorDTO);
                    var data = await _instructorService.Insert(instructor);
                    return RedirectToAction(nameof(Index));
                }

                return View(instructorDTO);
            }
            catch (Exception ex)
           {
                ViewBag.Message = ex.Message;
                ViewBag.Type = "danger";
                return View(instructorDTO);
            }

        }
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var instructor = await _instructorService.GetById(id.Value);
            if (instructor == null)
            {
                return NotFound();
            }
            var instructorDTO = _mapper.Map<InstructorDTO>(instructor);
            return View(instructorDTO);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(InstructorDTO instructorDTO)
        {
            if (ModelState.IsValid)
            {
                var data = _mapper.Map<Instructor>(instructorDTO);
                await _instructorService.Update(data);
                return RedirectToAction(nameof(Index));
            }           
            return View(instructorDTO);
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var instruct = await _instructorService.GetById(id.Value);
            if (instruct == null)
            {
                return NotFound();
            }
            var instructDTO = _mapper.Map<InstructorDTO>(instruct);

            return View(instructDTO);
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var instructor = await _instructorService.GetById(id.Value);
            if (instructor == null)
            {
                return NotFound();
            }
            var instructorDTO = _mapper.Map<InstructorDTO>(instructor);
            return View(instructorDTO);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var instructor = await _instructorService.GetById(id);
            try
            {
                await _instructorService.Delete(id);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ViewBag.Message = ex.Message;
                ViewBag.Type = "danger";
                var instructorDTO = _mapper.Map<InstructorDTO>(instructor);
                return View("Delete", instructorDTO);
            }

        }


    }
}