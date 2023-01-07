using LVRMWebAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LVRMWebAPI.Repository
{
    public class JobPlaceIdRepository: IJobPlaceIdRepository
    {
        public readonly PSM_DevContext pSM_DevContext;
        public JobPlaceIdRepository(PSM_DevContext _pSM_DevContext)
        {
            pSM_DevContext = _pSM_DevContext; 
        }

       

    }
}
