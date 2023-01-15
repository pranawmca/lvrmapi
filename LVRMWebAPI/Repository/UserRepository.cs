using LVRMWebAPI.Extension;
using LVRMWebAPI.Models;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LVRMWebAPI.Repository
{
    public class UserRepository : IUserRepository
    {
        public readonly PSM_DevContext pSM_DevContext;
        public UserRepository(PSM_DevContext _pSM_DevContext)
        {
            pSM_DevContext = _pSM_DevContext;
        }
        public UserDeatails GetUserDetail(int userId)
        {
            try
            {               
                UserDeatails userdetail= new UserDeatails();
                pSM_DevContext.LoadStoredProc("dbo.GetUserByIdApi")
                   .WithSqlParam("KeyUserId", userId)
                   .ExecuteStoredProc((handler) =>
                   {
                       userdetail = handler.ReadToList<UserDeatails>().FirstOrDefault();
                       // do something with your results.
                   });
                return userdetail;

            }
            catch
            {
                throw;
            }
        }
        public List<UserDeatails> GetUserList(UserReqField _objUserReq)
        {
            try
            {
                //UserResponse _objResponse = new UserResponse();
                IList<UserDeatails> userlist = new List<UserDeatails>();
                pSM_DevContext.LoadStoredProc("dbo.GetUsersFromApi")
                   .WithSqlParam("KeyUserId",Convert.ToInt32(_objUserReq.UserID))
                   .WithSqlParam("FirstName", string.IsNullOrEmpty(_objUserReq.FirstName)?"":(object)_objUserReq.FirstName)
                   .WithSqlParam("LastName", string.IsNullOrEmpty(_objUserReq.LastName) ? "" : (object)_objUserReq.LastName)
                   .WithSqlParam("EmailID", string.IsNullOrEmpty(_objUserReq.Email) ? "" : (object)_objUserReq.Email)
                   .ExecuteStoredProc((handler) =>
                   {
                       userlist = handler.ReadToList<UserDeatails>().ToList();
                       // do something with your results.
                   });
                return userlist.ToList();

            }
            catch
            {
                throw;

            }
        }
        public int AddUser(UserRequest _objUserFields)
        {
            try
            {
                int result = 0;
                ReulstMsg objResult = new ReulstMsg();
                pSM_DevContext.LoadStoredProc("dbo.AddUserFromApi")
                  .WithSqlParam("DealerId", Convert.ToInt32(_objUserFields.DealerId))
                  .WithSqlParam("FirstName", (object)_objUserFields.FirstName ?? DBNull.Value)
                  .WithSqlParam("LastName", (object)_objUserFields.LastName ?? DBNull.Value)
                  .WithSqlParam("Email", (object)_objUserFields.Email ?? DBNull.Value)
                  .WithSqlParam("Password", Commoncls.MD5Hash(_objUserFields.Password))
                  .WithSqlParam("Admin", _objUserFields.Admin==true?2:1)
                  .WithSqlParam("PhoneNumber", (object)_objUserFields.PhoneNumber ?? DBNull.Value)
                  .WithSqlParam("Department", (object)_objUserFields.Department ?? DBNull.Value)
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
        public int UpdateUser(UpdateUserRequest _objUserFields)
        {
            try
            {
                int result = 0;
                ReulstMsg objResult = new ReulstMsg();
                pSM_DevContext.LoadStoredProc("dbo.UpdateUserfromApi")
                  .WithSqlParam("KeyUserId", Convert.ToInt32(_objUserFields.UserID))
                  .WithSqlParam("DealerId", Convert.ToInt32(_objUserFields.DealerId))
                  .WithSqlParam("FirstName", (object)_objUserFields.FirstName ?? DBNull.Value)
                  .WithSqlParam("LastName", (object)_objUserFields.LastName ?? DBNull.Value)
                  .WithSqlParam("Email", (object)_objUserFields.Email ?? DBNull.Value)
                  .WithSqlParam("Password", String.IsNullOrEmpty(_objUserFields.Password) ? DBNull.Value : (object)Commoncls.MD5Hash(_objUserFields.Password))
                  .WithSqlParam("Admin", _objUserFields.Admin)
                  .WithSqlParam("PhoneNumber", (object)_objUserFields.PhoneNumber ?? DBNull.Value)                 
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
        public int DeleteUser(DeleteUserRequest _objUserFields)
        {
            try
            {
                int result = 0;
                ReulstMsg objResult = new ReulstMsg();
                pSM_DevContext.LoadStoredProc("dbo.DeleteUserFromAPI")
                  .WithSqlParam("KeyUserId", Convert.ToInt32(_objUserFields.UserID))
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

    public class ReulstMsg
    {     
        public int Message { get; set; }
    }
}
