using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WikipediaHelperService.Models
{
    [JsonDictionary]
    public class PagesModel : Dictionary<int, PageModel> 
    { 
    }
}