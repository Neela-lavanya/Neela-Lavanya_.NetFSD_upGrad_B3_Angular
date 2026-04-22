using BackendProject.Data;
using BackendProject.DTOs;
using BackendProject.Models;
using BackendProject.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BackendProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticateController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly JwtService _jwtService;

        public AuthenticateController(ApplicationDbContext context, JwtService jwtService)
        {
            _context = context;
            _jwtService = jwtService;
        }

        // REGISTER
        [HttpPost("register")]
        public async Task<IActionResult> Register(RegisterDTO dto)
        {
            if (dto == null)
                return BadRequest("Invalid data");

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var exists = _context.Users.Any(x => x.Email == dto.Email);

            if (exists)
                return BadRequest("Email already exists");

            var user = new User
            {
                Name = dto.Name,
                Email = dto.Email,
                Password = dto.Password,
                Role = dto.Role
            };

            await _context.Users.AddAsync(user);
            await _context.SaveChangesAsync();

            return Ok("User registered successfully");
        }

        // LOGIN
        [HttpPost("login")]
        public IActionResult Login(LoginDTO dto)
        {
            if (dto == null)
                return BadRequest("Invalid data");

            var user = _context.Users
                .FirstOrDefault(x => x.Email == dto.Email && x.Password == dto.Password);

            if (user == null)
                return BadRequest("Invalid credentials");

            var token = _jwtService.GenerateToken(user);

            return Ok(new { token });
        }
    }
}
