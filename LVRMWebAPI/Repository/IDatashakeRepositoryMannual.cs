using LVRMWebAPI.Models.Datashake;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LVRMWebAPI.Repository
{
   public  interface IDatashakeRepositoryMannual
    {
        int AddDatashakeReview(Review _objDatashakeReview, string source_name, double average_rating, string dealerid, string placeidvalue);

    }
}
