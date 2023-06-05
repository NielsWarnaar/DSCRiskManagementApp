using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RiskManagementAPI.DBContext;
using RiskManagementAPI.Models;

namespace RiskManagementAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NormsController : ControllerBase
    {
        private readonly RiskDbContext _context;

        public NormsController(RiskDbContext context)
        {
            _context = context;
        }

        // GET: api/Norms
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Norm>>> GetNorms()
        {
          if (_context.Norms == null)
          {
              return NotFound();
          }
            return await _context.Norms.ToListAsync();
        }

        // GET: api/Norms/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Norm>> GetNorm(int id)
        {
          if (_context.Norms == null)
          {
              return NotFound();
          }
            var norm = await _context.Norms.FindAsync(id);

            if (norm == null)
            {
                return NotFound();
            }

            return norm;
        }

        // PUT: api/Norms/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutNorm(int id, Norm norm)
        {
            if (id != norm.NormId)
            {
                return BadRequest();
            }

            _context.Entry(norm).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!NormExists(id))
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

        // POST: api/Norms
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Norm>> PostNorm(Norm norm)
        {
          if (_context.Norms == null)
          {
              return Problem("Entity set 'RiskDbContext.Norms'  is null.");
          }
            _context.Norms.Add(norm);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetNorm", new { id = norm.NormId }, norm);
        }

        // DELETE: api/Norms/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteNorm(int id)
        {
            if (_context.Norms == null)
            {
                return NotFound();
            }
            var norm = await _context.Norms.FindAsync(id);
            if (norm == null)
            {
                return NotFound();
            }

            _context.Norms.Remove(norm);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool NormExists(int id)
        {
            return (_context.Norms?.Any(e => e.NormId == id)).GetValueOrDefault();
        }
    }
}
