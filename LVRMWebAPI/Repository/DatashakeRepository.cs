using LVRMWebAPI.Extension;
using LVRMWebAPI.Models;
using LVRMWebAPI.Models.Datashake;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LVRMWebAPI.Repository
{
    public class DatashakeRepository : IDatashakeRepository
    {
        public readonly PSM_DevContext pSM_DevContext;
        public DatashakeRepository(PSM_DevContext _pSM_DevContext)
        {
            pSM_DevContext = _pSM_DevContext;
        }
        public List<PlaceIDJobDetail> GetPlaceidwithjobid(string DealerID, string PlaceID)
        {
            try
            {
                //UserResponse _objResponse = new UserResponse();
                IList<PlaceIDJobDetail> userlist = new List<PlaceIDJobDetail>();
                pSM_DevContext.LoadStoredProc("dbo.GetUsersFromApi")
                   .WithSqlParam("PlaceID", PlaceID)
                   .WithSqlParam("DealerID", DealerID)
                   .ExecuteStoredProc((handler) =>
                   {
                       userlist = handler.ReadToList<PlaceIDJobDetail>().ToList();
                       // do something with your results.
                   });
                return userlist.ToList();
            }

            catch
            {

                throw;
            }
        }

        public int AddUser(Employees _objEmploye)
        {
            try
            {
                int result = 0;
                ReulstMsg objResult = new ReulstMsg();
                pSM_DevContext.LoadStoredProc("dbo.USP_TestReviewSchedular")
                  .WithSqlParam("place_id", _objEmploye.Department)
                  .WithSqlParam("job_id", _objEmploye.EmpID)
                  .WithSqlParam("review_count", "200")
                  .WithSqlParam("Source", "source"+ _objEmploye.EmpID)
                  .WithSqlParam("ReviewID", "2929")
                  .WithSqlParam("FirstName", _objEmploye.Name)

                  .ExecuteStoredProc((handler) =>
                  {
                      objResult = handler.ReadToList<ReulstMsg>().FirstOrDefault();
                      // do something with your results.
                  });

                result = Convert.ToInt32(objResult.Message);
                return result;
            }
            catch
            {

                throw;
            }
        }
    }


}
