using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AstroPhotographyHelperService.Models
{
    public class MostSeparatedPointModel
    {
        public string Longitude { get; set; }
        public string Latitude { get; set; }
        public float MinDistance { get; set; }
    }
}
