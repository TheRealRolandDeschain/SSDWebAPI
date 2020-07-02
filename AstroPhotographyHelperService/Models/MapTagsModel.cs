using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AstroPhotographyHelperService.Models
{
    [JsonDictionary]
    public class MapTagsModel : Dictionary<string, string>
    {
    }
}
