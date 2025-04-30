using Demo.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Demo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReportsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public ReportsController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet("department-most-events")]
        public async Task<IActionResult> DepartmentWithMostEvents()
        {
            var result = await _context.SkillDays
                .Include(sd => sd.Events)
                .GroupBy(sd => sd.Department)
                .Select(g => new
                {
                    Department = g.Key,
                    EventCount = g.Sum(sd => sd.Events.Count)
                })
                .OrderByDescending(x => x.EventCount)
                .FirstOrDefaultAsync();

            return Ok(result);
        }

    }
}
