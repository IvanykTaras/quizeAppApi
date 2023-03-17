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
        private readonly QuestionService _questionService;
        public QuizeController(CategoryService categoryService, QuestionService questionService)
        {
            _categoryService = categoryService;
            _questionService = questionService;
        }

        //================
        //Category Methods
        //================

        [HttpGet("category/")]
        public async Task<List<Category>> GetCategory()
            => await _categoryService.GetAsync();

        [HttpGet("category/question/{id:length(24)}")]
        public async Task<List<Question>> GetQuestions(string id) 
            => await _categoryService.GetQuestionsAsync(id);

        [HttpGet("category/{id:length(24)}")]
        public async Task<ActionResult<Category>> GetCategory(string id) { 
            var category = await _categoryService.GetAsync(id);

            if (category is null)
            {
                return NotFound();
            }
            

            return category;
        }

        [HttpPost("category/")]
        public async Task<ActionResult> CreateCategory(Category category)
        {
            await _categoryService.CreateAsync(category);
            
            return CreatedAtAction(nameof(GetCategory), new { id = category.Id }, category);
        }

        [HttpPut("category/{id:length(24)}")]
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

        [HttpDelete("category/{id:length(24)}")]
        public async Task<ActionResult> DeleteCategory(string id)
        {
            var find = await _categoryService.GetAsync(id);
            
            if (find is null) {
                return NotFound();
            }

            await _categoryService.RemoveAsync(id);

            return NoContent();
        }

        //================
        //Question Methods
        //================

        [HttpGet("question/")]
        public async Task<List<Question>> GetQuestion()
            => await _questionService.GetAsync();

        [HttpGet("question/{id:length(24)}")]
        public async Task<ActionResult<Question>> GetQuestion(string id)
        {
            var question = await _questionService.GetAsync(id);

            if (question is null)
            {
                return NotFound();
            }

            return question;
        }

        [HttpPost("question/")]
        public async Task<ActionResult> CreateQuestion(Question question)
        {
            await _questionService.CreateAsync(question);

            return CreatedAtAction(nameof(GetCategory), new { id = question.Id }, question);
        }

        [HttpPut("question/{id:length(24)}")]
        public async Task<ActionResult> UpdateQuestion(string id, Question question)
        {
            var find = await _questionService.GetAsync(id);
            if (find is null)
            {
                return NotFound();
            }

            await _questionService.UpdateAsync(id, question);
            return NoContent();
        }

        [HttpDelete("question/{id:length(24)}")]
        public async Task<ActionResult> DeleteQuestion(string id)
        {
            var find = await _questionService.GetAsync(id);

            if (find is null)
            {
                return NotFound();
            }

            await _questionService.RemoveAsync(id);

            return NoContent();
        }


    }
}
