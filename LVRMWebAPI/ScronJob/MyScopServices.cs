using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LVRMWebAPI.ScronJob
{
    public class MyScopServices : IScopedSevices
    {
        private readonly ILogger<MyScopServices> _logger;
        public Guid id { get; set; }
        public MyScopServices(ILogger<MyScopServices> _logger)
        {
            this._logger = _logger;
            id = Guid.NewGuid();
        }
        public void Write()
        {
            _logger.LogInformation("MyScopedservice is {id}", id);
        }
        // DB Hit, get Placeid -- run or not-- IsRun-- true, false,-- place--> jobid
        // If hit, placeid & jobid in another table.--ture,,> job-->diff
        //



    }

    public interface IScopedSevices
    {

        void Write();
      
    }
}
