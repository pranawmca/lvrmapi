using LVRMWebAPI.Infrastructure;
using LVRMWebAPI.Models.Datashake;
using LVRMWebAPI.Repository;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Threading;
using System.Threading.Tasks;

namespace LVRMWebAPI.ScronJob
{
    public class DatashakeCronjboService : BackgroundService
    {
        private readonly ILogger<DatashakeCronjboService> _logger;
        private readonly IServiceProvider _serviceProvider;
        public DatashakeCronjboService(IServiceProvider serviceProvider, ILogger<DatashakeCronjboService> _logger)//, 
        {
            this._logger = _logger;
            _serviceProvider = serviceProvider;
        }
        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {

            while (!stoppingToken.IsCancellationRequested)
            {

                //if (_isFlag == false)
                //{
                // setp 1: Method to get dealer deatils with placeid

                //Log: Initiated
                ReviewRepository ObjreviewRepository = new ReviewRepository();
                int R1 = ObjreviewRepository.UpdateDatashakeLog("Crob job started");

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
                                int R2 = ObjreviewRepository.UpdateDatashakeLog("Calling Datashake api with to get jobID. Placeid : " + objPlaceIDJobDetail[i].PlaceID+ " and Dealer ID :" + objPlaceIDJobDetail[i].DealerID +"");
                                object objPlaceIdResponse = DataShakeClientCall.GetDataShakeAPIPlaceidResponse(objPlaceIDJobDetail[i].PlaceID, "0ded0923c6537d61c5d8b0dd03877b0e46b8ac73");
                                // object objPlaceIdResponse = "{\"success\":true,\"job_id\":453375210,\"status\":200,\"message\":\"Added this profile to the queue...\"}";
                                var data = (JObject)JsonConvert.DeserializeObject(objPlaceIdResponse.ToString());
                                if (Convert.ToBoolean(((Newtonsoft.Json.Linq.JValue)data["success"]).Value))
                                {
                                    jobid = Convert.ToString(((Newtonsoft.Json.Linq.JValue)data["job_id"]).Value);
                                }

                                int R7 = ObjreviewRepository.UpdateDatashakeLog("Get job ID For Placeid : " + objPlaceIDJobDetail[i].PlaceID + " and Dealer ID :" + objPlaceIDJobDetail[i].DealerID + "");

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
                                                    _logger.LogInformation("From Datasahake service start execution {datetime}", DateTime.Now);
                                                    var scopedService = scope.ServiceProvider.GetRequiredService<IScopedSevices>();
                                                    
                                                    scopedService.RunSchedular(itemId, source_name, Convert.ToDouble(average_rating),objPlaceIDJobDetail[i].DealerID, objPlaceIDJobDetail[i].PlaceID);
                                                }
                                            });

                                            totalCount = objReviewResponse.reviews.Count;

                                        }
                                    }
                                }
                            }
                            int R3 = ObjreviewRepository.UpdateDatashakeLog("Data completed For Placeid : " + objPlaceIDJobDetail[i].PlaceID);

                            #region update jobid
                            DatashakeJobIDDetails _objJobDetails = new DatashakeJobIDDetails();
                            _objJobDetails.DealerId = objPlaceIDJobDetail[i].DealerID;
                            _objJobDetails.PlaceID = objPlaceIDJobDetail[i].PlaceID;
                            _objJobDetails.JobID = jobid;
                            _objJobDetails.ReviewCount = totalCount.ToString();
                            int result = ObjreviewRepository.UpdateDatashakeJobID(_objJobDetails);
                            #endregion

                            int R4 = ObjreviewRepository.UpdateDatashakeLog("Placeid and JOb ID updated  For DealerID : " + objPlaceIDJobDetail[i].DealerID);
                        }

                        catch(Exception ex)
                        {
                            #region update jobid
                            DatashakeJobIDDetails _objJobDetails = new DatashakeJobIDDetails();
                            _objJobDetails.DealerId = objPlaceIDJobDetail[i].DealerID;
                            _objJobDetails.PlaceID = objPlaceIDJobDetail[i].PlaceID;
                            _objJobDetails.JobID = string.Empty;
                            _objJobDetails.ReviewCount = "0";
                            int result = ObjreviewRepository.UpdateDatashakeJobID(_objJobDetails);
                            #endregion

                            int R4 = ObjreviewRepository.UpdateDatashakeLog("Exceptions For DealerID : " + objPlaceIDJobDetail[i].DealerID+" "+ex.Message);
                        }

                    }


                }

                await Task.Delay(TimeSpan.FromMinutes(60), stoppingToken);
                Console.WriteLine("Background services started");
            }

            //}

            // return Task.CompletedTask;
        }


        public override Task StopAsync(CancellationToken cancellationToken)
        {
            _logger.LogInformation("Datasahake service stop execution {datetime}", DateTime.Now);
            return base.StopAsync(cancellationToken);
        }
    }

}
