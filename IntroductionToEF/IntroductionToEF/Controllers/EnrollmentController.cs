using IntroductionToEF.DAL;
using IntroductionToEF.Model;
using IntroductionToEF.WebModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel;

namespace IntroductionToEF.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class EnrollmentController : ControllerBase
    {
        private readonly SchoolContext _context;

        public EnrollmentController(SchoolContext context)
        {
            _context = context;
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var enrollments = await _context.Enrollments.ToListAsync();
            if (enrollments == null)
            {
                return BadRequest();
            }
            return Ok(enrollments);
        }
        [HttpPost]
        public async Task<IActionResult> CreateEnrollment([FromBody] CreateEnrollmentRequest request)
        {
            var newEnroll = new Enrollment { CourseID = request.CourseID, StudentID = request.StudentID };
            _context.Enrollments.Add(newEnroll);
            await _context.SaveChangesAsync();
            return Ok(await GetAll());
        }
    }
}

