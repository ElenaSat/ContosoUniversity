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
using AutoMapper;
using ContosoUniversity.DTOs;

namespace ContosoUniversity.Controllers
{
    public class OfficeAssignmentsController : Controller
    {
        private readonly IOfficeAssignmentService _assignmentService;
        private readonly IInstructorService _instructorService;
        private readonly IMapper _mapper;

        public OfficeAssignmentsController(IOfficeAssignmentService officeAssignmentService, IMapper mapper, IInstructorService instructorService)
        {
            _assignmentService = officeAssignmentService;
            _mapper = mapper;
            _instructorService = instructorService;
        }

        // GET: OfficeAssignments
        public async Task<IActionResult> Index()
        {
            var data = await _assignmentService.GetAll();
            var listOfficeAssignments = data.Select(x => _mapper.Map<OfficeAssignmentDTO>(x)).ToList();
            return View(listOfficeAssignments);
        }

        // GET: OfficeAssignments/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var officeAssignment = await _assignmentService.GetById(id.Value);
            if (officeAssignment == null)
            {
                return NotFound();
            }
            var officeAssignmentDTO = _mapper.Map<OfficeAssignmentDTO>(officeAssignment);

            return View(officeAssignmentDTO);
        }

        // GET: OfficeAssignments/Create
        public async Task<IActionResult> Create()
        {
            var listinstructors = await _instructorService.GetAll();
            ViewBag.Instructors = listinstructors;
            return View();
        }

        // POST: OfficeAssignments/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(OfficeAssignmentDTO officeAssignment)
        {
            if (ModelState.IsValid)
            {
                var office = _mapper.Map<OfficeAssignment>(officeAssignment);
                await _assignmentService.Insert(office);
                return RedirectToAction(nameof(Index));
            }
            var listinstructors = _instructorService.GetAll();
            ViewBag.Instructors = listinstructors;
            return View(officeAssignment);
        }

        // GET: OfficeAssignments/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var officeAssignment = await _assignmentService.GetById(id.Value);
            if (officeAssignment == null)
            {
                return NotFound();
            }
            // var instructors = await _instructorService.GetById(id.Value);
            ViewData["InstructorID"] = officeAssignment.InstructorID;
            var officeAssignmentDTO = _mapper.Map<OfficeAssignmentDTO>(officeAssignment);
            return View(officeAssignmentDTO);
        }

        // POST: OfficeAssignments/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(OfficeAssignmentDTO officeAssignmentDTO)
        {
            if (ModelState.IsValid)
            {
                var office = _mapper.Map<OfficeAssignment>(officeAssignmentDTO);
                await _assignmentService.Update(office);
                return RedirectToAction(nameof(Index));
            }
            ViewData["InstructorID"] = officeAssignmentDTO.InstructorID;
            return View(officeAssignmentDTO);
        }

        // GET: OfficeAssignments/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var officeAssignment = await _assignmentService.GetById(id.Value);
            if (officeAssignment == null)
            {
                return NotFound();
            }
            var officeAssignmentDTO = _mapper.Map<OfficeAssignmentDTO>(officeAssignment);
            return View(officeAssignmentDTO);
        }

        // POST: OfficeAssignments/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            try
            {
                await _assignmentService.Delete(id);
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
