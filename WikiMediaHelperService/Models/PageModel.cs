using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WikiMediaHelperService.Models
{
    public class PageModel
    {
        public int PageId { get; set; }
        public int Ns { get; set; }
        public string Title { get; set; }
        public string Extract { get; set; }
        public string Description { get; set; }
        public string Descriptionsource { get; set; }
        public OriginalModel Original { get; set; }
    }
}