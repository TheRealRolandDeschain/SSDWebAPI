using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AstroPhotographyHelperService.Models
{
    public class CelestialBodyFromHelperModel
    {
        public string Name { get; set; }
        public string Type { get; set; }
        public double RightAscention { get; set; }
        public double Declination { get; set; }
        public double Magnitude { get; set; }
    }
}
