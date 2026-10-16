using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;
using POE_PART2_.Data;
using POE_PART2_.Models;

namespace POE_PART2_.RaceDayAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EnrolmentsController : ControllerBase
    {
        private readonly RaceDayContext _context;

        public EnrolmentsController(RaceDayContext context)
        {
            _context = context;
        }

        [Authorize(Roles = "Participant")]
        [HttpPost]
        public async Task<IActionResult> Enrol(Enrolment enrolment)
        {
            enrolment.RegistrationDate = DateTime.Now;

            _context.Enrolments.Add(enrolment);

            await _context.SaveChangesAsync();

            return Ok(enrolment);
        }

        [Authorize(Roles = "Organiser")]
        [HttpGet("event/{eventId}")]
        public async Task<IActionResult> GetEnrolmentsForEvent(int eventId)
        {
            var enrolments = await _context.Enrolments
                .Include(e => e.Participant)
                .Include(e => e.Category)
                .Where(e => e.Category != null &&
                            e.Category.EventID == eventId)
                .ToListAsync();

            return Ok(enrolments);
        }
    }
}
