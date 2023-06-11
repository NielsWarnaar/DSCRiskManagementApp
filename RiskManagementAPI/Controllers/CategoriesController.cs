using Microsoft.AspNetCore.Mvc;
using RiskManagementAPI.Models;
using RiskManagementAPI.Services;

namespace RiskManagementAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly ICategoryService _categoriesService;

        public CategoriesController(ICategoryService categoriesService)
        {
            _categoriesService = categoriesService;
        }

        // GET: api/Categories
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Category>>> GetCategories()
        {
            var categories = await _categoriesService.GetCategories();
            if (categories == null)
            {
                return NotFound();
            }
            return Ok(categories);
        }

        // GET: api/Categories/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Category>> GetCategory(int id)
        {
            var category = await _categoriesService.GetCategoryById(id);
            if (category == null)
            {
                return NotFound();
            }
            return Ok(category);
        }

        // PUT: api/Categories/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCategory(int id, Category category)
        {
            if (id != category.CategoryId)
            {
                return BadRequest();
            }

            try
            {
                await _categoriesService.UpdateCategory(category);
            }
            catch (Exception)
            {
                if (!await _categoriesService.CategoryExists(id))
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

        // POST: api/Categories
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Category>> PostCategory(Category category)
        {
            try
            {
                await _categoriesService.CreateCategory(category);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

            return CreatedAtAction("GetCategory", new { id = category.CategoryId }, category);
        }

        // DELETE: api/Categories/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCategory(int id)
        {
            var category = await _categoriesService.GetCategoryById(id);
            if (category == null)
            {
                return NotFound();
            }
            await _categoriesService.DeleteCategory(category.CategoryId);

            return NoContent();
        }
    }
}
