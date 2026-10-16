using BCrypt.Net;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using POE_PART2_.Data;
using POE_PART2_.Models;

namespace POE_PART2_.RaceDayAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsersController : ControllerBase
    {
        private readonly RaceDayContext _context;

        public UsersController(RaceDayContext context)
        {
            _context = context;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register(User user)
        {
            if (_context.Users.Any(u => u.Email == user.Email))
            {
                return BadRequest("Email already exists.");
            }

            user.PasswordHash =
                BCrypt.Net.BCrypt.HashPassword(user.PasswordHash);

            _context.Users.Add(user);

            await _context.SaveChangesAsync();

            return Ok(user);
        }

        [HttpPost("login")]
        public IActionResult Login(string email, string password)
        {
            var user = _context.Users
                .SingleOrDefault(u => u.Email == email);

            if (user == null)
            {
                return Unauthorized();
            }

            bool validPassword = BCrypt.Net.BCrypt.Verify(
                password,
                user.PasswordHash);

            if (!validPassword)
            {
                return Unauthorized();
            }

            return Ok(new
            {
                Token = "jwt-token-placeholder",
                Role = user.Role
            });
        }

        [Authorize]
        [HttpGet("profile")]
        public async Task<IActionResult> GetProfile()
        {
            var email = User.Identity?.Name;

            var user = await _context.Users
                .FirstOrDefaultAsync(u => u.Email == email);

            return Ok(user);
        }
    }
}