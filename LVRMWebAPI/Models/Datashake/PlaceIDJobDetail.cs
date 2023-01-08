using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LVRMWebAPI.Models.Datashake
{
    public class PlaceIDJobDetail
    {
        public string DealerID { get; set; }
        public string PlaceID { get; set; }
        public string JobID { get; set; }
        public bool IsRun { get; set; }

    }
}
