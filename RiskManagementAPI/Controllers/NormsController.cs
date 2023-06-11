using Microsoft.AspNetCore.Mvc;
using RiskManagementAPI.Models;
using RiskManagementAPI.Services;

namespace RiskManagementAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NormsController : ControllerBase
    {
        private readonly INormService _normService;

        public NormsController(INormService normService)
        {
            _normService = normService;
        }

        // GET: api/Norms
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Norm>>> GetNorms()
        {
            var norms = await _normService.GetNorms();
            if (norms == null)
            {
                return NotFound();
            }
            return Ok(norms);
        }

        // GET: api/Norms/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Norm>> GetNorm(int id)
        {
            var norm = await _normService.GetNorm(id);
            if (norm == null)
            {
                return NotFound();
            }
            return Ok(norm);
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

            try
            {
                await _normService.UpdateNorm(norm);
            }
            catch (Exception)
            {
                if (!await _normService.NormExists(id))
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
            try
            {
                await _normService.CreateNorm(norm);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

            return CreatedAtAction("GetNorm", new { id = norm.NormId }, norm);
        }

        // DELETE: api/Norms/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteNorm(int id)
        {
            var norm = await _normService.GetNorm(id);
            if (norm == null)
            {
                return NotFound();
            }
            await _normService.DeleteNorm(norm.NormId);

            return NoContent();
        }
    }
}
