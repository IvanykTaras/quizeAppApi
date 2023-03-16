using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using quizeAppApi.Models;
using quizeAppApi.Services;

namespace quizeAppApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class QuizeController : ControllerBase
    {
        private readonly CategoryService _categoryService;
        public QuizeController(CategoryService categoryService) {
            _categoryService = categoryService;        
        }

        [HttpGet]
        public async Task<List<Category>> GetCategory()
            => await _categoryService.GetAsync();

        [HttpGet("{id:length(24)}")]
        public async Task<ActionResult<Category>> GetCategory(string id) { 
            Category category = await _categoryService.GetAsync(id);

            if (category is null)
            {
                return NotFound();
            }
            

            return category;
        }

        [HttpPost]
        public async Task<ActionResult> CreateCategory(Category category)
        {
            await _categoryService.CreateAsync(category);
            
            return CreatedAtAction(nameof(GetCategory), new { id = category.Id }, category);
        }

        [HttpPut("{id:length(24)}")]
        public async Task<ActionResult> UpdateCategory(string id, Category category)
        {
            var find = await _categoryService.GetAsync(id);
            if ( find is null)
            {
                return NotFound();
            }

            await _categoryService.UpdateAsync(id, category);
            return NoContent();
        }

        [HttpDelete("{id:length(24)}")]
        public async Task<ActionResult> DeleteCategory(string id)
        {
            var find = _categoryService.GetAsync(id);

            if (find is null) {
                return NotFound();
            }

            return NoContent();
        }


    }
}
