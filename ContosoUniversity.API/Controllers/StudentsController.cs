using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ContosoUniversity.API.DTOs;
using ContosoUniversity.API.Models;
using ContosoUniversity.API.Data;
using Microsoft.EntityFrameworkCore;

namespace ContosoUniversity.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentsController : ControllerBase
    {
        private readonly SchoolContext schoolContext;
        public StudentsController(SchoolContext schoolContext) {
            this.schoolContext = schoolContext;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> GetAll() {
            var listStudents = await schoolContext.Students.ToListAsync();
            var listStudentsDTO = listStudents.Select(x => StudentToDto(x));
            return Ok(listStudentsDTO);
        }

        /// <summary>
        /// Obtiene un objeto de estudiante por su Id.
        /// </summary>
        /// <remarks>
        /// Aquí una descripción más larga su fuera necesario. Obtiene un objeto de estudiante por su Id.
        /// </remarks>
        /// <param name="id">Id (GUID) del objeto</param>
        /// <response code="200">OK. Devuelve el objeto solicitado.</response>
        /// <response code="404">NotFound. No se ha encontrado el objeto solicitado.</response>
        /// <returns></returns>
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetById(int? id)
        {
            if (id == null)
                return NotFound();
            var students = await schoolContext.Students.FirstOrDefaultAsync(x=>x.ID==id);

            if (students == null)
                return NotFound();

            var studentsDTO = StudentToDto(students);
            return Ok(studentsDTO);
        }
        /// <summary>
        /// Crear el objeto Student
        /// </summary>
        /// <param name="studentDTO"></param>
        /// <response code="200">OK. Crea el objeto.</response>
        /// <response code="404">NotFound. No se ha creado el objeto solicitado.</response>
        /// <returns></returns>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> CreateStudent(StudentDTO studentDTO) {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest();

                var student = new Student
                {
                    LastName = studentDTO.LastName,
                    FirstMidName = studentDTO.FirstMidName,
                    EnrollmentDate = studentDTO.EnrollmentDate

                };
                await schoolContext.Students.AddAsync(student);
                await schoolContext.SaveChangesAsync();
                return Ok(StudentToDto(student));
            }
            catch (Exception ex )
            {
                return StatusCode(500, ex.Message);
            }

        }
        /// <summary>
        /// Edita el objeto Student
        /// </summary>
        /// <param name="id"></param>
        /// <param name="studentDTO"></param>
        /// <response code="200">OK. Edita el objeto.</response>
        /// <response code="404">NotFound. No se ha editado el objeto solicitado.</response>
        /// <returns></returns>
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> UpdateStudent(int ? id, StudentDTO studentDTO)
        {
            try
            {
                if (id != studentDTO.ID)
                    return BadRequest();

                if (!ModelState.IsValid)
                    return BadRequest();

                var student = await  schoolContext.Students.FindAsync(id);
                student.LastName = studentDTO.LastName;
                student.FirstMidName = studentDTO.FirstMidName;
                student.EnrollmentDate = studentDTO.EnrollmentDate;
                
                await schoolContext.SaveChangesAsync();

                return Ok(StudentToDto(student));
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }

        }
        /// <summary>
        /// Elimina el objeto Student
        /// </summary>
        /// <param name="id"></param>
        /// <response code="200">OK. Elimina el objeto.</response>
        /// <response code="404">NotFound. No se ha eliminado el objeto solicitado.</response>
        /// <returns></returns>
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> DeleteStudent(int? id)
        {
            try
            {
                if (id ==null)
                    return BadRequest();
                              
                var student = await schoolContext.Students.FindAsync(id);

                schoolContext.Students.Remove(student);
                await schoolContext.SaveChangesAsync();

                return Ok(StudentToDto(student));
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }

        }
        private static StudentDTO StudentToDto(Student student) => new StudentDTO
        {
            ID=student.ID,
            LastName=student.LastName,
            FirstMidName=student.FirstMidName,
            EnrollmentDate=student.EnrollmentDate
        };

    }
}