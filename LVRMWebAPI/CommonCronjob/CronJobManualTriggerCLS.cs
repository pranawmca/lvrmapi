using LVRMWebAPI.Extension;
using LVRMWebAPI.Infrastructure;
using LVRMWebAPI.Models;
using LVRMWebAPI.Models.Datashake;
using LVRMWebAPI.Repository;
using LVRMWebAPI.ScronJob;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LVRMWebAPI.CommonCronjob
{
    public class CronJobManualTriggerCLS : ICronJobManualTriggerCLS
    {
        private readonly IServiceProvider _serviceProvider;
        public CronJobManualTriggerCLS(IServiceProvider _serviceProvider)
        {
            this._serviceProvider = _serviceProvider;

        }
        public void CallCronJobManually()
        {
            try
            {
                ReviewRepository ObjreviewRepository = new ReviewRepository();
                int R1 = ObjreviewRepository.UpdateDatashakeLog("Mannually Triggered: Crob job started Mannually");

                List<PlaceIDJobDetail> objPlaceIDJobDetail = ObjreviewRepository.GetPlaceidwithjobid("", "");
                //List<PlaceIDJobDetail> objPlaceIDJobDetail = new List<PlaceIDJobDetail>();
                if (objPlaceIDJobDetail != null && objPlaceIDJobDetail.Count > 0)
                {

                    for (int i = 0; i < objPlaceIDJobDetail.Count; i++)
                    {
                        try
                        {
                            string jobid = string.Empty;
                            if (string.IsNullOrWhiteSpace(objPlaceIDJobDetail[i].JobID))
                            {
                                //Data shake API with placeid/fb url only.
                                int R2 = ObjreviewRepository.UpdateDatashakeLog("Mannually Triggered: Calling Datashake api mannually to get jobID. Placeid : " + objPlaceIDJobDetail[i].PlaceID + " and Dealer ID :" + objPlaceIDJobDetail[i].DealerID + "");
                                object objPlaceIdResponse = DataShakeClientCall.GetDataShakeAPIPlaceidResponse(objPlaceIDJobDetail[i].PlaceID, "0ded0923c6537d61c5d8b0dd03877b0e46b8ac73");
                                // object objPlaceIdResponse = "{\"success\":true,\"job_id\":453375210,\"status\":200,\"message\":\"Added this profile to the queue...\"}";
                                var data = (JObject)JsonConvert.DeserializeObject(objPlaceIdResponse.ToString());
                                if (Convert.ToBoolean(((Newtonsoft.Json.Linq.JValue)data["success"]).Value))
                                {
                                    jobid = Convert.ToString(((Newtonsoft.Json.Linq.JValue)data["job_id"]).Value);
                                }

                                int R7 = ObjreviewRepository.UpdateDatashakeLog("Mannually Triggered: Get job ID For Placeid : " + objPlaceIDJobDetail[i].PlaceID + " and Dealer ID :" + objPlaceIDJobDetail[i].DealerID + "");

                            }
                            else
                            {

                                jobid = objPlaceIDJobDetail[i].JobID;
                            }
                            #region update job id and isrun to database here
                            DatashakeJobIDDetails _objUpdateJobID = new DatashakeJobIDDetails();
                            _objUpdateJobID.DealerId = objPlaceIDJobDetail[i].DealerID;
                            _objUpdateJobID.PlaceID = objPlaceIDJobDetail[i].PlaceID;
                            _objUpdateJobID.JobID = jobid;
                            _objUpdateJobID.Status = "Running";
                            int updateJobIDResult = ObjreviewRepository.UpdateJobIDByPlaceID(_objUpdateJobID);
                            #endregion
                            int totalCount = 0;
                            //get review from datashake api
                            if (!string.IsNullOrWhiteSpace(jobid))
                            {
                                DataShakeApiResponseModel objReviewResponse = DataShakeClientCall.GetDataShakeAPIResponse(Convert.ToInt32(jobid), "0ded0923c6537d61c5d8b0dd03877b0e46b8ac73");

                                if (objReviewResponse != null)
                                {
                                    if (objReviewResponse.reviews?.Count > 0)
                                    {
                                        var average_rating = objReviewResponse.average_rating;
                                        var source_name = objReviewResponse.source_name;

                                        if (objReviewResponse.reviews.Count > 0)
                                        {
                                            //List<DatashakeReviewField> objEmployeeList = new List<DatashakeReviewField>();
                                            objReviewResponse.reviews.AsParallel()
                                              .WithDegreeOfParallelism(Convert.ToInt32(Math.Ceiling((Environment.ProcessorCount * 0.75) * 2.0)))
                                            .ForAll(itemId =>
                                            {
                                                using (var scope = _serviceProvider.CreateScope())
                                                {
                                                   // _logger.LogInformation("From Datasahake service start execution {datetime}", DateTime.Now);
                                                    var scopedService = scope.ServiceProvider.GetRequiredService<IMyScopServicesMannual>();

                                                    scopedService.RunSchedularMannual(itemId, source_name, Convert.ToDouble(average_rating), objPlaceIDJobDetail[i].DealerID, objPlaceIDJobDetail[i].PlaceID);
                                                }
                                            });

                                            totalCount = objReviewResponse.reviews.Count;

                                        }
                                    }
                                }
                            }
                            int R3 = ObjreviewRepository.UpdateDatashakeLog("Mannually Triggered: Data completed For Placeid : " + objPlaceIDJobDetail[i].PlaceID);

                            #region update jobid
                            DatashakeJobIDDetails _objJobDetails = new DatashakeJobIDDetails();
                            _objJobDetails.DealerId = objPlaceIDJobDetail[i].DealerID;
                            _objJobDetails.PlaceID = objPlaceIDJobDetail[i].PlaceID;
                            _objJobDetails.JobID = jobid;
                            _objJobDetails.ReviewCount = totalCount.ToString();
                            int result = ObjreviewRepository.UpdateDatashakeJobID(_objJobDetails);
                            #endregion

                            int R4 = ObjreviewRepository.UpdateDatashakeLog("Mannually Triggered: Placeid and JOb ID updated  For DealerID : " + objPlaceIDJobDetail[i].DealerID);
                        }

                        catch (Exception ex)
                        {
                            #region update jobid
                            DatashakeJobIDDetails _objJobDetails = new DatashakeJobIDDetails();
                            _objJobDetails.DealerId = objPlaceIDJobDetail[i].DealerID;
                            _objJobDetails.PlaceID = objPlaceIDJobDetail[i].PlaceID;
                            _objJobDetails.JobID = string.Empty;
                            _objJobDetails.ReviewCount = "0";
                            int result = ObjreviewRepository.UpdateDatashakeJobID(_objJobDetails);
                            #endregion

                            int R4 = ObjreviewRepository.UpdateDatashakeLog("Mannually Triggered: Exceptions For DealerID : " + objPlaceIDJobDetail[i].DealerID + " " + ex.Message);
                        }

                    }


                }
            }
            catch
            {
                throw;
            }
        }



        public List<PlaceIdDetailsModel> GetPlaceIDDetails()
        {
            PSM_DevContext _pSM_DevContext = new PSM_DevContext();
            List<PlaceIdDetailsModel> lstPlaceID = new List<PlaceIdDetailsModel>();
            try
            {

               _pSM_DevContext.LoadStoredProc("USP_GetAllPlaceidDetails")
                   .ExecuteStoredProc((handler) =>
                   {
                       lstPlaceID = handler.ReadToList<PlaceIdDetailsModel>().ToList();
                       // do something with your results.
                   });

                return lstPlaceID;
            }
            catch
            {

                throw;
            }
            
        }

        public void SaveDealerIDPlaceID(List<PlaceIdDetailsModel> lstModel)
        {

            try
            {
                for (int i = 0; i<lstModel.Count; i++)
                {
                    PlaceIdDetailsModel objModel = lstModel[i];
                   

                    int result = AddDealerIDPlaceID(objModel);

                }

            }
            catch
            {

                throw;

            }
        }

        private int AddDealerIDPlaceID(PlaceIdDetailsModel _obPlaceIdDetailsModel)
        {
            int result = 0;
            try
            {
                PSM_DevContext _pSM_DevContext = new PSM_DevContext();
             
                ReulstMsg objResult = new ReulstMsg();
                _pSM_DevContext.LoadStoredProc("dbo.USP_AddDealerAndPlaceIDValues")
                  .WithSqlParam("PlaceID", _obPlaceIdDetailsModel.PlaceID)
                  .WithSqlParam("DealerID", _obPlaceIdDetailsModel.DealerID)
                  .ExecuteStoredProc((handler) =>
                  {
                      objResult = handler.ReadToList<ReulstMsg>().FirstOrDefault();
                      // do something with your results.
                  });

                result = Convert.ToInt32(objResult.Message);
               
            }
            catch(Exception ex)
            {

               
            }
            return result;
        }

        public void MergeDealer()
        {
            int result = 0;
            try
            {
                PSM_DevContext _pSM_DevContext = new PSM_DevContext();
                ReulstMsg objResult = new ReulstMsg();
                _pSM_DevContext.LoadStoredProc("dbo.USP_InsertUpdateDealerFromDumpData")
                  .ExecuteStoredProc((handler) =>
                  {
                      objResult = handler.ReadToList<ReulstMsg>().FirstOrDefault();
                      // do something with your results.
                  });

                result = Convert.ToInt32(objResult.Message);

            }
            catch (Exception ex)
            {
            }           
        }
    }
}
