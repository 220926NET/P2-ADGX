using Microsoft.AspNetCore.Mvc;
using Models;
using BusinessLogicLayer;

namespace api_Flare.Controllers
{

    [Route("api/[controller]")]

    public class AuthController : Controller
    {
        private readonly IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpPost]
        [Route("register/")]
        public ActionResult Register([FromBody]User user)
        {
            int id = _authService.Register(user.Username, user.Password);
            if (id != -1)
                return Created("", $"Registration successful. ID:{id}");
            else
                return Unauthorized("Username already exists");
        }


        [HttpPost]
        [Route("login/")]
        public ActionResult Login(User user)
        {
            User login = _authService.Login(user.Username, user.Password);
            if (login.Id != 0)
                return Accepted(login);
            else
                return Unauthorized("Invalid login");
        }
    }
}
