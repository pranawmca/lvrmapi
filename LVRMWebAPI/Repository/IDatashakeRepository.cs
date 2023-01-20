using LVRMWebAPI.Models.Datashake;
using System.Collections.Generic;

namespace LVRMWebAPI.Repository
{
    public interface IDatashakeRepository
    {
        List<PlaceIDJobDetail> GetPlaceidwithjobid(string DealerID, string PlaceID);
        int AddDatashakeReview(Review _objDatashakeReview,   string source_name, double average_rating, string dealerid, string placeidvalue);
        //int UpdateDatashakeJobID(DatashakeJobIDDetails _objJobIDDetails);
    }
}