using MeusicRuchama.Core.Serivecs;
using MeusicRuchama.Models.User;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace MeusicRuchama.Controllers
{
    [EnableCors("AllowFrontend")]
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        private readonly IUserService _userService;

        public AuthController(IConfiguration configuration, IUserService userService)
        {
            _configuration = configuration;
            _userService = userService;
        }
        [AllowAnonymous]
        [HttpPost("login")]
        [HttpOptions("login")]
        public async Task<IActionResult> Login([FromBody] LoginModel loginModel)
        {
            Response.Headers.Add("Access-Control-Allow-Origin", "http://localhost:8080");
            var user = await _userService.GetByUserNameAsync(loginModel.UserName, loginModel.Password);

            if (user == null)
                return Unauthorized();

            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, user.UserName),
                new Claim(ClaimTypes.Role, user.Role.ToString())
            };

            var secretKey = new SymmetricSecurityKey(
                Encoding.UTF8.GetBytes(_configuration["JWT:Key"])
            );

            var signinCredentials = new SigningCredentials(
                secretKey,
                SecurityAlgorithms.HmacSha256
            );

            var tokenOptions = new JwtSecurityToken(
                issuer: _configuration["JWT:Issuer"],
                audience: _configuration["JWT:Audience"],
                claims: claims,
                expires: DateTime.Now.AddMinutes(30),
                signingCredentials: signinCredentials
            );

            var tokenString = new JwtSecurityTokenHandler().WriteToken(tokenOptions);

            return Ok(new
            {
                token = tokenString,
                user = new
                {
                    id = user.Id,
                    userName = user.UserName,
                    role = user.Role
                }
            });
        }
    }
}
