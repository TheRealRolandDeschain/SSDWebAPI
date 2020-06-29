using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MapHelperService.Models
{
    public class MapNodesModel
    {
        public float Version { get; set; }
        public string Generator { get; set; }
        public OsmModel Osm3s { get; set; }
        public ElementModel[] Elements { get; set; }
    }
}
