using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ContosoUniversity.Data;
using ContosoUniversity.Models;
using AutoMapper;
using ContosoUniversity.Services;
using ContosoUniversity.DTOs;

namespace ContosoUniversity.Controllers
{
    public class DepartmentsController : Controller
    {
       
        private readonly IMapper _mapper;
        private readonly IDepartmentService _departmentService;
        private readonly IInstructorService _instructorService;

        public DepartmentsController( IMapper mapper, IDepartmentService departmentService, IInstructorService instructorService)
        {
            _mapper = mapper;
            _departmentService = departmentService;
            _instructorService = instructorService;
        }

        // GET: Departments
        public async Task<IActionResult> Index()
        {
            var data = await _departmentService.GetAll();
            var listDepartments = data.Select(x => _mapper.Map<DepartmentDTO>(x)).ToList();
            return View(listDepartments);
        }

        // GET: Departments/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var department = await _departmentService.GetById(id.Value);
            if (department == null)
            {
                return NotFound();
            }
            var departmentDTO = _mapper.Map<DepartmentDTO>(department);
            return View(departmentDTO);
        }

        // GET: Departments/Create
        public async Task<IActionResult> Create()
        {
            var data = await _instructorService.GetAll();
            ViewBag.Instructors = data.Select(x => _mapper.Map<InstructorDTO>(x)).ToList();
            return View();
        }

        // POST: Departments/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(DepartmentDTO department)
        {
            if (ModelState.IsValid)
            {
                var depart = _mapper.Map<Department>(department);
                await _departmentService.Insert(depart);
                return RedirectToAction(nameof(Index));
            }
            var data = await _instructorService.GetAll();
            ViewBag.Instructors = data.Select(x => _mapper.Map<InstructorDTO>(x)).ToList();
            return View(department);
        }

        // GET: Departments/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var department = await _departmentService.GetById(id.Value);
            if (department == null)
            {
                return NotFound();
            }
            var deparmentDTO = _mapper.Map<DepartmentDTO>(department);
            var data = await _instructorService.GetAll();
            ViewBag.Instructors = data.Select(x => _mapper.Map<InstructorDTO>(x)).ToList();
            return View(deparmentDTO);
        }

        // POST: Departments/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit( DepartmentDTO departmentDTO)
        {
            if (ModelState.IsValid)
            {
                var deparment = _mapper.Map<Department>(departmentDTO);
                await _departmentService.Update(deparment);
                return RedirectToAction(nameof(Index));
            }            
            var data = await _instructorService.GetAll();
            ViewBag.Instructors = data.Select(x => _mapper.Map<InstructorDTO>(x)).ToList();

            return View(departmentDTO);
        }

        // GET: Departments/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var department = await _departmentService.GetById(id.Value);
            if (department == null)
            {
                return NotFound();
            }
            var deparmentDTO = _mapper.Map<DepartmentDTO>(department);
            return View(deparmentDTO);
        }

        // POST: Departments/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            try
            {
                await _departmentService.Delete(id);
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
