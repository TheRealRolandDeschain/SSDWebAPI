using AstroPhotographyHelperService.Helpers;
using AstroPhotographyHelperService.Interfaces;
using AstroPhotographyHelperService.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Reflection.PortableExecutable;
using System.Threading.Tasks;

namespace AstroPhotographyHelperService.Services
{
    public class LocationRequestService : ILocationRequestService
    {
        #region Public Properties
        private const string urpParametersWiki = @"http://wikihelperservice:80/request?search=";
        private const string urpParametersMap = @"http://maphelperservice:80/request?";
        private const string urpParametersWeather = @"http://weatherhelperservice:80/request?";
        private const string urpParametersCelest = @"http://celestialbodyhelperservice:80/request?";
        #endregion

        #region Private Methods
        /// <summary>
        /// Loads Information From the WikiMediaHelperService
        /// </summary>
        /// <param name="search"></param>
        /// <returns></returns>
        private async Task<WikiArticleModel> LoadArticleInfo(string search)
        {
            string completeURLParam = urpParametersWiki + search;
            using HttpResponseMessage response = await HttpHelper.HelperClient.GetAsync(completeURLParam).ConfigureAwait(false);
            if (response.IsSuccessStatusCode)
            {
                string articleString = await response.Content.ReadAsStringAsync().ConfigureAwait(false);

                return JsonConvert.DeserializeObject<WikiArticleModel>(articleString);
            }
            else
            {
                //System.Diagnostics.Debug.WriteLine("\n\n\n\n\n================ " + response.ReasonPhrase + "================\n\n\n\n\n");
                return null;
            }
        }

        /// <summary>
        /// Loads Information From the CelestialBodyHelperService
        /// </summary>
        /// <param name="search"></param>
        /// <returns></returns>
        private async Task<CelestialBodyFromHelperModel> LoadCelestialBodyInfo(double ra, double de, int angle)
        {
            string completeURLParam = urpParametersCelest + $"ra={ra}&de={de}&angle={angle}";
            using HttpResponseMessage response = await HttpHelper.HelperClient.GetAsync(completeURLParam).ConfigureAwait(false);
            if (response.IsSuccessStatusCode)
            {
                string articleString = await response.Content.ReadAsStringAsync().ConfigureAwait(false);

                return JsonConvert.DeserializeObject<CelestialBodyFromHelperModel>(articleString);
            }
            else
            {
                //System.Diagnostics.Debug.WriteLine("\n\n\n\n\n================ " + response.ReasonPhrase + "================\n\n\n\n\n");
                return null;
            }
        }

        /// <summary>
        /// Loads Information From the Map Helper Service
        /// </summary>
        /// <param name="search"></param>
        /// <returns></returns>
        private async Task<List<MapElementModel>> LoadMapInfo(string longleft, string longright, string lattop, string latbottom)
        {
            string completeURLParam = urpParametersMap + $"longleft={longleft}&longright={longright}&lattop={lattop}&latbottom={latbottom}";
            using HttpResponseMessage response = await HttpHelper.HelperClient.GetAsync(completeURLParam).ConfigureAwait(false);
            if (response.IsSuccessStatusCode)
            {
                string articleString = await response.Content.ReadAsStringAsync().ConfigureAwait(false);

                return JsonConvert.DeserializeObject<List<MapElementModel>>(articleString);
            }
            else
            {
                //System.Diagnostics.Debug.WriteLine("\n\n\n\n\n================ " + response.ReasonPhrase + "================\n\n\n\n\n");
                return null;
            }
        }

        /// <summary>
        /// Loads Information From the Weather Helper Service
        /// </summary>
        /// <param name="search"></param>
        /// <returns></returns>
        private async Task<WeatherInfoModel> LoadWeatherInfo(DateTime starttime, DateTime endtime, string latitude, string longitude)
        {
            string completeURLParam = urpParametersWeather + $"starttime={starttime}&endtime={endtime}&latitude={latitude}&longitude={longitude}";
            using HttpResponseMessage response = await HttpHelper.HelperClient.GetAsync(completeURLParam).ConfigureAwait(false);
            if (response.IsSuccessStatusCode)
            {
                string articleString = await response.Content.ReadAsStringAsync().ConfigureAwait(false);

                return JsonConvert.DeserializeObject<WeatherInfoModel>(articleString);
            }
            else
            {
                //System.Diagnostics.Debug.WriteLine("\n\n\n\n\n================ " + response.ReasonPhrase + "================\n\n\n\n\n");
                return null;
            }
        }

        private LocationAreaModel CalculateAreaFromLocationAndRange(float latitude, float longitude, int range)
        {
            // 1° translates roughly to 111km
            return new LocationAreaModel()
            {
                Longleft = (longitude - 0.5 * range / 111.0f).ToString(),
                Longright = (longitude + 0.5 * range / 111.0f).ToString(),
                Lattop = (latitude + 0.5 * range / 111.0f).ToString(),
                Latbottom = (latitude - 0.5 * range / 111.0f).ToString()
            };
        }

