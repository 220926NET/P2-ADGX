using BusinessLogicLayer.Services.AuthService;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Models;
using NuGet.Common;
using System.Configuration;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace api_Flare.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService authService;
        private readonly IConfiguration configuration;
        private readonly AuthSettings authSettings;

        public AuthController(IAuthService authService, IConfiguration configuration, IOptions<AuthSettings> authSettings)
        {
            this.authService = authService;
            this.configuration = configuration;
            this.authSettings = authSettings.Value;
        }

        // GET: api/<AuthController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<AuthController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<AuthController>
        [HttpPost, Route("login")]
        public IActionResult Post([FromBody] User user)
        {
            if(user == null)
            {
                return BadRequest("Invalid client request");
            }
            if(authService.TestPassword(user.Username, user.Password)){
                var secretKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(authSettings.AuthSecretKey));
                var signingCredentials = new SigningCredentials(secretKey, SecurityAlgorithms.HmacSha256);

                var tokenOptions = new JwtSecurityToken(
                    issuer: authSettings.Issuer,
                    audience: authSettings.Audience,
                    claims: new List<Claim>(),
                    expires: DateTime.Now.AddMinutes(10),
                    signingCredentials: signingCredentials
                    );
                var tokenString = new JwtSecurityTokenHandler().WriteToken(tokenOptions);
                return Ok(new { Token = tokenString });
            }
            return Unauthorized();
        }

        // PUT api/<AuthController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<AuthController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
