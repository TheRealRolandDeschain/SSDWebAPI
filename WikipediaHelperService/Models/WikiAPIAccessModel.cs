using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Http.Formatting;
using System.Threading.Tasks;

namespace WikipediaHelperService.Models
{
    public class WikiAPIAccessModel
    {
        #region Private Properties
        private const string URL = "https://en.wikipedia.org/w/api.php/";
        private const string urlParameters = "?action=query&format=json&prop=extracts|description|pageimages&explaintext=1&exintro=1&titles=";
        #endregion

        #region Public Properties
        public static HttpClient client = new HttpClient();
        #endregion

        #region Construtor
        #endregion

        #region Private Methods
        #endregion

        #region Public Methods
        public static List<string> MakeWikiRequest(string searchparam)
        {
            List<DataObject> result = new List<DataObject>();
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(URL);

            // Add an Accept header for JSON format.
            client.DefaultRequestHeaders.Accept.Add(
            new MediaTypeWithQualityHeaderValue("application/json"));

            // List data response.
            HttpResponseMessage response = client.GetAsync(urlParameters + searchparam).Result;
            if (response.IsSuccessStatusCode)
            {
                // Parse the response body.
                var dataObjects = response.Content.rea
                result = dataObjects as List<DataObject>;
                Console.WriteLine("cool");

            }
            else
            {
                Console.WriteLine("{0} ({1})", (int)response.StatusCode, response.ReasonPhrase);
            }
            client.Dispose();

            return new List<string>() { };
        }
    }
    #endregion
}
