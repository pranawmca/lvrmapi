using LVRMWebAPI.Extension;
using LVRMWebAPI.Models;
using LVRMWebAPI.Models.Datashake;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LVRMWebAPI.Repository
{
    public class DatashakeRepositoryMannual : IDatashakeRepositoryMannual
    {
        public readonly PSM_DevContext pSM_DevContext;
        public DatashakeRepositoryMannual(PSM_DevContext _pSM_DevContext)
        {
            pSM_DevContext = _pSM_DevContext;
        }
        public int AddDatashakeReview(Review _objDatashakeReview, string source_name, double average_rating, string dealerid, string placeidvalue)
        {
            try
            {
                int result = 0;
                ReulstMsg objResult = new ReulstMsg();
                pSM_DevContext.LoadStoredProc("dbo.USP_DatashakeReviewSchedular")
                  .WithSqlParam("DealerID", dealerid)//string
                  .WithSqlParam("PlaceID", placeidvalue)//string
                  .WithSqlParam("JobID", "0")  //int
                  .WithSqlParam("ReviewCount", "0")//int
                  .WithSqlParam("Source", source_name)// all string below
                  .WithSqlParam("ReviewID", _objDatashakeReview.id)
                  .WithSqlParam("FirstName", _objDatashakeReview.name)
                  .WithSqlParam("LastName", "")
                  .WithSqlParam("ReviewDate", _objDatashakeReview.date)
                  .WithSqlParam("Rating", _objDatashakeReview.rating_value)
                  .WithSqlParam("ReviewDesc", _objDatashakeReview.review_text)
                  .WithSqlParam("ProfilePic", _objDatashakeReview.profile_picture)
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
