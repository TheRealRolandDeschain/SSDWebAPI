using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WikiMediaHelperService.Models
{

    public class QueryModel
    {
        public List<NormalizedModel> Normalized { get; set; }

        public PagesModel Pages { get; set; }
    }
}