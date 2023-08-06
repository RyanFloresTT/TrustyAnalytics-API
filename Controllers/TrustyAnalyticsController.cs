using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using API.Models;
using TrustyAnalytics.Models;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TrustyAnalyticsController : ControllerBase
    {
        private readonly TrustyAnalyticContext _context;

        public TrustyAnalyticsController(TrustyAnalyticContext context)
        {
            _context = context;
        }

        // GET: api/TrustyAnalytics
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TrustyAnalytic>>> GetAnalytics()
        {
          if (_context.Analytics == null)
          {
              return NotFound();
          }
            return await _context.Analytics.ToListAsync();
        }

        // GET: api/TrustyAnalytics/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TrustyAnalytic>> GetTrustyAnalytic(long id)
        {
          if (_context.Analytics == null)
          {
              return NotFound();
          }
            var trustyAnalytic = await _context.Analytics.FindAsync(id);

            if (trustyAnalytic == null)
            {
                return NotFound();
            }

            return trustyAnalytic;
        }

        // PUT: api/TrustyAnalytics/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTrustyAnalytic(long id, TrustyAnalytic trustyAnalytic)
        {
            if (id != trustyAnalytic.Id)
            {
                return BadRequest();
            }

            _context.Entry(trustyAnalytic).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TrustyAnalyticExists(id))
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

        // POST: api/TrustyAnalytics
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<TrustyAnalytic>> PostTrustyAnalytic(TrustyAnalytic trustyAnalytic)
        {
          if (_context.Analytics == null)
          {
              return Problem("Entity set 'TrustyAnalyticContext.Analytics'  is null.");
          }
            _context.Analytics.Add(trustyAnalytic);
            await _context.SaveChangesAsync();

            //return CreatedAtAction("GetTrustyAnalytic", new { id = trustyAnalytic.Id }, trustyAnalytic);
            return CreatedAtAction(nameof(GetTrustyAnalytic), new { id = trustyAnalytic.Id }, trustyAnalytic);
        }

        // DELETE: api/TrustyAnalytics/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTrustyAnalytic(long id)
        {
            if (_context.Analytics == null)
            {
                return NotFound();
            }
            var trustyAnalytic = await _context.Analytics.FindAsync(id);
            if (trustyAnalytic == null)
            {
                return NotFound();
            }

            _context.Analytics.Remove(trustyAnalytic);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TrustyAnalyticExists(long id)
        {
            return (_context.Analytics?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
