using LVRMWebAPI.Models.Datashake;
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
        private readonly IServiceScopeFactory _serviceScopeFactory;
        public Guid id { get; set; }
        public MyScopServices(ILogger<MyScopServices> _logger, IDatashakeRepository datashakeRepository, IServiceScopeFactory _serviceScopeFactory)
        {
            this._logger = _logger;
            // id = Guid.NewGuid();
            this.datashakeRepository = datashakeRepository;
            this._serviceScopeFactory = _serviceScopeFactory;
        }
        public void Write()
        {
            _logger.LogInformation("MyScopedservice is {id}", id);
        }
        // DB Hit, get Placeid -- run or not-- IsRun-- true, false,-- place--> jobid
        // If hit, placeid & jobid in another table.--ture,,> job-->diff
        //

        public void RunSchedular(Employees obEmployees)
        {


            //Add Emplyee in Db
            var result = datashakeRepository.AddUser(obEmployees);

            //var placeIdDetails = datashakeRepository.GetPlaceidwithjobid("30232", "ChIJN1t_tDeuEmsRUsoyG83frY4");
            //if (placeIdDetails.Count > 0)
            //{

            //    for (int i = 0; i < placeIdDetails.Count; i++)
            //    {

            //        string JobId = placeIdDetails[0].JobID;
            //        if (string.IsNullOrEmpty(JobId))
            //        {

            //            //Call Datashake api with Only PlaceID
            //            //update the JobId in this Table.

            //            //Call Datasahake API with PlaceID and JobID to Get the Details





            //        }
            //        else
            //        {

            //            bool IsRun = placeIdDetails[0].IsRun;
            //            if (IsRun)
            //            {
            //                // Call Datashake api with Diff param
            //            }
            //            else
            //            {

            //                //Call Datashake api with place and jobid only.

            //                //Check the Review is comming or not.
            //                int ReviewCOunt = 10;
            //                if (ReviewCOunt > 0)
            //                {

            //                    //Map Data review with Datasahke API;

            //                    //Insert Review Table and Update the Status is run 


            //                }


            //            }
            //        }


            //    }

            //}
        }



    }

    public interface IScopedSevices
    {

        void Write();
        void RunSchedular(Employees objEmployees);


    }
}