        /// <summary>
        /// This is just a dummy methods. Normally one would take all the map nodes in the area
        /// and calculated the most isolated point in the given area where 
        /// x = arg max(p€S) min(q€S\p) d(p, q), which means the point in the area where the minimum distance to the 
        /// nearest map node is the farthest away. 
        /// </summary>
        /// <param name="area"></param>
        /// <param name="mapnodes"></param>
        /// <returns></returns>
        private MostSeparatedPointModel CalculateMostSeparatedPointInArea(LocationAreaModel area, List<MapElementModel> mapnodes)
        {

            float ll = float.Parse(area.Longleft);
            float lr = float.Parse(area.Longright);
            float lt = float.Parse(area.Lattop);
            float lb = float.Parse(area.Latbottom);

            if (mapnodes.Count == 0)
            {
                return new MostSeparatedPointModel { Longitude = ((lr - ll) / 2).ToString(), Latitude = ((lb - lt) / 2).ToString(), MinDistance = 0 };
            }

            var rng = new Random();
            double firstrng = rng.NextDouble();
            double secondrng = rng.NextDouble();

            float newlong = ll + (lr - ll) * (float)firstrng;
            float newlat = lt + (lb - lt) * (float)secondrng;

            float minDistance = 60.5f;

            return new MostSeparatedPointModel { Longitude = newlong.ToString(), Latitude = newlat.ToString(), MinDistance = minDistance };
        }

        /// <summary>
        /// Also a dummy methods. Normally one would get the celestial coordinates from the sidereal time and the location coordinates
        /// https://skyandtelescope.org/astronomy-resources/right-ascension-declination-celestial-coordinates/
        /// </summary>
        /// <param name="startTime"></param>
        /// <param name="endTime"></param>
        /// <param name="item1"></param>
        /// <param name="item2"></param>
        /// <returns></returns>
        private CelestialCoordinateModel CalculateCelestCoordinatesFromTimeAndLocation(DateTime startTime, DateTime endTime, string Long, string Lat)
        {
            CelestialCoordinateModel coordinates = new CelestialCoordinateModel
            {
                // This first one is actually correct... 
                DE = double.Parse(Lat)
            };

            //The rest are just dummy calculations
            TimeSpan span = endTime - startTime;
            coordinates.Angle = (int)Math.Max(span.TotalHours, 5);
            coordinates.RA = double.Parse(Long);

            return coordinates;
        }

        /// <summary>
        /// This too is not too accurate since the lightpollution map doesn't fit the coordinates of standard world maps
        /// </summary>
        /// <param name="longitude"></param>
        /// <param name="latitude"></param>
        /// <returns></returns>
        private int CalculateLightPollutionFromLocation(float longitude, float latitude)
        {
            var projectFolder = Directory.GetCurrentDirectory();
            var filepath = Path.Combine(projectFolder, @"Data/lighpollution.TIF").Replace(@"\", @"/");
            Image img = Image.FromFile(filepath);
            int height = img.Height;
            int width = img.Width;
            int red, green, blue;

            int pixelX = (int)(width * ((longitude + 180.0f) / 360.0f));
            int pixely = (int)(height - height * ((latitude + 90.0f) / 180.0f));

            using (Bitmap bmp = new Bitmap(img))
            {
                Color clr = bmp.GetPixel(pixelX, pixely); // Get the color of pixel at position 5,5
                red = clr.R;
                green = clr.G;
                blue = clr.B;
            }
            return (100 * (red + green + blue)) / 765;
        }

        private int CalculateProbability(WeatherInfoModel weather, float minDistance, int lightpollution)
        {
            if (!weather.Sundown) return 0;

            float probability = 
                  0.1f * Math.Min((minDistance / 100), 1) 
                + 0.2f * Math.Min((lightpollution / 100.0f), 1) 
                + 0.3f * Math.Min((weather.Clouds / 100.0f), 1)
                + 0.05f * Math.Min((weather.Humity / 100.0f), 1) 
                + 0.05f * Math.Min((weather.WindSpeed / 100.0f), 1) 
                + 0.3f * Math.Min(((100 -weather.PrecipitateProperty) / 100.0f), 1);
            return (int)(probability * 100);
        }
        #endregion

        #region Public Methods
        public RequestResponseModel GetBestLocationsFromRequest(LocationRequestModel request)
        {
            LocationAreaModel area = CalculateAreaFromLocationAndRange(request.Latitude, request.Longitude, request.Range);
            List<MapElementModel> mapnodes = LoadMapInfo(area.Longleft, area.Longright, area.Lattop, area.Latbottom).Result;
            MostSeparatedPointModel mostseparatedPoint = CalculateMostSeparatedPointInArea(area, mapnodes);
            WeatherInfoModel weather = LoadWeatherInfo(request.StartTime, request.EndTime, mostseparatedPoint.Latitude, mostseparatedPoint.Longitude).Result;
            CelestialCoordinateModel celestCoords = CalculateCelestCoordinatesFromTimeAndLocation(request.StartTime, request.EndTime, mostseparatedPoint.Longitude, mostseparatedPoint.Latitude);

            CelestialBodyFromHelperModel possibleBody = LoadCelestialBodyInfo(celestCoords.RA, celestCoords.DE, celestCoords.Angle).Result;
            WikiArticleModel additionalInfo = LoadArticleInfo(possibleBody.Name).Result;

            int lightpollution = CalculateLightPollutionFromLocation(float.Parse(mostseparatedPoint.Longitude), float.Parse(mostseparatedPoint.Latitude));

            int photoprob = CalculateProbability(weather, mostseparatedPoint.MinDistance, lightpollution);

            LocationModel newlocation = new LocationModel()
            {
                CelestialBody = new CelestialBodyModel { Name = possibleBody.Name, Type = possibleBody.Type, ImageUrl = null },
                Name = "New found location",
                Description = "There is no description yet for this Location. Please write one, if you used the location. ",
                Latitude = float.Parse(mostseparatedPoint.Latitude),
                Longitude = float.Parse(mostseparatedPoint.Longitude),
                UserName = "Enter your UserName.."
            };

            RequestResponseModel result = new RequestResponseModel()
            {
                Location = newlocation,
                SuccessProbability = photoprob,
                WikiInfo = additionalInfo
            };

            return result;
        }
        #endregion
    }
}
