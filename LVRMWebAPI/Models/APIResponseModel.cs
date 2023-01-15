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
        public int DealerId { get; set; }
        public string UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public bool Admin { get; set; }
        public string PhoneNumber { get; set; }       
        public string Department { get; set; }
    }
    public class DealerResponse
    {
        public int DealerId { get; set; }
        public string DealerName { get; set; }     
        public string PhoneNumber { get; set; }
        public string TimeZone { get; set; }
        public string DealerHomePageURL { get; set; }
        public string ThirdPartySite { get; set; }
        // Optional
        public string LVSuiteID { get; set; }
        public string ReviewInvitationEmail { get; set; }
        public bool RMEnabled { get; set; }
        public bool ReviewWidgetSite { get; set; }
        public bool TrackingScript { get; set; }
        public string ReviewWidgetContainerTag { get; set; }
        public string Industry { get; set; }
        public string FacebookURL { get; set; }
        public bool FacebookEnabled { get; set; }
        public string GoogleLocationID { get; set; }
        public string FacebookReviewURL { get; set; }
        public string GoogleReviewURL { get; set; }

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
    public class DealerResponses
    {
        public int SourceDealerId { get; set; }
        public string DealerName { get; set; }
        public string PhoneNumber { get; set; }
        public string TimeZone { get; set; }
        public string DealerHomePageURL { get; set; }
        public string ThirdPartySite { get; set; }

        // Optional
        public string LVSuiteID { get; set; }
        public string ReviewInvitationEmail { get; set; }
        public bool RMEnabled { get; set; }
        //public bool ReviewWidgetSite { get; set; } 
        public bool TrackingScript { get; set; }
        public string ReviewWidgetContainerTag { get; set; }
        public int? Industry { get; set; }    
        public bool FacebookEnabled { get; set; }
        public string GoogleLocationID { get; set; }
        public string FacebookURL { get; set; }
        //public string FacebookReviewURL { get; set; }
        public string GoogleReviewURL { get; set; }
    }
}
