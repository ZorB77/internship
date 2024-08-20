using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using WebApplication1.Data;
using WebApplication1.DTOs;
using WebApplication1.Exceptions;
using WebApplication1.Middleware;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly DataContext _context;
        private readonly IConfiguration _configuration;

        public UsersController(DataContext context,IConfiguration configuration ) {
            _context = context;
            _configuration = configuration;
    }

        [HttpPost]
        [Route("Register")]
        public IActionResult Register(UserDTO userDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var objUser = _context.Users.FirstOrDefault(x => x.Email == userDTO.Email);
            if (objUser != null)
            {
                throw new UserAlreadyExistsException("User with this email already exists");
            }
            
                var hashedPassword = BCrypt.Net.BCrypt.HashPassword(userDTO.Password);

                var newUser = new User
                {
                    FirstName = userDTO.FirstName,
                    LastName = userDTO.LastName,
                    Email = userDTO.Email,
                    Password = hashedPassword
                };
                _context.Users.Add(newUser);
                _context.SaveChanges();

                var claims = new[]
               {
                    new Claim(JwtRegisteredClaimNames.Sub, _configuration["Jwt:Subject"]),
                    new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                    new Claim("UserId", newUser.Id.ToString()),
                    new Claim("UserEmail", newUser.Email.ToString())
                };

                var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
                var signIn = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
                var token = new JwtSecurityToken(
                    _configuration["Jwt:Issuer"],
                    _configuration["Jwt:Audience"],
                    claims,
                    expires: DateTime.UtcNow.AddDays(1),
                    signingCredentials: signIn
                    );
                string tokenValue = new JwtSecurityTokenHandler().WriteToken(token);
                return Ok(new { Token = tokenValue, User = newUser });
            
          
        }

        [HttpPost]
        [Route("Login")]
        public IActionResult Login(Login login)
        {
            var user = _context.Users.FirstOrDefault(x => x.Email == login.Email);
            if (user != null && BCrypt.Net.BCrypt.Verify(login.Password, user.Password))
            {
                var claims = new[]
                {
                    new Claim(JwtRegisteredClaimNames.Sub, _configuration["Jwt:Subject"]),
                    new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                    new Claim("UserId", user.Id.ToString()),
                    new Claim("UserEmail", user.Email.ToString())
                };

                var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
                var signIn = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
                var token = new JwtSecurityToken(
                    _configuration["Jwt:Issuer"],
                    _configuration["Jwt:Audience"],
                    claims,
                    expires: DateTime.UtcNow.AddDays(1),
                    signingCredentials: signIn
                    );
                string tokenValue = new JwtSecurityTokenHandler().WriteToken(token);
                return Ok(new {Token = tokenValue, User = user});   
              //  return Ok(User);
            }
            else
            {
                return NoContent();
            }

        }
        [Authorize]
            [HttpGet] 
            [Route("GetUsers")]
     public IActionResult GetUsers()
        {
            return Ok(_context.Users.ToList());
        }
        [HttpGet]
        [Route("GetUser")]
        public IActionResult GetUser(int id)
        {
            var user = _context.Users.FirstOrDefault(u => u.Id == id);
            if (user == null)
            {
                throw new EntityNotFoundException($"User with id: {id} not found!");
            }
            else
            {
                return Ok(user);
            }
        }

    }

   
}
