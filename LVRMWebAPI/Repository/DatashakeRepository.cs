using LVRMWebAPI.Extension;
using LVRMWebAPI.Models;
using LVRMWebAPI.Models.Datashake;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LVRMWebAPI.Repository
{
    public class DatashakeRepository : IDatashakeRepository
    {
        public readonly PSM_DevContext pSM_DevContext;
        public DatashakeRepository(PSM_DevContext _pSM_DevContext)
        {
            pSM_DevContext = _pSM_DevContext;
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

        public int AddDatashakeReview(Review _objDatashakeReview)
        {
            try
            {
                int result = 0;
                ReulstMsg objResult = new ReulstMsg();
                pSM_DevContext.LoadStoredProc("dbo.USP_DatashakeReviewSchedular")
                  .WithSqlParam("PlaceID", "")//string
                  .WithSqlParam("JobID", 0)  //int
                  .WithSqlParam("ReviewCount", 0)//int
                  .WithSqlParam("Source", "google")// all string below
                  .WithSqlParam("ReviewID", _objDatashakeReview.id)
                  .WithSqlParam("FirstName", _objDatashakeReview.name)
                  .WithSqlParam("LastName", "")
                  .WithSqlParam("ReviewDate", _objDatashakeReview.date)
                  .WithSqlParam("Rating", _objDatashakeReview.rating_value)
                  .WithSqlParam("ReviewDesc", _objDatashakeReview.review_text)
                  .ExecuteStoredProc((handler) =>
                  {
                      objResult = handler.ReadToList<ReulstMsg>().FirstOrDefault();
                      // do something with your results.
                  });

                result = Convert.ToInt32(objResult.Message);
                return result;
            }
            catch
            {

                throw;
            }
        }
    }


}
