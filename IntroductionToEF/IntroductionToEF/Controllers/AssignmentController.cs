using IntroductionToEF.DAL;
using IntroductionToEF.Model;
using IntroductionToEF.WebModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace IntroductionToEF.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AssignmentController : ControllerBase
    {
        private readonly SchoolContext _context;
        public AssignmentController(SchoolContext context)
        {
            _context = context;
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var assignments = await _context.Assignments.Include(assign => assign.Course).ToListAsync();
            if (assignments!=null) 
            { 
                return Ok(assignments);
            }
            else
            {
                return BadRequest();
            }
        }
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateAssignmentRequest request)
        {
            var newAssignment = new Assignment { ID = request.ID, Title=request.Title,CourseID=request.CourseID,Description = request.Description };
            _context.Assignments.Add(newAssignment);
            await _context.SaveChangesAsync();
            return Ok(newAssignment);
        }
    }

}
