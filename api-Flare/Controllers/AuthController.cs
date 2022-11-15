using BusinessLogicLayer.Services.AuthService;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Models;
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



        [HttpPost, Route("register")]
        public ActionResult Register([FromForm] User user)
        {
            if (authService.Register(user.Username, user.Password))
            {
                return Ok();
            }
            else
            {
                return BadRequest();
            }

        }


        // POST api/<AuthController>
        [HttpPost, Route("login")]
        public IActionResult login([FromForm] User user)
        {
            if (user == null)
            {
                return BadRequest("Invalid client request");
            }
            if (authService.TestPassword(user.Username, user.Password))
            {
                User loggedIn = authService.Login(user.Username, user.Password);

                var secretKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(authSettings.AuthSecretKey));
                var signingCredentials = new SigningCredentials(secretKey, SecurityAlgorithms.HmacSha256);

                var tokenOptions = new JwtSecurityToken(
                    issuer: authSettings.Issuer,
                    audience: authSettings.Audience,
                    claims: new List<Claim>{
                        new Claim(ClaimTypes.Name, loggedIn.Username),
                        new Claim(ClaimTypes.Sid, loggedIn.UserId.ToString())
                    },
                    expires: DateTime.Now.AddMinutes(10),
                    signingCredentials: signingCredentials
                    );
                var tokenString = new JwtSecurityTokenHandler().WriteToken(tokenOptions);
                return Ok(tokenString);
            }
            return Unauthorized();
        }

    }
}
