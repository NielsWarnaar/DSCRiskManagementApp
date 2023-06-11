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
    public class RiskHistoriesController : ControllerBase
    {
        private readonly RiskDbContext _context;

        public RiskHistoriesController(RiskDbContext context)
        {
            _context = context;
        }

        // GET: api/RiskHistories
        [HttpGet]
        public async Task<ActionResult<IEnumerable<RiskHistory>>> GetRiskHistories()
        {
          if (_context.RiskHistories == null)
          {
              return NotFound();
          }
            return await _context.RiskHistories.ToListAsync();
        }

        // GET: api/RiskHistories/5
        [HttpGet("{id}")]
        public async Task<ActionResult<RiskHistory>> GetRiskHistory(int id)
        {
          if (_context.RiskHistories == null)
          {
              return NotFound();
          }
            var riskHistory = await _context.RiskHistories.FindAsync(id);

            if (riskHistory == null)
            {
                return NotFound();
            }

            return riskHistory;
        }

        // PUT: api/RiskHistories/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutRiskHistory(int id, RiskHistory riskHistory)
        {
            if (id != riskHistory.RiskHistoryId)
            {
                return BadRequest();
            }

            _context.Entry(riskHistory).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RiskHistoryExists(id))
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

        // POST: api/RiskHistories
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<RiskHistory>> PostRiskHistory(RiskHistory riskHistory)
        {
          if (_context.RiskHistories == null)
          {
              return Problem("Entity set 'RiskDbContext.RiskHistories'  is null.");
          }
            _context.RiskHistories.Add(riskHistory);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetRiskHistory", new { id = riskHistory.RiskHistoryId }, riskHistory);
        }

        // DELETE: api/RiskHistories/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRiskHistory(int id)
        {
            if (_context.RiskHistories == null)
            {
                return NotFound();
            }
            var riskHistory = await _context.RiskHistories.FindAsync(id);
            if (riskHistory == null)
            {
                return NotFound();
            }

            _context.RiskHistories.Remove(riskHistory);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool RiskHistoryExists(int id)
        {
            return (_context.RiskHistories?.Any(e => e.RiskHistoryId == id)).GetValueOrDefault();
        }
    }
}
