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
    public class ControlsController : ControllerBase
    {
        private readonly RiskDbContext _context;

        public ControlsController(RiskDbContext context)
        {
            _context = context;
        }

        // GET: api/Controls
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Control>>> GetControls()
        {
          if (_context.Controls == null)
          {
              return NotFound();
          }
            return await _context.Controls.ToListAsync();
        }

        // GET: api/Controls/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Control>> GetControl(int id)
        {
          if (_context.Controls == null)
          {
              return NotFound();
          }
            var control = await _context.Controls.FindAsync(id);

            if (control == null)
            {
                return NotFound();
            }

            return control;
        }

        // PUT: api/Controls/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutControl(int id, Control control)
        {
            if (id != control.ControlId)
            {
                return BadRequest();
            }

            _context.Entry(control).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ControlExists(id))
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

        // POST: api/Controls
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Control>> PostControl(Control control)
        {
          if (_context.Controls == null)
          {
              return Problem("Entity set 'RiskDbContext.Controls'  is null.");
          }
            _context.Controls.Add(control);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetControl", new { id = control.ControlId }, control);
        }

        // DELETE: api/Controls/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteControl(int id)
        {
            if (_context.Controls == null)
            {
                return NotFound();
            }
            var control = await _context.Controls.FindAsync(id);
            if (control == null)
            {
                return NotFound();
            }

            _context.Controls.Remove(control);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ControlExists(int id)
        {
            return (_context.Controls?.Any(e => e.ControlId == id)).GetValueOrDefault();
        }
    }
}
