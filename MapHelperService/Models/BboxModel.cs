using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MapHelperService.Models
{
    public class BboxModel
    {
        #region Public Properties
        public string LongLeft { get; set; }
        public string LongRight { get; set; }
        public string LatTop { get; set; }
        public string  LatBottom { get; set; }
        #endregion

        #region Public Methods
        public string GetParameterString()
        {
            return $"{LatBottom},{LongLeft},{LatTop},{LongRight}";
        }
        #endregion
    }
}
