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
    public class MetricValuesController : ControllerBase
    {
        private readonly GameAnalyticContext _context;

        public MetricValuesController(GameAnalyticContext context)
        {
            _context = context;
        }

        // GET: api/MetricValues
        [HttpGet]
        public async Task<ActionResult<IEnumerable<MetricValue>>> GetMetricValues()
        {
          if (_context.MetricValues == null)
          {
              return NotFound();
          }
            return await _context.MetricValues.ToListAsync();
        }

        // GET: api/MetricValues/5
        [HttpGet("{id}")]
        public async Task<ActionResult<MetricValue>> GetMetricValue(int id)
        {
          if (_context.MetricValues == null)
          {
              return NotFound();
          }
            var metricValue = await _context.MetricValues.FindAsync(id);

            if (metricValue == null)
            {
                return NotFound();
            }

            return metricValue;
        }

        // PUT: api/MetricValues/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMetricValue(int id, MetricValue metricValue)
        {
            if (id != metricValue.Id)
            {
                return BadRequest();
            }

            _context.Entry(metricValue).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MetricValueExists(id))
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

        // POST: api/MetricValues
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<MetricValue>> PostMetricValue(MetricValue metricValue)
        {
          if (_context.MetricValues == null)
          {
              return Problem("Entity set 'GameAnalyticContext.MetricValues'  is null.");
          }
            _context.MetricValues.Add(metricValue);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetMetricValue", new { id = metricValue.Id }, metricValue);
        }

        // DELETE: api/MetricValues/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMetricValue(int id)
        {
            if (_context.MetricValues == null)
            {
                return NotFound();
            }
            var metricValue = await _context.MetricValues.FindAsync(id);
            if (metricValue == null)
            {
                return NotFound();
            }

            _context.MetricValues.Remove(metricValue);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool MetricValueExists(int id)
        {
            return (_context.MetricValues?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
