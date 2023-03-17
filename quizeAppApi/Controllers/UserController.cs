using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using quizeAppApi.Models;
using quizeAppApi.Services;

namespace quizeAppApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private UserService _userService;
        public UserController(UserService service)
        {
            _userService = service;
        }

        //================
        //User Methods
        //================

        [HttpGet]
        public async Task<List<User>> GetUser()
            => await _userService.GetAsync();

        
        [HttpGet("{id:length(24)}")]
        public async Task<ActionResult<User>> GetUser(string id)
        {
            var user = await _userService.GetAsync(id);

            if (user is null)
            {
                return NotFound();
            }


            return user;
        }

        [HttpPost]
        public async Task<ActionResult> CreateCategory(User user)
        {
            await _userService.CreateAsync(user);

            return CreatedAtAction(nameof(GetUser), new { id = user.Id }, user);
        }

        [HttpPut("{id:length(24)}")]
        public async Task<ActionResult> UpdateCategory(string id, User user)
        {
            var find = await _userService.GetAsync(id);
            if (find is null)
            {
                return NotFound();
            }

            await _userService.UpdateAsync(id, user);
            return NoContent();
        }

        [HttpDelete("category/{id:length(24)}")]
        public async Task<ActionResult> DeleteCategory(string id)
        {
            var find = await _userService.GetAsync(id);

            if (find is null)
            {
                return NotFound();
            }

            await _userService.RemoveAsync(id);

            return NoContent();
        }

    }
}
