using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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
        public WikiArticleSanitizedModel Get(string search)
        {
            if (string.IsNullOrEmpty(search)) return null;
            var result = WikiApiAccessHelper.LoadArticleInfo(search).Result;
            return result;
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
