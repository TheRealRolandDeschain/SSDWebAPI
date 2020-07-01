using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using AstroPhotographyHelperService.Services;
using AstroPhotographyHelperService.Models;
using AstroPhotographyHelperService.Interfaces;
using System.Security.Claims;

namespace AstroPhotographyHelperService.Controllers
{

    [Authorize]
    [ApiController]
    [Route("[controller]")]
    public class UsersController : ControllerBase
    {
        #region Private Fields
        private readonly IUserService userService;
        #endregion

        public UsersController(IUserService UserService)
        {
            userService = UserService;
        }

        [AllowAnonymous]
        [HttpPost("authenticate")]
        public IActionResult Login([FromBody]AuthenticateRequestModel model)
        {
            string response = userService.Authenticate(model);

            if (response == null)
                return BadRequest(new { message = "Username or password is incorrect" });

            return Ok(response);
        }

        [AllowAnonymous]
        [HttpPost]
        public IActionResult CreateUser([FromBody]UserModel user)
        {
            string response = userService.CreateNewUser(user);

            if (string.IsNullOrEmpty(response))
                return BadRequest(new { message = "Invalid Parameters" });
            else if (response == "-1")
                return Conflict(new { message = "User already exists" });
            return Ok("Success!");
        }

        [HttpGet]
        public string Test()
        {
            return User.Identity.Name;
        }

    }
}
