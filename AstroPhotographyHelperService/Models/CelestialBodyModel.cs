using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AstroPhotographyHelperService.Models
{
    public class CelestialBodyModel
    {
        #region Public Properties
        public string Name { get; set; }
        public string Type { get; set; }
        public string ImageUrl { get; set; }
        #endregion

        #region Constructors
        public CelestialBodyModel()
        {
                
        }

        public CelestialBodyModel(string celestialBody_Name, string celestialBody_Type, string celestialBody_ImageUrl)
        {
            Name = celestialBody_Name;
            Type = celestialBody_Type;
            ImageUrl = celestialBody_ImageUrl;
        }
        #endregion
    }
}
