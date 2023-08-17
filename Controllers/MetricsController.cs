﻿using System;
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
    public class MetricsController : ControllerBase
    {
        private readonly GameAnalyticContext _context;

        public MetricsController(GameAnalyticContext context)
        {
            _context = context;
        }

        // GET: api/Metrics
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Metric>>> GetMetrics()
        {
          if (_context.Metrics == null)
          {
              return NotFound();
          }
            return await _context.Metrics.ToListAsync();
        }

        // GET: api/Metrics/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Metric>> GetMetric(int id)
        {
          if (_context.Metrics == null)
          {
              return NotFound();
          }
            var metric = await _context.Metrics.FindAsync(id);

            if (metric == null)
            {
                return NotFound();
            }

            return metric;
        }

        // PUT: api/Metrics/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMetric(int id, Metric metric)
        {
            if (id != metric.Id)
            {
                return BadRequest();
            }

            _context.Entry(metric).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MetricExists(id))
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

        // POST: api/Metrics
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Metric>> PostMetric(Metric metric)
        {
            if (!ModelState.IsValid)
            {
                var errors = ModelState.Values
                    .SelectMany(v => v.Errors)
                    .Select(e => e.ErrorMessage)
                    .ToList();

                return BadRequest(new { Errors = errors });
            }
            if (_context.Metrics == null)
            {
              return Problem("Entity set 'GameAnalyticContext.Metrics'  is null.");
            }
            _context.Metrics.Add(metric);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetMetric", new { id = metric.Id }, metric);
        }

        // DELETE: api/Metrics/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMetric(int id)
        {
            if (_context.Metrics == null)
            {
                return NotFound();
            }
            var metric = await _context.Metrics.FindAsync(id);
            if (metric == null)
            {
                return NotFound();
            }

            _context.Metrics.Remove(metric);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool MetricExists(int id)
        {
            return (_context.Metrics?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
