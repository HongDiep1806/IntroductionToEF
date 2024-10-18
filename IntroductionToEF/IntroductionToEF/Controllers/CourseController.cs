using IntroductionToEF.DAL;
using IntroductionToEF.Model;
using IntroductionToEF.WebModel;
using Microsoft.AspNetCore.Mvc;

namespace IntroductionToEF.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CourseController : ControllerBase
    {
        private readonly SchoolContext _context;
       public CourseController(SchoolContext context) 
        {
        _context = context;
        }
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateCourseRequest request) 
        {
            var newCourse = new Course {ID=request.Id, Credits = request.Credits,Title=request.Title };
            _context.Courses.Add(newCourse);
            await _context.SaveChangesAsync();
            return Ok(newCourse);
        }

    }
}
