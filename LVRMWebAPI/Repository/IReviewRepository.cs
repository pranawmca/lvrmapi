using LVRMWebAPI.Models.Datashake;
using System.Collections.Generic;

namespace LVRMWebAPI.Repository
{
    public interface IReviewRepository
    {
        string getname();
        List<PlaceIDJobDetail> GetPlaceidwithjobid(string DealerID, string PlaceID);

    }
}
