using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace ContosoUniversity.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [AllowAnonymous]
    public class LoginController : ControllerBase
    {
        private readonly IConfiguration configuration;
        public LoginController(IConfiguration configuration) {
            this.configuration = configuration;
        }

        [HttpGet]
        [Route("echoping")]
        public async Task<IActionResult> EchoPing() {
            return  Ok(true);
        }

        //private string GenerateTokenJwt(User user) {
        //    var secretKey = configuration["JWT:SECRET_KEY"];
        //    var audienceToken= configuration["JWT"]
        //}
    }
}