using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CelestialBodyHelperService.Models;
using CelestialBodyHelperService.Helpers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace CelestialBodyHelperService.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class RequestController : ControllerBase
    {
        //private static readonly string[] Summaries = new[]
        //{
        //    "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        //};

        //private readonly ILogger<RequestController> _logger;

        [HttpGet]
        public BodyInfoModel Get(double ra, double de, int angle)
        {
            return BodyDataProvider.GetBodyData(ra, de, angle);
        }

        /// <summary>
        /// Just to test if API can be accessed
        /// </summary>
        /// <returns></returns>
        [HttpGet("test")]
        public string SimpleTest()
        {
            return "Hello from the CelestialBodyHelperService!";
        }
    }
}
