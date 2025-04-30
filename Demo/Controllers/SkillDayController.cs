using Demo.Data;
using Demo.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Demo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SkillDayController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public SkillDayController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllSkilldays()
        {
            var skilldays = await _context.SkillDays
                .Include(sd => sd.Events)
                .Select(sd => new
                {
                    SkillDayId = sd.SkillDayId,
                    Name = sd.Name,
                    Department = sd.Department,
                    ResponsibleId = sd.ResponsibleId,
                    EventIds = sd.Events.Select(e => e.EventId).ToList()
                })
                .ToListAsync();

            return Ok(skilldays);
        }


        [HttpGet("{id}")]
        public async Task<IActionResult> GetSkilldayById(Guid id)
        {
            var skillday = await _context.SkillDays
                .Include(sd => sd.Events)
                .Where(sd => sd.SkillDayId == id)
                .Select(sd => new
                {
                    SkillDayId = sd.SkillDayId,
                    Name = sd.Name,
                    Department = sd.Department,
                    ResponsibleId = sd.ResponsibleId,
                    EventIds = sd.Events.Select(e => e.EventId).ToList()
                })
                .FirstOrDefaultAsync();

            if (skillday == null)
            {
                return NotFound();
            }

            return Ok(skillday);
        }

    }
}
