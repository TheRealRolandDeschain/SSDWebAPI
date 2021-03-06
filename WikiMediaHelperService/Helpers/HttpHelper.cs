﻿using System;
using System.Net.Http;
using System.Net.Http.Headers;

namespace WikiMediaHelperService.Helpers
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
        /// <summary>
        /// Initializes the Http Client
        /// </summary>
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