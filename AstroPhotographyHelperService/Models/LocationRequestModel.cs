using System;

namespace AstroPhotographyHelperService.Models
{
    public class LocationRequestModel
    {
        public float Longitude { get; set; }
        public float Latitude { get; set; }
        public int Range { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
    }
}
