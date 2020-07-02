using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MapHelperService.Helpers;
using MapHelperService.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace MapHelperService.Controllers
{
    /// <summary>
    /// Controller for all sanitized Wikipedia API requests
    /// </summary>
    [ApiController]
    [Route("[controller]")]
    public class RequestController : ControllerBase
    {
        //private readonly ILogger<RequestController> _logger;

        //public RequestController(ILogger<RequestController> logger)
        //{
        //    _logger = logger;
        //}

        /// <summary>
        /// std Get request
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public List<ElementModel> Get(string longleft, string longright, string lattop, string latbottom)
        {
            if (String.IsNullOrEmpty(longleft)
                || String.IsNullOrEmpty(longleft)
                || String.IsNullOrEmpty(longleft)
                || String.IsNullOrEmpty(longleft))
            {
                return null;
            }
            BboxModel bbox = new BboxModel
            {
                LongLeft = longleft,
                LongRight = longright,
                LatTop = lattop,
                LatBottom = latbottom
            };
            List<ElementModel> result = MapAPIAccessHelper.LoadNodeInfo(bbox).Result;
            return result;
        }


        /// <summary>
        /// Just to test if API can be accessed
        /// </summary>
        /// <returns></returns>
        [HttpGet("test")]
        public string SimpleTest()
        {
            return "Hello From MapHelperService!";
        }
    }
}
