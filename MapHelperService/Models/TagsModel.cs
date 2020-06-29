using Newtonsoft.Json;
using System.Collections.Generic;

namespace MapHelperService.Models
{
    [JsonDictionary]
    public class TagsModel : Dictionary<string, string>
    {
    }
}
