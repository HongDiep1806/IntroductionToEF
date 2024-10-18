using IntroductionToEF.DAL;
using IntroductionToEF.Model;
using IntroductionToEF.WebModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace IntroductionToEF.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentCardController : ControllerBase
    {
        private readonly SchoolContext _context;

        public StudentCardController(SchoolContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var studentcards = await _context.StudentCards.Include(card => card.Student).ToListAsync();
            var results = studentcards.Select(card => new GetAllStudentCardResponse
            {
                StudentId = card.StudentID,
                Period = card.Period,
                ClassIRN = card.ClassIRN,
                StudentName = $"{card.Student.FirstMidName} {card.Student.LastName}",
            }).ToList();

            return Ok(results);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateStudentCardRequest request)
        {
            if (request == null)
            {
                return BadRequest("Request is null");
            }
            _context.StudentCards.Add(new StudentCard {StudentID = request.StudentId, ClassIRN = request.ClassIRN, Period = request.Period});
            await _context.SaveChangesAsync();
            return Ok(await GetAll());

        }

    }
}
