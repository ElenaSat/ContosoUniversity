using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ContosoUniversity.Data;
using ContosoUniversity.Models;
using ContosoUniversity.Services;
using ContosoUniversity.DTOs;
using AutoMapper;

namespace ContosoUniversity.Controllers
{
    public class StudentsController : Controller
    {
        private readonly IStudentService _studentService;
        private readonly IMapper _mapper;

        public StudentsController( IStudentService studentService, IMapper mapper)
        {
            this._studentService = studentService;
            this._mapper = mapper;
            
        }

        // GET: Students
        public async Task<IActionResult> Index(int? id)
        {
            if (id != null)
            {
                var dataCourse = await _studentService.GetCourseByStudents(id.Value);
                ViewBag.Courses = dataCourse.Select(x => _mapper.Map<CoursesDTO>(x)).ToList();

                var student = await _studentService.GetById(id.Value);
                var studentDTO = _mapper.Map<StudentDTO>(student);
                ViewBag.studentD = studentDTO.LastName + " " + studentDTO.FirstMidName;
            }
            var data = await _studentService.GetAll();
            var listStudents = data.Select(x=>_mapper.Map<StudentDTO>(x)).ToList();
            return View(listStudents);
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var student = await _studentService.GetById(id.Value);

            if (student == null)
            {
                return NotFound();
            }
            var studentDTO = _mapper.Map<StudentDTO>(student);
            return View(studentDTO);
        }

        public IActionResult Create()
        {
            return View();
        }

        // POST: Students/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(StudentDTO studentDTO)
        {
            //var student = new Student {
            //    LastName=studentDTO.LastName,
            //    FirstMidName=studentDTO.FirstMidName,
            //    EnrollmentDate =studentDTO.EnrollmentDate
            //};

            if (ModelState.IsValid)
            {
                var student = _mapper.Map<Student>(studentDTO);
                student =await _studentService.Insert(student);
                var id = student.ID;
                return RedirectToAction("Index");
            }
            return View(studentDTO);
        }

        // GET: Students/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var student = await _studentService.GetById(id.Value);
            if (student == null)
            {
                return NotFound();
            }
            var studentDTO = _mapper.Map<StudentDTO>(student);
            return View(studentDTO);
        }

        // POST: Students/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(StudentDTO studentDTO)
        {
            
            if (ModelState.IsValid)
            {
                var student = _mapper.Map<Student>(studentDTO);
                await _studentService.Update(student);
                return RedirectToAction(nameof(Index));
            }
            return View(studentDTO);
        }


        // GET: Students/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var student = await _studentService.GetById(id.Value);
            if (student == null)
            {
                return NotFound();
            }
            var studentDTO = _mapper.Map<StudentDTO>(student);
            return View(studentDTO);
        }

        // POST: Students/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            try
            {
                await _studentService.Delete(id);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ViewBag.Message = ex.Message;
                ViewBag.Type = "danger";
                return View("Delete");
            }
        }

    }
}
