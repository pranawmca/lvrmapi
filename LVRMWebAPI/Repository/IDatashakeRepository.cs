using LVRMWebAPI.Models.Datashake;
using System.Collections.Generic;

namespace LVRMWebAPI.Repository
{
    public interface IDatashakeRepository
    {
        List<PlaceIDJobDetail> GetPlaceidwithjobid(string DealerID, string PlaceID);
        int AddUser(Employees _objEmploye);
    }
}