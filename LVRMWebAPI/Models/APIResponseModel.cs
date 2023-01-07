using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LVRMWebAPI.Models
{
    public class APIResponseModel
    {
    }
    public class APIResponse
    {
    }
    public class UserResponse
    {

        public string UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Password { get; set; }
    }
    public class DealerResponse
    {
        public string DealerName { get; set; }
    }

    public class UpdateUserResponse
    {
        public int UserId { get; set; }
    }
    public class UpdateDealerResponse
    {
        public int KeyDealershipId { get; set; }
    }

    public class DeleteUserResponse
    {
        public int UserId { get; set; }
    }
}
