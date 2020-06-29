using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MapHelperService.Models
{
    public class ElementModel
    {
        public string Type { get; set; }
        public long ID { get; set; }
        public float Lat { get; set; }
        public float Lon { get; set; }
        public TagsModel Tags { get; set; }
    }
}
