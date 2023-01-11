using LVRMWebAPI.Models.Datashake;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace LVRMWebAPI.ScronJob
{
    public class DatashakeCronjboService : BackgroundService
    {
        private readonly ILogger<DatashakeCronjboService> _logger;
        private readonly IServiceProvider _serviceProvider;
        private static bool _isFlag = false;
        public DatashakeCronjboService(IServiceProvider serviceProvider, ILogger<DatashakeCronjboService> _logger)
        {
            this._logger = _logger;
            _serviceProvider = serviceProvider;
        }
        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {

            while (!stoppingToken.IsCancellationRequested)
            {

               // if (_isFlag == false)
                // {

                // setp 1: Method to get dealer deatils with placeid

               


                    _isFlag = true;
                    List<PlaceIDJobDetail> objPlaceIDJobDetail = new List<PlaceIDJobDetail>()
                    {
                        new PlaceIDJobDetail(){ DealerID="31341", PlaceID="1515545", IsRun=false, JobID="TEst"},
                         new PlaceIDJobDetail(){ DealerID="45245", PlaceID="4254", IsRun=false, JobID="abc"},
                         new PlaceIDJobDetail(){ DealerID="2452435", PlaceID="2452345", IsRun=false, JobID="xyz"},
                         new PlaceIDJobDetail(){ DealerID="2452435", PlaceID="2452345", IsRun=false, JobID="klm"},
                         new PlaceIDJobDetail(){ DealerID="2452435", PlaceID="2452345", IsRun=false, JobID="pqr"}
                    };

                    if (objPlaceIDJobDetail != null && objPlaceIDJobDetail.Count > 0)
                    {
                        for (int i = 0; i < objPlaceIDJobDetail.Count; i++)
                        {
                        // Setp 2: Call datasahke api

                        List<DatashakeReviewField> objEmployeeList = new List<DatashakeReviewField>();
                        //    for (int j = 0; j < 1000; j++)
                        //    {

                        //        Employees employees = new Employees();
                        //        employees.EmpID = Convert.ToInt32(objPlaceIDJobDetail[i].DealerID);
                        //        employees.Department = objPlaceIDJobDetail[i].JobID + j;
                        //        employees.Name = objPlaceIDJobDetail[i].JobID + j;
                        //        objEmployeeList.Add(employees);
                        //    }

                            objEmployeeList.AsParallel()
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
                 //   }
                    await Task.Delay(TimeSpan.FromMinutes(20), stoppingToken);
                }


            }
            Console.WriteLine("Background services started");
            // return Task.CompletedTask;
        }

        public override Task StopAsync(CancellationToken cancellationToken)
        {
            _logger.LogInformation("Datasahake service stop execution {datetime}", DateTime.Now);
            return base.StopAsync(cancellationToken);
        }
    }

}
