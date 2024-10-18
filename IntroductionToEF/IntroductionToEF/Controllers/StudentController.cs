using IntroductionToEF.DAL;
using IntroductionToEF.Model;
using IntroductionToEF.WebModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Text.Json.Serialization;
using System.Text.Json;
using Azure;

namespace IntroductionToEF.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly SchoolContext _context;

        public StudentController(SchoolContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var students = await _context.Students.AsNoTracking()
                .Include(student => student.Enrollments)
                .ThenInclude(enrollment => enrollment.Course)
                .Include(student => student.StudentCard)
                .ToListAsync();

            //var results = students.Select(student => new
            //{
            //    studentID = student.ID,
            //    studentName = student.FirstMidName,
            //    classIRN = student.StudentCard?.ClassIRN,   
            //});
            var results = students.Select(student => new GetAllStudentsResponse
            {
                StudentId = student.ID,
                StudentFirstMidName = student.FirstMidName,
                StudentLastName = student.LastName,
                RegisteredCourseList = student.Enrollments.Select(enrollment => new RegisteredCourse
                {
                    CourseId = enrollment.CourseID,
                    CourseName = enrollment.Course.Title
                }).ToList(),
                CardResponse = new CardResponse
                {
                    ClassIRN = student.StudentCard?.ClassIRN,
                    Period = student.StudentCard?.Period,
                }
            });

            return Ok(results);

        }


        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateStudentRequest request)
        {
            if (request == null)
            {
                return BadRequest("Request is null");
            }
            _context.Students.Add(new Student { ID = request.Id, FirstMidName = request.FirstMidName, LastName = request.LastName });
            await _context.SaveChangesAsync();
            return Ok(await GetAll());

        }

        [HttpGet("{Id}")]
        public async Task<IActionResult> GetById(int Id)
        {
            var student = await _context.Students.FindAsync(Id);
            if (student == null)
            {
                return BadRequest("Not found");
            }
            return Ok(student);
        }

        [HttpDelete("{Id}")]
        public async Task<IActionResult> Delete(int Id)
        {
            var student = await _context.Students.FindAsync(Id);
            if (student == null)
            {
                return BadRequest("Not found");
            }
            _context.Students.Remove(student);
            await _context.SaveChangesAsync();
            return Ok(await GetAll());
        }

        [HttpPut]
        public async Task<IActionResult> Update(UpdateStudentRequest request)
        {
            var student = await _context.Students.FindAsync(request.Id);
            if (student == null)
            {
                return BadRequest("Not found");
            }
            student.FirstMidName = request.FirstMidName;
            student.LastName = request.LastName;
            _context.Students.Update(student);
            await _context.SaveChangesAsync();
            return Ok(await GetAll());
        }

    }

}

