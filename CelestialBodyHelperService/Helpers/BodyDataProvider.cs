using CelestialBodyHelperService.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace CelestialBodyHelperService.Helpers
{
    public class BodyDataProvider
    {
        #region Private Methods
        /// <summary>
        /// Load Weather Data from JSON file
        /// </summary>
        /// <returns></returns>
        private static List<BodyInfoModel> ReadBodyData()
        {
            List<BodyInfoModel> data;
            var projectFolder = Directory.GetCurrentDirectory();
            // Path.Combine always uses wrong separator for linux file systems
            var filepath = Path.Combine(projectFolder, @"Data/BodyData.json").Replace(@"\", @"/");
            using (StreamReader file = File.OpenText(filepath))
            using (JsonTextReader reader = new JsonTextReader(file))
            {
                JsonSerializer serializer = new JsonSerializer();
                data = (List<BodyInfoModel>)serializer.Deserialize(file, typeof(List<BodyInfoModel>));
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
        public static BodyInfoModel GetBodyData(double ra, double de, int angle)
        {
            List<BodyInfoModel> bodylist = ReadBodyData();
            Random rnd = new Random();
            int index = rnd.Next(0, 12);
            //System.Diagnostics.Debug.WriteLine("\n================ " + index + "================\n");
            return bodylist[index];
        }
        #endregion
    }
}
