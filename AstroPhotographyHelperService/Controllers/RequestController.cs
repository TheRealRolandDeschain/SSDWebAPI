using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace AstroPhotographyHelperService.Controllers
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

        //public RequestController(ILogger<RequestController> logger)
        //{
        //    _logger = logger;
        //}

        [HttpGet]
        public string Get()
        {
            return "Hello World";
        }
    }
}
