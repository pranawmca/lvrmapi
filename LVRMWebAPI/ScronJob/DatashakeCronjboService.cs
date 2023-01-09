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
        public DatashakeCronjboService(IServiceProvider serviceProvider, ILogger<DatashakeCronjboService> _logger)
        {
            this._logger = _logger;
            _serviceProvider = serviceProvider;
        }
        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
         
            while (!stoppingToken.IsCancellationRequested)
            {


                //create data sahke api
                List<Employees> objEmployeeList = new List<Employees>();
               
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
                await Task.Delay(TimeSpan.FromSeconds(50), stoppingToken);
            

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
