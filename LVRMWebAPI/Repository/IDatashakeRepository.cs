using LVRMWebAPI.Models.Datashake;
using System.Collections.Generic;

namespace LVRMWebAPI.Repository
{
    public interface IDatashakeRepository
    {
        List<PlaceIDJobDetail> GetPlaceidwithjobid(string DealerID, string PlaceID);
        int AddDatashakeReview(Review _objDatashakeReview, string dealerid);
        //int UpdateDatashakeJobID(DatashakeJobIDDetails _objJobIDDetails);
    }
}