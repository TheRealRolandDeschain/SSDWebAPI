using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AstroPhotographyHelperService.Models
{
    public class WikiArticleModel
    {
        public string Title { get; set; }
        public int PageId { get; set; }
        public string Description { get; set; }
        public string Summary { get; set; }
        public string ImageUrl { get; set; }
    }
}
