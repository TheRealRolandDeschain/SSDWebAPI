using System;
using System.Net.Http;
using System.Net.Http.Headers;

namespace MapHelperService.Helpers
{
    public static class HttpHelper
    {
        #region Private Properties
        private const string URL = @"http://overpass-api.de/api/";
        #endregion

        #region Public Properties
        public static HttpClient MapClient { get; set; }
        #endregion

        #region Construtor
        static HttpHelper()
        {
            InitClient();
        }
        #endregion

        #region Private Methods
        /// <summary>
        /// Initializes the Http Client
        /// </summary>
        private static void InitClient()
        {
            MapClient = new HttpClient
            {
                BaseAddress = new Uri(URL)
            };
            MapClient.DefaultRequestHeaders.Accept.Clear();
            MapClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }
        #endregion
    }
}

