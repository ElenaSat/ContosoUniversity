using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using ContosoUniversity.API.DTOs;
using ContosoUniversity.API.Models;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using System.Security.Claims;
using System.IdentityModel.Tokens.Jwt;

namespace ContosoUniversity.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [AllowAnonymous]
    public class LoginController : ControllerBase
    {
        private readonly IConfiguration configuration;
        public LoginController(IConfiguration configuration)
        {
            this.configuration = configuration;
        }

        [HttpGet]
        [Route("echoPing")]
        public async Task<IActionResult> EchoPing()
        {
            return Ok(true);
        }

        [HttpPost]
        public async Task<IActionResult> Authenticate(UserDTO userDTO)
        {
            if (userDTO == null)
                return BadRequest();

            bool isCredentialValid = (userDTO.Password == "123456");

            if (isCredentialValid)
            {
                var user = new User
                {
                    Id = Guid.NewGuid(),
                    UserName = "ElenaSat",
                    Email = "franciaemp1998@gmail.com"
                };
                var token = GenerateTokenJwt(user);
                return Ok(token);
            }
            else
            {
                return Unauthorized();
            }
        }

        private string GenerateTokenJwt(User user)
        {
            //appsettings JWT
            var secretKey = configuration["JWT:SECRET_KEY"];
            var audienceToken = configuration["JWT:AUDIENCE_TOKEN"];
            var issuerToken = configuration["JWT:ISSUER_TOKEN"];
            var expireTime = configuration["JWT:EXPIRE_MINUTES"];

            //header
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secretKey));
            var siginCredentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
            var header = new JwtHeader(siginCredentials);

            //claims
            var claimsIdentity = new[]
            {
                new Claim(JwtRegisteredClaimNames.Jti,Guid.NewGuid().ToString()),
                new Claim(JwtRegisteredClaimNames.NameId,user.Id.ToString()),
                new Claim(ClaimTypes.Name,user.UserName),
                new Claim(JwtRegisteredClaimNames.Email, user.Email)
            };

            var payload = new JwtPayload(issuer: issuerToken,
                audience: audienceToken,
                claims: claimsIdentity,
                notBefore: DateTime.UtcNow,
                expires: DateTime.UtcNow.AddMinutes(Convert.ToInt32(expireTime)));

            var token = new JwtSecurityToken(header, payload);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}