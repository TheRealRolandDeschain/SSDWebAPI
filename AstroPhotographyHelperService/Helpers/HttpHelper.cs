using System;
using System.Net.Http;
using System.Net.Http.Headers;

namespace AstroPhotographyHelperService.Helpers
{
    public static class HttpHelper
    {
        #region Private Properties
        #endregion

        #region Public Properties
        public static HttpClient HelperClient { get; set; }
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
            HelperClient = new HttpClient();
            HelperClient.DefaultRequestHeaders.Accept.Clear();
            HelperClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }
        #endregion
    }
}