using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AstroPhotographyHelperService.Interfaces;
using AstroPhotographyHelperService.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace AstroPhotographyHelperService.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class RequestController : ControllerBase
    {

        #region Private Fields
        private readonly ILocationRequestService lrService;
        #endregion

        public RequestController(ILocationRequestService locationRequestService)
        {
            lrService = locationRequestService;
        }

        [HttpGet]
        public RequestResponseModel GetBestLocations([FromBody] LocationRequestModel request)
        {
            if (request.Range > 50) return null;
            return lrService.GetBestLocationsFromRequest(request);
        }

        /// <summary>
        /// Just to test if API can be accessed
        /// </summary>
        /// <returns></returns>
        [HttpGet("test")]
        public string SimpleTest()
        {
            return "Hello from the AstrophotographyHelperService!";
        }
    }
}
