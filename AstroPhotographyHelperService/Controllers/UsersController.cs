using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using AstroPhotographyHelperService.Models;
using AstroPhotographyHelperService.Interfaces;

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
        [HttpPost("login")]
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

            if (string.IsNullOrWhiteSpace(response))
                return BadRequest(new { message = "Invalid Parameters" });
            else if (response == "-1")
                return Conflict(new { message = "User already exists" });
            return Ok("Success!");
        }

        [HttpGet("{username}")]
        public UserModel GetUserByUserName(string username)
        {
            if (User.Identity.Name != username) return null;
            UserModel user = userService.GetUserByUserName(username);

            return user;
        }

        [HttpPut("{username}")]
        public IActionResult UpdateUserByUserName([FromBody]UserModel user)
        {
            if (User.Identity.Name != user.Username) return null;

            string response = userService.UpdateUserByUserName(user);

            if (string.IsNullOrWhiteSpace(response))
                return BadRequest(new { message = "Invalid Parameters" });
            else if (response == "-1")
                return Conflict(new { message = "User doesn't exists" });
            return Ok(new { message = $"Successfully updated user {user.Username}" });
        }

        [HttpDelete("{username}")]
        public IActionResult DeleteUserByUserName(string username)
        {
            if (User.Identity.Name != username) return null;
            string response = userService.DeleteUserByUserName(username);

            if (response == "-1")
                return Conflict(new { message = "User doesn't exists" });
            return Ok(new { message = $"Successfully deleted user {username}" });
        }
    }
}
