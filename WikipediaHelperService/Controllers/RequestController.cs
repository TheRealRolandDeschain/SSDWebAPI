using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

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
        public IEnumerable<string> Get()
        {
            return new string[] { "depp", "bleder" };
        }

        /// <summary>
        /// std Get request with additional parameter
        /// </summary>
        public string Get(int id)
        {
            return "value";
        }

        /// <summary>
        /// std Post request
        /// </summary>
        public void Post([FromBody]string value)
        {
        }

        /// <summary>
        /// std Put request
        /// </summary>
        public void Put(int id, [FromBody]string value)
        {
        }

        /// <summary>
        /// std Delete request
        /// </summary>
        public void Delete(int id)
        {
        }
    }
}