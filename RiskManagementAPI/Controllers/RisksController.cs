using Microsoft.AspNetCore.Mvc;
using RiskManagementAPI.Models;
using RiskManagementAPI.Services;

namespace RiskManagementAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RisksController : ControllerBase
    {
        private readonly IRiskService _riskService;

        public RisksController(IRiskService riskService)
        {
            _riskService = riskService;
        }

        // GET: api/Risks
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Risk>>> GetRisks()
        {
            var risks = await _riskService.GetRisks();
            if (risks == null)
            {
                return NotFound();
            }
            return Ok(risks);
        }

        // GET: api/Risks/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Risk>> GetRisk(int id)
        {
            var risk = await _riskService.GetRiskById(id);
            if (risk == null)
            {
                return NotFound();
            }

            return Ok(risk);
        }

        // PUT: api/Risks/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutRisk(int id, Risk risk)
        {
            if (id != risk.RiskId)
            {
                return BadRequest();
            }

            try
            {
                await _riskService.UpdateRisk(risk);
            }
            catch (Exception)
            {
                if (!await _riskService.RiskExists(id))
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

        // POST: api/Risks
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Risk>> PostRisk(Risk risk)
        {
          try
            {
                await _riskService.AddRisk(risk);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

            return CreatedAtAction("GetRisk", new { id = risk.RiskId }, risk);
        }

        // DELETE: api/Risks/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRisk(int id)
        {
            var risk = await _riskService.GetRiskById(id);
            if (risk == null)
            {
                return NotFound();
            }

            await _riskService.DeleteRisk(risk.RiskId);

            return NoContent();
        }
    }
}
