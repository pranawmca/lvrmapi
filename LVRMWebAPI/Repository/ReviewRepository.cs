using LVRMWebAPI.Extension;
using LVRMWebAPI.Models;
using LVRMWebAPI.Models.Datashake;
using System;
using System.Collections.Generic;
using System.Linq;

namespace LVRMWebAPI.Repository
{
    public class ReviewRepository //: IReviewRepository
    {
        //public readonly PSM_DevContext pSM_DevContext;
        //public ReviewRepository(PSM_DevContext _pSM_DevContext)
        //{
        //    pSM_DevContext = _pSM_DevContext;
        //}
        public string getname()
        {
            return "test";
        }
        public List<PlaceIDJobDetail> GetPlaceidwithjobid(string DealerID, string PlaceID)
        {
            try
            {
                PSM_DevContext _pSM_DevContext = new PSM_DevContext();
                //UserResponse _objResponse = new UserResponse();
                IList<PlaceIDJobDetail> placeIDList = new List<PlaceIDJobDetail>();
                _pSM_DevContext.LoadStoredProc("GET_PlaceID_DealerIDTest")
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

        public int UpdateDatashakeJobID(DatashakeJobIDDetails _objJobIDDetails)
        {
            try
            {
                int result = 0;
                ReulstMsg objResult = new ReulstMsg();
                PSM_DevContext _pSM_DevContext = new PSM_DevContext();
                _pSM_DevContext.LoadStoredProc("dbo.UpdateJobIDDeatails")
                  .WithSqlParam("DealerID", _objJobIDDetails.DealerId)//string
                  .WithSqlParam("PlaceID", _objJobIDDetails.PlaceID)//string
                  .WithSqlParam("JobID", _objJobIDDetails.JobID)  //string
                  .WithSqlParam("ReviewCount", _objJobIDDetails.ReviewCount)//string
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

        public int UpdateJobIDByPlaceID(DatashakeJobIDDetails _objJobIDDetails)
        {
            try
            {
                int result = 0;
                ReulstMsg objResult = new ReulstMsg();
                PSM_DevContext _pSM_DevContext = new PSM_DevContext();
                _pSM_DevContext.LoadStoredProc("dbo.UpdateJobIDByPlaceID")
                  .WithSqlParam("DealerID", _objJobIDDetails.DealerId)//string
                  .WithSqlParam("PlaceID", _objJobIDDetails.PlaceID)//string
                  .WithSqlParam("JobID", _objJobIDDetails.JobID)  //string
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

        public int UpdateDatashakeLog(string MessageLog)
        {
            try
            {
                int result = 0;
                ReulstMsg objResult = new ReulstMsg();
                PSM_DevContext _pSM_DevContext = new PSM_DevContext();
                _pSM_DevContext.LoadStoredProc("dbo.USP_DatashakeLog")
                  .WithSqlParam("Message", MessageLog)//string
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
