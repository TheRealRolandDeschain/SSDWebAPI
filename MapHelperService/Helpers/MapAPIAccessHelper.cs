using MapHelperService.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace MapHelperService.Helpers
{
    public class MapAPIAccessHelper
    {
        #region Private Properties
        private const string urlParameters_begin = @"interpreter?data=[out:json][bbox:";
        private const string urlParameters_end = @"];node[~'^(highway|place|landuse|crossing|railway|amenity|shop)$'~'.'];out;";
        #endregion

        #region Public Properties
        #endregion

        #region Construtorion
        #endregion

        #region Private Methods
        /// <summary>
        /// Further reduces the returned result to only useful data
        /// </summary>
        /// <param name="orig"></param>
        /// <returns></returns>
        public static List<ElementModel> SanitizeNodesModel(MapNodesModel orig)
        {
            return orig.Elements.Where(e => !e.Tags.ContainsValue("bench") && !e.Tags.ContainsValue("drinking_water") && !e.Tags.ContainsValue("toilets")).ToList();
        }
        #endregion

        #region Public Methods
        /// <summary>
        /// loads the article information based on the search parameter from the
        /// wikimedia api
        /// </summary>
        /// <param name="search"></param>
        /// <returns></returns>
        public static async Task<List<ElementModel>> LoadNodeInfo(BboxModel bbox)
        {
            string completeURLParam = urlParameters_begin + bbox.GetParameterString() + urlParameters_end;
            using HttpResponseMessage response = await HttpHelper.MapClient.GetAsync(completeURLParam).ConfigureAwait(false);
            if (response.IsSuccessStatusCode)
            {
                string articleString = await response.Content.ReadAsStringAsync().ConfigureAwait(false);
                MapNodesModel nodes = JsonConvert.DeserializeObject<MapNodesModel>(articleString);
                return SanitizeNodesModel(nodes);
            }
            else
            {
                return null;
            }
        }
        #endregion
    }
}

