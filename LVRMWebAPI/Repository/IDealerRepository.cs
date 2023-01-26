using LVRMWebAPI.Models;
using System.Collections.Generic;

namespace LVRMWebAPI.Repository
{
    public interface IDealerRepository
    {
        DealerResponses GetDealerById(int dealerId);
        List<DealerResponses> GetDealer(DealerSearch _objDealerSearch);
        //int AddDealer(DealerRequest _objDealerFields);
        DealerResponses AddDealer(DealerRequest _objDealerFields);
        int UpdateDealer(UpdateDealerRequest _objDealerFields);
        int DeleteDealer(DeleteDealerRequest _objDealerFields);
    }
}
