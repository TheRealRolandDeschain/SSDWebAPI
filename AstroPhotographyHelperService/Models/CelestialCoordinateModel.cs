using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AstroPhotographyHelperService.Models
{
    public class CelestialCoordinateModel
    {
        public double RA { get; set; } 
        public double DE { get; set; } 
        public int Angle { get; set; }
    }
}
