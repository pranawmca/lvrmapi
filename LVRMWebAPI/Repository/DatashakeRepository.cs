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

        public int AddDatashakeReview(DatashakeReviewField _objDatashakeReview)
        {
            try
            {
                int result = 0;
                ReulstMsg objResult = new ReulstMsg();
                pSM_DevContext.LoadStoredProc("dbo.USP_DatashakeReviewSchedular")
                  .WithSqlParam("PlaceID", _objDatashakeReview.PlaceID)
                  .WithSqlParam("JobID", _objDatashakeReview.JobID)
                  .WithSqlParam("ReviewCount", _objDatashakeReview.ReviewCount)
                  .WithSqlParam("Source", "google")
                  .WithSqlParam("ReviewID", _objDatashakeReview.ReviewID)
                  .WithSqlParam("FirstName", _objDatashakeReview.FirstName)
                  .WithSqlParam("LastName", _objDatashakeReview.LastName)
                  .WithSqlParam("ReviewDate", _objDatashakeReview.ReviewDate)
                  .WithSqlParam("Rating", _objDatashakeReview.Rating)
                  .WithSqlParam("ReviewDesc", _objDatashakeReview.ReviewDesc)
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
