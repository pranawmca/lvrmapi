using LVRMWebAPI.Models.Datashake;
using LVRMWebAPI.Repository;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LVRMWebAPI.ScronJob
{
    public class MyScopServicesMannual: IMyScopServicesMannual
    {
        private readonly ILogger<MyScopServices> _logger;
        private readonly IDatashakeRepositoryMannual datashakeRepository;
        public MyScopServicesMannual(ILogger<MyScopServices> _logger, IDatashakeRepositoryMannual datashakeRepository)
        {

            this._logger = _logger;
            this.datashakeRepository = datashakeRepository;
        }

        public void RunSchedularMannual(Review _objDatashakeReviewField, string source_name, double average_rating, string dealerid, string placeidvalue)
        {
            //Process to add Datashake reviews in DB
            var result = datashakeRepository.AddDatashakeReview(_objDatashakeReviewField, source_name, average_rating, dealerid, placeidvalue);

        }
    }

    public interface IMyScopServicesMannual
    {
            void RunSchedularMannual(Review _objDatashakeReviewField, string source_name, double average_rating, string dealerid, string placeidvalue);


    }
}
