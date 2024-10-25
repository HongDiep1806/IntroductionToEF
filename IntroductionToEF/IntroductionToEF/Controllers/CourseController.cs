using IntroductionToEF.DAL;
using IntroductionToEF.Model;
using IntroductionToEF.WebModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace IntroductionToEF.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CourseController : ControllerBase
    {
        private readonly SchoolContext _context;
        private readonly ILogger _logger;
        public CourseController(SchoolContext context, ILogger<CourseController> logger)
        {
            _context = context;
            _logger = logger;
        }

        [HttpGet("testlog")]
        public IActionResult TestLog() 
        {
           _logger.LogInformation("this is test log");
            return Ok();
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var courses = await _context.Courses.Include(course => course.Enrollments)
                                                .ThenInclude(enroll => enroll.Student)
                                                .Include(course => course.Assignments)
                                                .ToListAsync();
            if (courses != null)
            {
                var results = courses.Select(course => new GetAllCourseResponse
                {
                    ID = course.ID,
                    Title = course.Title,
                    Credits = course.Credits,

                    Assignments = course.Assignments.Select(assign => new AssignmentResponse
                    {
                        ID = assign.ID,
                        Title = assign.Title,
                        CourseName = assign.Course.Title,
                        Description = assign.Description
                    }).ToList(),

                    Enrollments = course.Enrollments.Select(enroll => new EnrollmentResponse
                    {
                        EnrollmentID=enroll.Course.ID,
                        StudentName = enroll.Student.FirstMidName+" "+ enroll.Student.LastName
                    }
                    ).ToList()                    
                }).ToList();
                return Ok(results); 
            }
            else
            {
                return BadRequest();
            }
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateCourseRequest request)
        {
            var newCourse = new Course { ID = request.Id, Credits = request.Credits, Title = request.Title };
            _context.Courses.Add(newCourse);
            await _context.SaveChangesAsync();
            return Ok(newCourse);
        }

    }
}
