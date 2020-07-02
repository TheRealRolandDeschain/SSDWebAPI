using System.Collections.Generic;
using AstroPhotographyHelperService.Interfaces;
using AstroPhotographyHelperService.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AstroPhotographyHelperService.Controllers
{
    [Route("[controller]")]
    [Authorize]
    [ApiController]
    public class DatabaseController : ControllerBase
    {

        #region Private Fields
        private readonly IDatabaseService databaseService;
        #endregion

        public DatabaseController(IDatabaseService DatabaseService)
        {
            databaseService = DatabaseService;
        }

        [HttpGet]
        [AllowAnonymous]
        public List<LocationModel> GetLocationsByArea(float longleft, float longright, float lattop, float latbottom)
        {
            return databaseService.GetLocationsByArea(longleft, longright, lattop, latbottom);
        }


        [HttpPost]
        public IActionResult CreateNewLocation([FromBody]LocationModel location)
        {
            location.UserName = User.Identity.Name;

            string response = databaseService.AddLocation(location);

            if (string.IsNullOrWhiteSpace(response))
                return BadRequest(new { message = "Invalid Parameters" });
            else if (response == "-1")
                return Conflict(new { message = "Location already exists" });
            return Ok("Success!");
        }

        [HttpGet("{locationname}")]
        [AllowAnonymous]
        public LocationModel GetUserByUserName(string locationname)
        {
            LocationModel location = databaseService.GetLocationByName(locationname);

            return location;
        }

        // not yet implemented 
        //[HttpPut("{locationname}")]
        //public IActionResult UpdateUserByUserName([FromBody]LocationModel location)
        //{
        //    string response = databaseService.UpdateLocationByUserName(location);

        //    if (string.IsNullOrWhiteSpace(response))
        //        return BadRequest(new { message = "Invalid Parameters" });
        //    else if (response == "-1")
        //        return Conflict(new { message = "User doesn't exists" });
        //    return Ok(new { message = $"Successfully updated location {location.Name}" });
        //}

        [HttpDelete("{locationname}")]
        public IActionResult DeleteUserByUserName(string locationname)
        {
            string response = databaseService.DeleteLocationByName(locationname);

            if (response == "-1")
                return Conflict(new { message = "User doesn't exists" });
            return Ok(new { message = $"Successfully deleted location {locationname}" });
        }
    }
}
