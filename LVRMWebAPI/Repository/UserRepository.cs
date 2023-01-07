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
        public List<UserDeatails> GetUserList(UserReqField _objUserReqField)
        {
            UserResponse _objResponse = new UserResponse();
            List<UserDeatails> userlist = new List<UserDeatails>();
            SqlParameter[] P = new SqlParameter[]{
                    new SqlParameter("@KeyUserId",Convert.ToInt32(_objUserReqField.UserID)),
               };
             userlist = pSM_DevContext.UserDeatails.FromSqlRaw("GetUsersFromApi @KeyUserId", P).ToList();
            return userlist;
        }
    }
}
