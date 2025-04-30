using Demo.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Demo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AttendeeController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public AttendeeController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/attendee
        [HttpGet]
        public async Task<IActionResult> GetAllAttendees()
        {
            var attendees = await _context.Attendees
                .Include(a => a.AttendingEvents)
                .Select(a => new
                {
                    attendeeId = a.AttendeeId,
                    name = a.Name,
                    email = a.Email,
                    title = a.Title,
                    department = a.Department,
                    attendingEventIds = a.AttendingEvents.Select(e => e.EventId).ToList()
                })
                .ToListAsync();

            return Ok(attendees);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<object>> GetAttendeeById(Guid id)
        {
            var attendee = await _context.Attendees
                .Include(a => a.AttendingEvents)
                .Where(a => a.AttendeeId == id)
                .Select(a => new
                {
                    attendeeId = a.AttendeeId,
                    name = a.Name,
                    email = a.Email,
                    title = a.Title,
                    department = a.Department,
                    attendingEventIds = a.AttendingEvents.Select(e => e.EventId).ToList()
                })
                .FirstOrDefaultAsync();

            if (attendee == null)
                return NotFound();

            return Ok(attendee);
        }
    }
}
