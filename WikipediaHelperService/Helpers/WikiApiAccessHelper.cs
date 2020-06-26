using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Http.Formatting;
using System.Threading.Tasks;
using WikipediaHelperService.Models;
using System.Linq;

namespace WikipediaHelperService.Helpers
{
    public class WikiApiAccessHelper
    {
        #region Private Properties
        private const string urlParameters = "?action=query&format=json&prop=extracts|description|pageimages&explaintext=1&exintro=1&piprop=original&pithumbsize=800&titles=";
        #endregion

        #region Public Properties
        #endregion

        #region Construtorion
        #endregion

        #region Private Methods
        /// <summary>
        /// Retrieves all the necessary information from the wikimedia api retun model 
        /// and saves it to a smaller model
        /// </summary>
        /// <param name="article"></param>
        /// <returns></returns>
        private static WikiArticleSanitizedModel SanitizeArticleModel(WikiArticleModel article)
        {
            WikiArticleSanitizedModel sanitized = new WikiArticleSanitizedModel();
            var page = article.Query.Pages.FirstOrDefault().Value;
            sanitized.Title = page.Title;
            sanitized.PageId = page.PageId;
            sanitized.Description = page.Description;
            sanitized.Summary = page.Extract;
            sanitized.ImageUrl = page.Original.Source;

            return sanitized;
        }
        #endregion

        #region Public Methods
        /// <summary>
        /// loads the article information based on the search parameter from the
        /// wikimedia api
        /// </summary>
        /// <param name="search"></param>
        /// <returns></returns>
        public static async Task<WikiArticleSanitizedModel> LoadArticleInfo(string search)
        {
            string completeURLParam = urlParameters + search;
            using (HttpResponseMessage response = await HttpHelper.WikiClient.GetAsync(completeURLParam).ConfigureAwait(false))
            {
                if (response.IsSuccessStatusCode)
                {
                    WikiArticleModel article = await response.Content.ReadAsAsync<WikiArticleModel>().ConfigureAwait(false);

                    return SanitizeArticleModel(article);
                }
                else
                {
                    Console.WriteLine("\n\n\n\n\n================ " + response.ReasonPhrase + "================\n\n\n\n\n");
                    return null;
                }
            }
        }
        #endregion
    }

}

