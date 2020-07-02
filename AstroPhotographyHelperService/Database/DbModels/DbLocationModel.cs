using AstroPhotographyHelperService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AstroPhotographyHelperService.Database.DbModels
{
    public class DbLocationModel
    {
        #region Public Properties
        public string UserName { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public float Longitude { get; set; }
        public float Latitude { get; set; }
        public string CelestialBody_Name { get; set; }
        public string CelestialBody_Type { get; set; }
        public string CelestialBody_ImageUrl { get; set; }
        #endregion

        #region Constructors
        public DbLocationModel()
        {

        }

        public DbLocationModel(LocationModel location)
        {
            UserName = location.UserName;
            Name = location.Name;
            Description = location.Description;
            Longitude = location.Longitude;
            Latitude = location.Latitude;
            CelestialBody_Name = location.CelestialBody.Name;
            CelestialBody_Type = location.CelestialBody.Type;
            CelestialBody_ImageUrl = location.CelestialBody.ImageUrl;
        }
        #endregion
    }
}
