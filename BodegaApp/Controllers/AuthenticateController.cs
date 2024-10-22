using Common.Dtos;
using Data.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Service;
using System.IdentityModel.Tokens.Jwt;
using System.Net;
using System.Security.Claims;
using System.Text;

namespace BodegaApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        private readonly UserService _userService;

        public AuthenticationController(IConfiguration configuration, UserService userService)
        {
            _configuration = configuration;
            _userService = userService;
        }

        [HttpPost]
        public IActionResult Authenticate([FromBody] LoginDto dto)
        {
            User? userAuthenticate = _userService.AuthenticateUser(dto.Username, dto.Password);

            if (userAuthenticate is not null)
            {
                var securityPassword = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(_configuration["Authentication:SecretForKey"]));

                var credentials = new SigningCredentials(securityPassword, SecurityAlgorithms.HmacSha256);

                var claimsForToken = new List<Claim>();
                claimsForToken.Add(new Claim("sub", userAuthenticate.Id.ToString()));
                claimsForToken.Add(new Claim("given_name", userAuthenticate.Username));

                var jwtSecurityToken = new JwtSecurityToken(
                  _configuration["Authentication:Issuer"],
                  _configuration["Authentication:Audience"],
                  claimsForToken,
                  DateTime.UtcNow,
                  DateTime.UtcNow.AddMinutes(int.Parse(_configuration["Authentication:MinutesToExpire"]!)),
                  credentials);

                var tokenToReturn = new JwtSecurityTokenHandler()
                    .WriteToken(jwtSecurityToken);

                return Ok(tokenToReturn);
            }
            return Unauthorized();
        }
    }

}