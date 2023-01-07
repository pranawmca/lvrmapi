using LVRMWebAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LVRMWebAPI.Repository
{
    public interface IUserRepository
    {
        List<UserDeatails> GetUserList(UserReqField _objUserReqField);
    }
}
