using Microsoft.AspNetCore.Mvc;
using RiskManagementAPI.Models;
using RiskManagementAPI.Services;

namespace RiskManagementAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RiskHistoriesController : ControllerBase
    {
        private readonly IRiskHistoryService _riskHistoryService;

        public RiskHistoriesController(IRiskHistoryService riskHistoryService)
        {
            _riskHistoryService = riskHistoryService;
        }

        // GET: api/RiskHistories
        [HttpGet]
        public async Task<ActionResult<IEnumerable<RiskHistory>>> GetRiskHistories()
        {
            var riskHistories = await _riskHistoryService.GetAllRiskHistory();
            if (riskHistories == null)
            {
                return NotFound();
            }
            return Ok(riskHistories);
        }

        // GET: api/RiskHistories/5
        [HttpGet("{id}")]
        public async Task<ActionResult<RiskHistory>> GetRiskHistory(int id)
        {
            var riskHistory = await _riskHistoryService.GetRiskHistoryById(id);
            if (riskHistory == null)
            {
                return NotFound();
            }

            return Ok(riskHistory);
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

            try
            {
                await _riskHistoryService.UpdateRiskHistory(riskHistory);
            }
            catch (Exception)
            {
                if (!await _riskHistoryService.RiskHistoryExists(id))
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
            try
            {
                await _riskHistoryService.CreateRiskHistory(riskHistory);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            return CreatedAtAction("GetRiskHistory", new { id = riskHistory.RiskHistoryId }, riskHistory);
        }

        // DELETE: api/RiskHistories/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRiskHistory(int id)
        {
            var riskHistory = await _riskHistoryService.GetRiskHistoryById(id);
            if (riskHistory == null)
            {
                return NotFound();
            }
            await _riskHistoryService.DeleteRiskHistory(riskHistory.RiskId);

            return NoContent();
        }
    }
}
