using LVRMWebAPI.Models.Datashake;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LVRMWebAPI.CommonCronjob
{
    public interface ICronJobManualTriggerCLS
    {
        void CallCronJobManually();
        List<PlaceIdDetailsModel> GetPlaceIDDetails();
        void SaveDealerIDPlaceID(List<PlaceIdDetailsModel> lstModel);
        void MergeDealer();
    }
}
