using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;
using POE_PART2_.Data;
using POE_PART2_.Models;

namespace POE_PART2_.RaceDayAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EventsController : ControllerBase
    {
        private readonly RaceDayContext _context;

        public EventsController(RaceDayContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetEvents()
        {
            return Ok(await _context.Events.ToListAsync());
        }

        [Authorize(Roles = "Organiser")]
        [HttpPost]
        public async Task<IActionResult> CreateEvent(Event ev)
        {
            _context.Events.Add(ev);

            await _context.SaveChangesAsync();

            return Ok(ev);
        }

        [Authorize(Roles = "Organiser")]
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateEvent(int id, Event ev)
        {
            if (id != ev.EventID)
            {
                return BadRequest();
            }

            _context.Entry(ev).State = EntityState.Modified;

            await _context.SaveChangesAsync();

            return Ok(ev);
        }

        [Authorize(Roles = "Organiser")]
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEvent(int id)
        {
            var ev = await _context.Events.FindAsync(id);

            if (ev == null)
            {
                return NotFound();
            }

            _context.Events.Remove(ev);

            await _context.SaveChangesAsync();

            return Ok();
        }
    }
}