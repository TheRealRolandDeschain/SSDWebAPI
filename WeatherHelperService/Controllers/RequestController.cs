using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using WeatherHelperService.Helpers;
using WeatherHelperService.Models;

namespace WeatherHelperService.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class RequestController : ControllerBase
    {

        //private readonly ILogger<RequestController> _logger;

        //public RequestController(ILogger<RequestController> logger)
        //{
        //    _logger = logger;
        //}

        [HttpGet]
        public WeatherInfoModel Get(DateTime starttime, DateTime endtime, string latitude, string longitude)
        {
            return WeatherDataProvider.GetWeatherData(starttime, endtime, latitude, longitude);
        }

        /// <summary>
        /// Just to test if API can be accessed
        /// </summary>
        /// <returns></returns>
        [HttpGet("test")]
        public string SimpleTest()
        {
            return "success";
        }
    }
}
