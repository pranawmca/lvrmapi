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
        private readonly IDatashakeRepository _dataShakeRepo;
        private readonly IReviewRepository _reviewRepository;
        private static bool _isFlag = false;
        public DatashakeCronjboService(IServiceProvider serviceProvider, ILogger<DatashakeCronjboService> _logger)//, 
        {
            this._logger = _logger;
            _serviceProvider = serviceProvider;
            //_reviewRepository = reviewRepository;
            //this._dataShakeRepo = _dataShakeRepo;
        }
        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {

            while (!stoppingToken.IsCancellationRequested)
            {

                //if (_isFlag == false)
                //{
                // setp 1: Method to get dealer deatils with placeid

                ReviewRepository ObjreviewRepository = new ReviewRepository();
                List<PlaceIDJobDetail> objPlaceIDJobDetail = ObjreviewRepository.GetPlaceidwithjobid("", "");
                //List<PlaceIDJobDetail> objPlaceIDJobDetail = new List<PlaceIDJobDetail>();
                if (objPlaceIDJobDetail != null && objPlaceIDJobDetail.Count > 0)
                {
                    for (int i = 0; i < objPlaceIDJobDetail.Count; i++)
                    {
                        // Setp 2: Call datasahke api with Place id to get job id
                        int jobid = 0;
                        // object objPlaceIdResponse = DataShakeClientCall.GetDataShakeAPIPlaceidResponse(objPlaceIDJobDetail[i].PlaceID, "0ded0923c6537d61c5d8b0dd03877b0e46b8ac73");
                        object objPlaceIdResponse = "{\"success\":true,\"job_id\":453375210,\"status\":200,\"message\":\"Added this profile to the queue...\"}";

                        var data = (JObject)JsonConvert.DeserializeObject(objPlaceIdResponse.ToString());
                        if (Convert.ToBoolean(((Newtonsoft.Json.Linq.JValue)data["success"]).Value))
                        {
                            jobid = Convert.ToInt32(((Newtonsoft.Json.Linq.JValue)data["job_id"]).Value);
                        }
                        // save job id and isrun to database here
                        //
                        //get review from datashake api
                        DataShakeApiResponseModel objReviewResponse = DataShakeClientCall.GetDataShakeAPIResponse(jobid, "0ded0923c6537d61c5d8b0dd03877b0e46b8ac73");
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
                                    scopedService.RunSchedular(itemId);
                                }
                            });
                        }

                    }
                }

                await Task.Delay(TimeSpan.FromMinutes(20), stoppingToken);
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
