using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WikipediaHelperService.Models;

namespace WikipediaHelperService.Controllers
{
    /// <summary>
    /// Controller for all sanitized Wikipedia API requests
    /// </summary>
    public class RequestController : ApiController
    {

        /// <summary>
        /// std Get request
        /// </summary>
        /// <returns></returns>
        public List<string> Get(string search)
        {
            if (String.IsNullOrEmpty(search)) return null;
            return WikiAPIAccessModel.MakeWikiRequest(search);
        }
    }
}