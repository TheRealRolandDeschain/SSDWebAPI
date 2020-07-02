using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using WikiMediaHelperService.Helpers;
using WikiMediaHelperService.Models;

namespace WikiMediaHelperService.Controllers
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
            var result = WikiApiAccessHelper.LoadArticleInfo(search.Replace(" ", "%20")).Result;
            return result;
        }


        /// <summary>
        /// Just to test if API can be accessed
        /// </summary>
        /// <returns></returns>
        [HttpGet("test")]
        public string SimpleTest()
        {
            return "Hello from the WikiMediaHelperService!";
        }
    }
}