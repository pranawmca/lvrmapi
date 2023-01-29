using LVRMWebAPI.Extension;
using LVRMWebAPI.Models;
using System.Collections.Generic;
using System;
using System.Linq;

namespace LVRMWebAPI.Repository
{
    public class DealerRepository: IDealerRepository
    {
        public readonly PSM_DevContext pSM_DevContext;
        public DealerRepository(PSM_DevContext _pSM_DevContext)
        {
            pSM_DevContext = _pSM_DevContext;
        }     
        public DealerResponses GetDealerById(int dealerId)
        {
            try
            {
                //UserResponse _objResponse = new UserResponse();
                DealerResponses dealerdetails = new DealerResponses();
                pSM_DevContext.LoadStoredProc("dbo.GetDealerByIdApi")
                   .WithSqlParam("SourceDealerId", dealerId)
                   .ExecuteStoredProc((handler) =>
                   {
                       dealerdetails = handler.ReadToList<DealerResponses>().FirstOrDefault();
                       // do something with your results.
                   });
                return dealerdetails;

            }
            catch
            {
                throw;

            }
        }
        public List<DealerResponses> GetDealer(DealerSearch _objDealerSearch)
        {
            try
            {
                //UserResponse _objResponse = new UserResponse();
                IList<DealerResponses> dealerlist = new List<DealerResponses>();
                pSM_DevContext.LoadStoredProc("dbo.GetDealersFromApi")
                   .WithSqlParam("SourceDealerId", Convert.ToInt32(_objDealerSearch.SourceDealerId))
                   .ExecuteStoredProc((handler) =>
                   {
                       dealerlist = handler.ReadToList<DealerResponses>().ToList();
                       // do something with your results.
                   });
                return dealerlist.ToList();

            }
            catch
            {
                throw;

            }
        }
        //  public int AddDealer(DealerRequest _objDealerFields)
        public DealerResponses AddDealer(DealerRequest _objDealerFields)
        {
            try
            {
                string guid = Guid.NewGuid().ToString().Replace("-","");
                //IList<DealerResponses> dealerlist = new List<DealerResponses>();
                DealerResponses dealerDetails = new DealerResponses();
                int result = 0;
               // ReulstDealerMsg objResult = new ReulstDealerMsg();
                pSM_DevContext.LoadStoredProc("dbo.AddDealersFromApi")
                  .WithSqlParam("SourceDealerId", Convert.ToInt32(_objDealerFields.SourceDealerId))
                  .WithSqlParam("DealerName", _objDealerFields.DealerName)
                  .WithSqlParam("PhoneNumber", _objDealerFields.PhoneNumber)
                  .WithSqlParam("TimeZone", _objDealerFields.TimeZone)
                  .WithSqlParam("DealerHomePageURL", _objDealerFields.DealerHomePageURL)
                  .WithSqlParam("ThirdPartySite", _objDealerFields.ThirdPartySite)
                  .WithSqlParam("LVSuiteID", _objDealerFields.LVSuiteID)
                  .WithSqlParam("ReviewInvitationEmail", _objDealerFields.ReviewInvitationEmail)
                  .WithSqlParam("RMEnabled", _objDealerFields.RMEnabled)
                  .WithSqlParam("ReviewWidgetSite", _objDealerFields.ReviewWidgetSite)
                  .WithSqlParam("reviewProfile", DBNull.Value)
                  //.WithSqlParam("TrackingScript", _objDealerFields.TrackingScript) //need to discuss about
                  .WithSqlParam("TrackingScript", DBNull.Value)
                  .WithSqlParam("ReviewWidgetContainerTag", _objDealerFields.ReviewWidgetContainerTag)
                  .WithSqlParam("Industry", String.IsNullOrEmpty(_objDealerFields.Industry) ? 0 : (object)_objDealerFields.Industry)
                  .WithSqlParam("FacebookURL", _objDealerFields.FacebookURL)
                  .WithSqlParam("FacebookEnabled", _objDealerFields.FacebookEnabled)
                  .WithSqlParam("GoogleLocationID", _objDealerFields.GoogleLocationID)
                  .WithSqlParam("FacebookReviewURL", _objDealerFields.FacebookReviewURL)
                  .WithSqlParam("GoogleReviewURL", _objDealerFields.GoogleReviewURL)
                  // .WithSqlParam("BadgeGUID", _objDealerFields.BadgeGUID)
                    .WithSqlParam("BadgeGUID", guid) 
                  .ExecuteStoredProc((handler) =>
                  {
                      // objResult = handler.ReadToList<ReulstDealerMsg>().FirstOrDefault();
                      // do something with your results.

                      dealerDetails = handler.ReadToList<DealerResponses>().FirstOrDefault();
                  });

                //result = Convert.ToInt32(objResult.Message);
                //return result;
                return dealerDetails;
            }
            catch
            {

                throw;
            }
        }       
        public int UpdateDealer(UpdateDealerRequest _objDealerFields)
        {
            try
            {
                int result = 0;
                ReulstMsg objResult = new ReulstMsg();
                pSM_DevContext.LoadStoredProc("dbo.UpdateDealerFromAPI")
                  .WithSqlParam("SourceDealerId", Convert.ToInt32(_objDealerFields.SourceDealerId))
                  .WithSqlParam("DealerName", (object)_objDealerFields.DealerName ?? DBNull.Value)
                  .WithSqlParam("PhoneNumber", (object)_objDealerFields.PhoneNumber ?? DBNull.Value)
                  .WithSqlParam("TimeZone", (object)_objDealerFields.TimeZone ?? DBNull.Value)
                  .WithSqlParam("DealerHomePageURL", (object)_objDealerFields.DealerHomePageURL ?? DBNull.Value)
                  .WithSqlParam("ThirdPartySite", (object)_objDealerFields.ThirdPartySite ?? DBNull.Value)
                  .WithSqlParam("LVSuiteID", (object)_objDealerFields.LVSuiteID ?? DBNull.Value)
                  .WithSqlParam("ReviewInvitationEmail", (object)_objDealerFields.ReviewInvitationEmail ?? DBNull.Value)
                  .WithSqlParam("RMEnabled", (object)_objDealerFields.RMEnabled ?? DBNull.Value)
                  .WithSqlParam("ReviewWidgetSite", (object)_objDealerFields.ReviewWidgetSite ?? DBNull.Value)
                  //.WithSqlParam("reviewProfile", _objDealerFields.reviewProfile)
                  .WithSqlParam("TrackingScript", (object)_objDealerFields.TrackingScript ?? DBNull.Value)
                  .WithSqlParam("ReviewWidgetContainerTag", (object)_objDealerFields.ReviewWidgetContainerTag ?? DBNull.Value)
                  //.WithSqlParam("Industry", String.IsNullOrEmpty(_objDealerFields.Industry) ? 0 : (object)_objDealerFields.Industry)
                  .WithSqlParam("Industry", (object)_objDealerFields.Industry ?? DBNull.Value)
                  .WithSqlParam("FacebookURL", (object)_objDealerFields.FacebookURL ?? DBNull.Value)
                  .WithSqlParam("FacebookEnabled", (object)_objDealerFields.FacebookEnabled ?? DBNull.Value)
                  .WithSqlParam("GoogleLocationID", (object)_objDealerFields.GoogleLocationID ?? DBNull.Value)
                  .WithSqlParam("FacebookReviewURL", (object)_objDealerFields.FacebookReviewURL ?? DBNull.Value)
                  .WithSqlParam("GoogleReviewURL", (object)_objDealerFields.GoogleReviewURL ?? DBNull.Value)
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
        public int DeleteDealer(DeleteDealerRequest _objDealerFields)
        {
            try
            {
                int result = 0;
                ReulstMsg objResult = new ReulstMsg();
                pSM_DevContext.LoadStoredProc("dbo.DeleteDealerFromAPI")
                  .WithSqlParam("SourceDealerId", Convert.ToInt32(_objDealerFields.SourceDealerId))
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
    public class ReulstDealerMsg
    {
        public int Message { get; set; }
    }
}
