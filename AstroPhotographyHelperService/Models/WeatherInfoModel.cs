using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AstroPhotographyHelperService.Models
{
    public class WeatherInfoModel
    {
        public string WeatherType { get; set; }
        public int Clouds { get; set; }
        public bool Sundown { get; set; }
        public int WindSpeed { get; set; }
        public int PrecipitateProperty { get; set; }
        public int Humity { get; set; }
    }
}
