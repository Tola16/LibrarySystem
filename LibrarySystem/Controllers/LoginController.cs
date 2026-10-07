using System.Drawing.Imaging;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Transactions;
using LibrarySystem.Dto;
using LibrarySystem.Models;
using LibrarySystem.UnitOfWorks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

namespace LibrarySystem.Controllers
{
    [AllowAnonymous]
    [ApiController]
    [Route("api/[controller]")]

    public class LoginController : ControllerBase
    {
        IUnitOfWork _context;
        IConfiguration _configuration;
        public LoginController(IUnitOfWork unit , IConfiguration configuration)
        {
            _context= unit;
            _configuration= configuration;
        }

        [HttpPost("Login")]
        public IActionResult Login (LoginDto dto)
        {
            var user = _context.Users.GetByName(dto.UserName);
            if (user == null || user.PassWordHash != dto.PassWord)
            {
                return Unauthorized("PassWord Or UserName Is Wrong ") ;
            }
            var token = GenerateToken(user);
            return Ok(new {token} );

        }

        private string GenerateToken(User user)
        {
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
            var creds = new SigningCredentials(key,SecurityAlgorithms.HmacSha256);
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier , user.Id.ToString()),
                new Claim (ClaimTypes.Name , user.Name),
            };
            var token = new JwtSecurityToken(
                issuer : _configuration["Jwt:Issuer"],
                audience: _configuration["Jwt:Audience"],
                claims: claims ,
                expires : DateTime.Now.AddHours(2),
                signingCredentials : creds  


                );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        


    }
}
