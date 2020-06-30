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
        private IUserService _userService;

        public UsersController(IUserService userService)
        {
            _userService = userService;
        }

        [AllowAnonymous]
        [HttpPost("authenticate")]
        public IActionResult Login([FromBody]AuthenticateRequestModel model)
        {
            var response = _userService.Authenticate(model);

            if (response == null)
                return BadRequest(new { message = "Username or password is incorrect" });

            return Ok(response);
        }

        [HttpGet]
        public string Test()
        {
            return User.Identity.Name;
        }

    }
}
