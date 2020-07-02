using AstroPhotographyHelperService.Database.DbModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AstroPhotographyHelperService.Models
{
    public class LocationModel
    {
        #region Public Properties
        public string UserName { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public float Longitude { get; set; }
        public float Latitude { get; set; }
        public CelestialBodyModel CelestialBody { get; set; }
        #endregion

        #region Constructors
        public LocationModel()
        {

        }

        public LocationModel(DbLocationModel dbmodel)
        {
            UserName = dbmodel.UserName;
            Name = dbmodel.Name;
            Description = dbmodel.Description;
            Longitude = dbmodel.Longitude;
            Latitude = dbmodel.Latitude;
            CelestialBody = new CelestialBodyModel(dbmodel.CelestialBody_Name, dbmodel.CelestialBody_Type, dbmodel.CelestialBody_ImageUrl);
        }
        #endregion
    }
}
