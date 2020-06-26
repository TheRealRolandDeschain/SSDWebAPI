using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WikipediaHelperService.Models
{
    public class WikiArticleModel
    {
        public string BatchComplete { get; set; }
        public QueryModel Query { get; set; }
    }
}