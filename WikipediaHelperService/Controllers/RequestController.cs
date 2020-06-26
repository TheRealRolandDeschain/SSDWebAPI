using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WikipediaHelperService.Helpers;
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
        public WikiArticleSanitizedModel Get(string search)
        {
            var result = WikiApiAccessHelper.LoadArticleInfo(search).Result;
            return result;
        }
    }
}