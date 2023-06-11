using Microsoft.AspNetCore.Mvc;
using RiskManagementAPI.Models;
using RiskManagementAPI.Services;

namespace RiskManagementAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ControlsController : ControllerBase
    {
        private readonly IControlService _controlService;

        public ControlsController(IControlService controlService)
        {
            _controlService = controlService;
        }

        // GET: api/Controls
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Control>>> GetControls()
        {
            var controls = await _controlService.GetControls();
            if (controls == null)
            {
                return NotFound();
            }
            return Ok(controls);
        }

        // GET: api/Controls/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Control>> GetControl(int id)
        {
            var control = await _controlService.GetControlById(id);
            if (control == null)
            {
                return NotFound();
            }
            return Ok(control);
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

            try
            {
                await _controlService.UpdateControl(control);
            }
            catch (Exception)
            {
                if (!await _controlService.ControlExists(id))
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
            try {                 
                await _controlService.CreateControl(control);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);   
            }

            return CreatedAtAction("GetControl", new { id = control.ControlId }, control);
        }

        // DELETE: api/Controls/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteControl(int id)
        {
            var control = await _controlService.GetControlById(id);
            if (control == null)
            {
                return NotFound();
            }

            await _controlService.DeleteControl(control.ControlId);

            return NoContent();
        }
    }
}
