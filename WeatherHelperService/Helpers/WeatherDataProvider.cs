using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography.Xml;
using System.Threading.Tasks;
using WeatherHelperService.Models;

namespace WeatherHelperService.Helpers
{
    public class WeatherDataProvider
    {
        #region Private Methods
        /// <summary>
        /// Load Weather Data from JSON file
        /// </summary>
        /// <returns></returns>
        private static List<WeatherInfoModel> ReadWeatherData()
        {
            List<WeatherInfoModel> data;
            var projectFolder = Directory.GetCurrentDirectory();
            // Path.Combine always uses wrong separator for linux file systems
            var filepath = Path.Combine(projectFolder, @"Data/WeatherData.json").Replace(@"\", @"/");
            using (StreamReader file = File.OpenText(filepath))
            using (JsonTextReader reader = new JsonTextReader(file))
            {
                JsonSerializer serializer = new JsonSerializer();
                data = (List<WeatherInfoModel>)serializer.Deserialize(file, typeof(List<WeatherInfoModel>));
            }
            return data;
        }
        #endregion

        #region Public Methods
        /// <summary>
        /// Simply load all possible weather models from json and return one at random
        /// </summary>
        /// <param name="start"></param>
        /// <param name="end"></param>
        /// <param name="latitude"></param>
        /// <param name="longitude"></param>
        /// <returns></returns>
        public static WeatherInfoModel GetWeatherData(DateTime start, DateTime end, string latitude, string longitude)
        {
            List<WeatherInfoModel> weatherlist = ReadWeatherData();
            Random rnd = new Random();
            int index = rnd.Next(0, 10);
            //System.Diagnostics.Debug.WriteLine("\n================ " + index + "================\n");
            return weatherlist[index];
        }
        #endregion
    }
}
