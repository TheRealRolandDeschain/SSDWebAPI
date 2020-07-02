using AstroPhotographyHelperService.Database.DbAccess;
using AstroPhotographyHelperService.Database.DbModels;
using AstroPhotographyHelperService.Interfaces;
using AstroPhotographyHelperService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace AstroPhotographyHelperService.Services
{
    public class DatabaseService : IDatabaseService
    {
        #region Private Methods
        /// <summary>
        /// Checks input parameters: we always use latitude respecive to aequator and longitude to nullmeridian
        /// Normally numbers exceeding the limits of earth aren't an issue, since they can't simply be mapped
        /// to usable values, but we don't care about this here. (This means for example a longitude value of 
        /// 190° would be mapped to -170°
        /// </summary>
        /// <param name="longleft"></param>
        /// <param name="longright"></param>
        /// <param name="lattop"></param>
        /// <param name="latbottom"></param>
        /// <returns></returns>
        private bool CheckCoordInput(float longleft, float longright, float lattop, float latbottom)
        {
            if (lattop < latbottom || longright < longleft)
                return false;
            return true;
        }

        private bool CheckLocationModel(LocationModel location)
        {
            foreach (PropertyInfo pi in location.GetType().GetProperties())
            {
                if (pi.PropertyType == typeof(string))
                {
                    string value = (string)pi.GetValue(location);
                    if (string.IsNullOrWhiteSpace(value))
                    {
                        return false;
                    }
                }
            }
            return true;
        }
        #endregion

        #region Public Methods
        public string AddLocation(LocationModel location)
        {
            if (!CheckLocationModel(location)) return null;

            DatabaseAccessHandler db = new DatabaseAccessHandler();
            DbLocationModel dbLocation = new DbLocationModel(location);
            string response = db.TryCreateNewLocation(dbLocation);
            return response;
        }


        public List<LocationModel> GetLocationsByArea(float longleft, float longright, float lattop, float latbottom)
        {
            if (!CheckCoordInput(longleft, longright, lattop, latbottom)) return null;

            DatabaseAccessHandler db = new DatabaseAccessHandler();

            List<DbLocationModel> dblocations = db.TryGetLocationByArea(longleft, longright, lattop, latbottom);
            List<LocationModel> locations = new List<LocationModel>();

            foreach (var dblocation in dblocations)
            {
                locations.Add(new LocationModel(dblocation));
            }

            return locations;
        }

        public LocationModel GetLocationByName(string locationname)
        {
            if (string.IsNullOrWhiteSpace(locationname)) return null;
            DatabaseAccessHandler db = new DatabaseAccessHandler();

            DbLocationModel dblocation = db.TryGetLocationByName(locationname);
            LocationModel location = new LocationModel(dblocation);

            return location;
        }

        public string DeleteLocationByName(string locationname)
        {
            if (string.IsNullOrWhiteSpace(locationname)) return null;

            DatabaseAccessHandler db = new DatabaseAccessHandler();
            string response = db.DeleteLocationByName(locationname);

            return response;
        }
        #endregion
    }
}
