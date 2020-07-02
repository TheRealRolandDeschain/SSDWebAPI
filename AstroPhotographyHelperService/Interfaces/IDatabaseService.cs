using AstroPhotographyHelperService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AstroPhotographyHelperService.Interfaces
{
    public interface IDatabaseService
    {
        List<LocationModel> GetLocationsByArea(float longleft, float longright, float lattop, float latbottom);
        string AddLocation(LocationModel location);
        LocationModel GetLocationByName(string locationname);
        //string UpdateLocationByUserName(LocationModel location);
        string DeleteLocationByName(string locationname);
    }
}
