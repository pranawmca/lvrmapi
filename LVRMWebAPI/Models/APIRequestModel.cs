using FluentValidation;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Net;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace LVRMWebAPI.Models
{
    public class APIRequestModel
    {
    }

    public class APIModel
    {
    }
    public class MenuDetails
    {
        public string Title { get; set; }
        public string MenuUrl { get; set; }
    }
    public class MenuRequestParam
    {
        public string SsoLogin { get; set; }
    }
    public class MenuResponseData
    {
        public bool Status { get; set; }
        public string Message { get; set; }
        public List<MenuDetails> MenuDetails { get; set; }
    }
    public class UserRequest
    {
        public int DealerId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        [DefaultValue(false)]
        public bool Admin { get; set; }
        public string PhoneNumber { get; set; }
        public string Password { get; set; }
        public string Department { get; set; }
    }


    public class Response
    {
        public bool Status { get; set; }
        public string Message { get; set; }
        public HttpStatusCode StatusCode { get; set; }
        public object Data { get; set; }
    }

    public class InvalidResponse
    {
        public string Message { get; set; }
        public string Code { get; set; }
        public IEnumerable<Details> details { get; set; }
    }
    public class Details
    {
        public string AttributeName { get; set; }
        public string Reason { get; set; }
    }
    public class InvalidResponses
    {
        public IEnumerable<InvalidResponse> Errors { get; set; }
    }
    public class UserValidator : AbstractValidator<UserRequest>
    {
        public UserValidator()
        {
            RuleFor(x => x.FirstName).NotEmpty().WithMessage("First Name is required");
            RuleFor(x => x.LastName).NotEmpty().WithMessage("Last Name is required");
            RuleFor(x => x.DealerId).NotEmpty().WithMessage("DealerID is required");
            RuleFor(x => x.Email).NotEmpty().WithMessage("Email is required").EmailAddress().WithMessage("Invalid email address");
            RuleFor(x => x.Admin).NotNull().WithMessage("Admin field is required");
            When(x => !string.IsNullOrEmpty(x.PhoneNumber), () => { RuleFor(x => x.PhoneNumber).Must(CheckNumber).WithMessage("Invalid phone number"); }) ;
        }

        public bool CheckNumber(string strPhoneNumber)
        {
            string MatchPhoneNumberPattern = @"^\(?([0-9]{3})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{4})$";
            if (strPhoneNumber != null)
                return Regex.IsMatch(strPhoneNumber, MatchPhoneNumberPattern);
            else return false;
        }

    }
    public class GetUserValidator : AbstractValidator<UserField>
    {
        public GetUserValidator()
        {
            RuleFor(x => x.UserID).NotEmpty().WithMessage("User Idis required");
            // RuleFor(x => x.PhoneNumber).Must(CheckNumber).WithMessage("Invalid phone number");

        }

        public bool CheckNumber(string strPhoneNumber)
        {
            string MatchPhoneNumberPattern = @"^\(?([0-9]{3})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{4})$";
            if (strPhoneNumber != null)
                return Regex.IsMatch(strPhoneNumber, MatchPhoneNumberPattern);
            else return false;
        }

    }
    public class UpdateUserRequest : UserRequest
    {
        public int UserID { get; set; }
    }
    public class UpdateUserValidator : AbstractValidator<UpdateUserRequest>
    {
        public UpdateUserValidator()
        {
            RuleFor(x => x.UserID).NotEmpty().WithMessage("User Id is required");
            //RuleFor(x => x.FirstName).NotEmpty().WithMessage("First Name is required");
            //RuleFor(x => x.LastName).NotEmpty().WithMessage("Last Name is required");
            RuleFor(x => x.DealerId).NotEmpty().WithMessage("DealerID is required");
            //RuleFor(x => x.Email).EmailAddress().WithMessage("Invalid email address");
            //RuleFor(x => x.Admin).NotEmpty().WithMessage("Admin field is required");
            //RuleFor(x => x.PhoneNumber).Must(CheckNumber).WithMessage("Invalid phone number");
        }

        public bool CheckNumber(string strPhoneNumber)
        {
            string MatchPhoneNumberPattern = @"^\(?([0-9]{3})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{4})$";
            if (strPhoneNumber != null)
                return Regex.IsMatch(strPhoneNumber, MatchPhoneNumberPattern);
            else return false;
        }

    }
    public class DeleteUserRequest
    {
        public int UserID { get; set; }
    }
    public class DeleteUserValidator : AbstractValidator<DeleteUserRequest>
    {
        public DeleteUserValidator()
        {
            RuleFor(x => x.UserID).NotEmpty().WithMessage("User Id is required");
        }
    }

    #region Delaer class

    public class DealerRequest
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
        public bool ReviewWidgetSite { get; set; }
        //public List<ReviewProfiles> reviewProfile { get; set; }
        public bool TrackingScript { get; set; }
        public string ReviewWidgetContainerTag { get; set; }
        public string Industry { get; set; }
        public string FacebookURL { get; set; }
        public bool FacebookEnabled { get; set; }
        public string GoogleLocationID { get; set; }
        public string FacebookReviewURL { get; set; }
        public string GoogleReviewURL { get; set; }
        [JsonIgnore]
        public string BadgeGUID { get; set; }
        
    }
    public class DealerValidator : AbstractValidator<DealerRequest>
    {
        public DealerValidator()
        {
            RuleFor(x => x.DealerName).NotEmpty().WithMessage("Dealer Name is required");
            RuleFor(x => x.PhoneNumber).Must(CheckNumber).WithMessage("Invalid phone number");
            RuleFor(x => x.TimeZone).NotEmpty().WithMessage("TimeZone is required");
            RuleFor(x => x.DealerHomePageURL).NotEmpty().WithMessage("Home Page URL is required");
            RuleFor(x => x.ThirdPartySite).NotEmpty().WithMessage("Third Party Site is required");
        }

        public bool CheckNumber(string strPhoneNumber)
        {
            string MatchPhoneNumberPattern = @"^\(?([0-9]{3})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{4})$";
            if (strPhoneNumber != null)
                return Regex.IsMatch(strPhoneNumber, MatchPhoneNumberPattern);
            else return false;
        }

    }
    public class UpdateDealerRequest : DealerRequest
    {
        //public int SourceDealerId { get; set; }
    }
    public class DealerSearch
    {
        public string SourceDealerId { get; set; }
    }
    public class UpdateDealerValidator : AbstractValidator<UpdateDealerRequest>
    {
        public UpdateDealerValidator()
        {
            RuleFor(x => x.SourceDealerId).NotEmpty().WithMessage("Dealer Id is required"); 
            When(x => !string.IsNullOrEmpty(x.PhoneNumber), () => { RuleFor(x => x.PhoneNumber).Must(CheckNumber).WithMessage("Invalid phone number"); });           
            //RuleFor(x => x.TimeZone).NotEmpty().WithMessage("TimeZone is required");
            //RuleFor(x => x.DealerHomePageURL).NotEmpty().WithMessage("Home Page URL is required");
            //RuleFor(x => x.ThirdPartySite).NotEmpty().WithMessage("Third Party Site is required");
        }

        public bool CheckNumber(string strPhoneNumber)
        {
            string MatchPhoneNumberPattern = @"^\(?([0-9]{3})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{4})$";
            if (strPhoneNumber != null)
                return Regex.IsMatch(strPhoneNumber, MatchPhoneNumberPattern);
            else return false;
        }

    }
    public class DeleteDealerRequest
    {
        public int SourceDealerId { get; set; }
    }
    public class DeleteDealerValidator : AbstractValidator<DeleteDealerRequest>
    {
        public DeleteDealerValidator()
        {
            RuleFor(x => x.SourceDealerId).NotEmpty().WithMessage("Dealer Id is required");
        }
    }
    public class DealerSearchValidator : AbstractValidator<DealerSearch>
    {
        public DealerSearchValidator()
        {
            RuleFor(x => x.SourceDealerId).NotEmpty().WithMessage("Dealer Id is required");
        }
    }
    #endregion

    public class ReviewProfiles
    {
        public string URL { get; set; }
    }
    public class UserField : UserRequest
    {
        [Key]
        public int UserID { get; set; }
    }
    public class DealerUser
    {
        public string DealerID { get; set; }
    }
    public class DealerUserValidator : AbstractValidator<DealerUser>
    {
        public DealerUserValidator()
        {
            RuleFor(x => x.DealerID).NotEmpty().WithMessage("Dealer Id is required");
        }
    }
    public class UserReqField
    {
        public int UserID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
    }
    public class UserDeatails 
    {
        [Key]
        public int UserID { get; set; }
        public int DealerId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
    }


}
