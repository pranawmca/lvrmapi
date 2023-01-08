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
                using (var scope = _serviceProvider.CreateScope())
                {

                    _logger.LogInformation("From Datasahake service start execution {datetime}", DateTime.Now);
                    var scopedService = scope.ServiceProvider.GetRequiredService<IScopedSevices>();
                    scopedService.Write();
                    await Task.Delay(TimeSpan.FromSeconds(20), stoppingToken);
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
