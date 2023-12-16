using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TradeApi.Tables;

namespace TradeApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CategoryController : ControllerBase
    {
        private readonly AppDbContext _context;
        public CategoryController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Category>>> GetCategories()
        {
            return await _context.category.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<IEnumerable<Category>>> GetMoreCategoryById(int id)
        {
            var category = await _context.category.FindAsync(id);

            if (category == null)
            {
                return NotFound();
            }

            return Ok(category);
        }

        [HttpPost]
        public async Task<ActionResult<Category>> CreateCategory(Category categories)
        {
            _context.category.Add(categories);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(CreateCategory), new { id = categories.id }, categories);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteCategory(int id)
        {
            var category = await _context.category.FindAsync(id);
            if (category == null)
            {
                return NotFound();
            }
            _context.category.Remove(category);
            await _context.SaveChangesAsync();
            return NoContent();
        }

        [HttpPut]
        public async Task<ActionResult> UpdateCategoryes(Category category)
        {
            _context.category.Update(category);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}
