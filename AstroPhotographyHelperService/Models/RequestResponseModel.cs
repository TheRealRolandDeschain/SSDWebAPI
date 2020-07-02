using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AstroPhotographyHelperService.Models
{
    public class RequestResponseModel
    {
        public int SuccessProbability { get; set; }
        public WikiArticleModel WikiInfo { get; set; }
        public LocationModel Location { get; set; }
    }
}
