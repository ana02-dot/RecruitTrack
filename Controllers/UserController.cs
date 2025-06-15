using JobSeekerAPI.Dtos;
using JobSeekerAPI.Models;
using JobSeekerAPI.Services;
using Microsoft.AspNetCore.Mvc;

namespace JobSeekerAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        public UserController(IUserService userService)
        {
            _userService = userService;
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var users = await _userService.GetAllUsersAsync();
            return Ok(users);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var user = await _userService.GetUserByIdAsync(id);
            return user == null ? NotFound() : Ok(user);
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateUserDto dto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var user = new User
            {
                FirstName = dto.FirstName,
                LastName = dto.LastName,
                Email = dto.Email,
                HashedPassword = dto.Password,
                Role = dto.Role
            };

            var success = await _userService.CreateUserAsync(user);
            return success ? CreatedAtAction(nameof(GetById), new { id = user.Id }, user) : StatusCode(500);
        }
        [HttpGet("email/{email}")]
        public async Task<IActionResult> GetByEmail(string email)
        {
            var user = await _userService.GetUserByEmailAsync(email);
            return Ok("User role is " + user.Role);
        }
    }
}
