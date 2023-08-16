using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using API.Models;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AnalyticsController : ControllerBase
    {
        private readonly GameAnalyticContext _context;

        public AnalyticsController(GameAnalyticContext context)
        {
            _context = context;
        }

        // GET: api/Analytics
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Analytic>>> GetAnalytics()
        {
          if (_context.Analytics == null)
          {
              return NotFound();
          }
            return await _context.Analytics.ToListAsync();
        }

        // GET: api/Analytics/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Analytic>> GetAnalytic(int id)
        {
          if (_context.Analytics == null)
          {
              return NotFound();
          }
            var analytic = await _context.Analytics.FindAsync(id);

            if (analytic == null)
            {
                return NotFound();
            }

            return analytic;
        }

        // PUT: api/Analytics/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAnalytic(int id, Analytic analytic)
        {
            if (id != analytic.Id)
            {
                return BadRequest();
            }

            _context.Entry(analytic).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AnalyticExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Analytics
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Analytic>> PostAnalytic(Analytic analytic)
        {
          if (_context.Analytics == null)
          {
              return Problem("Entity set 'GameAnalyticContext.Analytics'  is null.");
          }
            _context.Analytics.Add(analytic);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetAnalytic", new { id = analytic.Id }, analytic);
        }

        // DELETE: api/Analytics/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAnalytic(int id)
        {
            if (_context.Analytics == null)
            {
                return NotFound();
            }
            var analytic = await _context.Analytics.FindAsync(id);
            if (analytic == null)
            {
                return NotFound();
            }

            _context.Analytics.Remove(analytic);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool AnalyticExists(int id)
        {
            return (_context.Analytics?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
