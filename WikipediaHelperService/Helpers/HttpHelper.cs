using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web;

namespace WikipediaHelperService.Helpers
{
    public static class HttpHelper
    {
        #region Private Properties
        private const string URL = "https://en.wikipedia.org/w/api.php/";
        #endregion

        #region Public Properties
        public static HttpClient WikiClient { get; set; }
        #endregion

        #region Construtor
        static HttpHelper()
        {
            InitClient();
        }
        #endregion

        #region Private Methods
        private static void InitClient()
        {
            WikiClient = new HttpClient
            {
                BaseAddress = new Uri(URL)
            };
            WikiClient.DefaultRequestHeaders.Accept.Clear();
            WikiClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }
        #endregion
    }
}