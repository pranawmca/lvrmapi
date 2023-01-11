using LVRMWebAPI.Extension;
using LVRMWebAPI.Models;
using LVRMWebAPI.Models.Datashake;
using System.Collections.Generic;
using System.Linq;

namespace LVRMWebAPI.Repository
{
    public class ReviewRepository: IReviewRepository
    {
        public readonly PSM_DevContext pSM_DevContext;
        public ReviewRepository(PSM_DevContext _pSM_DevContext)
        {
            pSM_DevContext = _pSM_DevContext;
        }
        public string getname()
        {
            return "test";
        }
        public List<PlaceIDJobDetail> GetPlaceidwithjobid(string DealerID, string PlaceID)
        {
            try
            {
                //UserResponse _objResponse = new UserResponse();
                IList<PlaceIDJobDetail> placeIDList = new List<PlaceIDJobDetail>();
                pSM_DevContext.LoadStoredProc("dbo.GET_PlaceID_DealerID")
                   .WithSqlParam("DealerID", DealerID)
                   .WithSqlParam("PlaceID", PlaceID)
                   .ExecuteStoredProc((handler) =>
                   {
                       placeIDList = handler.ReadToList<PlaceIDJobDetail>().ToList();
                       // do something with your results.
                   });
                return placeIDList.ToList();
            }

            catch
            {
                throw;
            }
        }
    }
}
