using IntroductionToEF.DAL;
using IntroductionToEF.Model;
using IntroductionToEF.WebModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace IntroductionToEF.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AssignmentResultController : ControllerBase
    {
        private SchoolContext _context;
        public AssignmentResultController(SchoolContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var results = await _context.AssignmentResults.Include(result => result.Assignment).Include(result => result.Student).ToListAsync();
            if (results!= null)
            {
                return Ok(results);
            }
            else
            {
                return BadRequest();
            }
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateAssignmentResultRequest request)
        {
            var newResult = new AssignmentResult { ID=request.ID, AssignmentID=request.AssignmentID,StudentID=request.StudentID,Score=request.Score };
            _context.AssignmentResults.Add(newResult);
            await _context.SaveChangesAsync();
            return Ok(newResult);
        }

    }
}
