﻿using LVRMWebAPI.Models.Datashake;
using LVRMWebAPI.Repository;
using Microsoft.Extensions.DependencyInjection;
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
        private readonly IDatashakeRepository datashakeRepository;
        public Guid id { get; set; }
        public MyScopServices(ILogger<MyScopServices> _logger, IDatashakeRepository datashakeRepository)
        {
            this._logger = _logger;
            // id = Guid.NewGuid();
            this.datashakeRepository = datashakeRepository;
        }
        public void Write()
        {
            _logger.LogInformation("MyScopedservice is {id}", id);
        }

        public void RunSchedular(DatashakeReviewField _objDatashakeReviewField)
        {
            //Process to add Datashake reviews in DB
            var result = datashakeRepository.AddDatashakeReview(_objDatashakeReviewField);

        }

    }

    public interface IScopedSevices
    {
        void Write();
        void RunSchedular(DatashakeReviewField _objDatashakeReviewField);


    }
}
