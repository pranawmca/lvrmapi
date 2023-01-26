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
        public string GooglePlaceID { get; set; }
        public string FacebookReviewURL { get; set; }
        public string GoogleReviewURL { get; set; }
        public string GUID { get; set; }

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
        //public bool TrackingScript { get; set; }
        public string TrackingScript { get; set; }
        public string ReviewWidgetContainerTag { get; set; }
        public int? Industry { get; set; }    
        public bool FacebookEnabled { get; set; }
        public string GoogleLocationID { get; set; }
        public string FacebookURL { get; set; }
        //public string FacebookReviewURL { get; set; }
        public string GoogleReviewURL { get; set; }
        //Added Field

        public string BadgeGUID { get; set; } 
        public int KeyManufacturerId { get; set; }
        public string Address1 { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Zip { get; set; }


        public string WelcomeMessage { get; set; }
        public string ExcellentReviewMessage { get; set; }
        public string OtherReviewMessage { get; set; }
        public string EmailBody { get; set; }
        public int dealer_id { get; set; }
        public int Status { get; set; }
        public string DateCreated { get; set; }//convert to string
        public string DateLastLoggedIn { get; set; }
     //   public string ThemeName { get; set; }//no need
        public string PDLDomainName { get; set; }

        public string Fax { get; set; }
        public string NewInventoryURL { get; set; }
        public string PreOwnedInventoryURL { get; set; }

        public string GoogleAnalyticsAcct { get; set; }
        public string AddThisProfileID { get; set; }
        public string OpenSunday { get; set; }
        public string CloseSunday { get; set; }
        public string OpenMonday { get; set; }
        public string CloseMonday { get; set; }
        public string OpenTuesday { get; set; }
        public string CloseTuesday { get; set; }
        public string OpenWednesday { get; set; }
        public string CloseWednesday { get; set; }
        public string OpenThursday { get; set; }
        public string CloseThursday { get; set; }
        public string OpenFriday { get; set; }
        public string CloseFriday { get; set; }
        public string OpenSaturday { get; set; }
        public string CloseSaturday { get; set; }
        public string DealerLogoFileName { get; set; }
        public string HeaderBannerFileName { get; set; }
        public int NewInventoryBanner { get; set; }
        public int PreownedInventoryBanner { get; set; }
        public int WriteAReviewBanner { get; set; }
        public int ReviewGroupsBy { get; set; }
        public string DealerBannerAdFileName { get; set; }
        public string ContactName { get; set; }
        public string ContactEmail { get; set; }
        public string ContactPhone { get; set; }
        public string ReviewThankYouExcellentMessage { get; set; }
        public string ReviewThankYouOtherMessage { get; set; }
        public string ReviewVerifiedThankYouMessage { get; set; }
        public string GooglePlacePageURL { get; set; }
        public string GoogleMapURL { get; set; }
        public string EmailHeaderImage { get; set; }
        public string BadReviewHeaderImage { get; set; }
        public string MetaData_Description { get; set; }
        public string MetaData_Keywords { get; set; }
        public string MetaData_MetroArea { get; set; }
        public string MetaData_Country { get; set; }
        public string MetaData_ICBM { get; set; }
        public string CallTrackerAccountId { get; set; }
        public string CallFireAPIKey { get; set; }
        public string CallTrackerGroupId { get; set; }
        public int OriginIdForDMS { get; set; }
        public int OriginIdForWebForm { get; set; }
        public int OriginIdForWalkin { get; set; }
        public string LMSCompanyName { get; set; }
        public string DefaultFeedbackReplyMessage { get; set; }

        public int EmailExpireyDays { get; set; }
        public string VerficationEmailBody { get; set; }
        public string ReferralEmailMessage { get; set; }
        public string GooglePlacesReferalEmail { get; set; }
        public string SecondaryReviewPage { get; set; }

        public string ReviewRequestSubject { get; set; }
        public string VerificationRequestSubject { get; set; }
        public string SecondaryRequestSubject { get; set; }
        public string StoreVisitEmailSubject { get; set; }
        public string StoreVisitEmailBody { get; set; }
        public Boolean Claimed { get; set; }//bit
        public int ReviewCount { get; set; }
        public int FeedbackCount { get; set; }
        public decimal RS_Score { get; set; }
        public Boolean SharpShooterEnabled { get; set; }//bit
        public Boolean ReputationManagementEnabled { get; set; }//bit
        public string ExternalLink1URL { get; set; }
        public string ExternalLink1Target { get; set; }
        public string ExternalLink1Caption { get; set; }
        public string ExternalLink2URL { get; set; }
        public string ExternalLink2Target { get; set; }
        public string ExternalLink2Caption { get; set; }
        public string ExternalLink3URL { get; set; }
        public string ExternalLink3Target { get; set; }
        public string ExternalLink3Caption { get; set; }
        public string ExternalLink4URL { get; set; }
        public string ExternalLink4Target { get; set; }
        public string ExternalLink4Caption { get; set; }
        public int LeadAssignMode { get; set; }
        public int LeadManualTimeout { get; set; }

        public int SSLeadAssignMode { get; set; }
        public int SSLeadTimeout { get; set; }
        public decimal CustomerValue { get; set; }
        public string AdwordsAccount { get; set; }
        public string FaceBookPageId { get; set; }
        public string FaceBookAccessToken { get; set; }

        public int ReviewsPerDayToFacebook { get; set; }
        public int MinReviewLevelToFacebook { get; set; }
        public string TwitterURL { get; set; }
        public string YouTubeURL { get; set; }
        public int StickyFooterStatus { get; set; }
        public string LightspeedDealerId { get; set; }
        public string NizexAPIKey { get; set; }
        public DateTime NizexLastDateRun { get; set; }
        public DateTime LastJumpstartDate { get; set; }
        public DateTime LastLightspeedDate { get; set; }
        public int InactiveCustomerMths { get; set; }
        public Boolean Deleted { get; set; }
     //   public string WS_TagTitleFee { get; set; }//no need
     //   public string WS_SalesTax { get; set; }//no need
     //   public string WS_DocFee { get; set; }//no need
        public string LMS_CompanyId { get; set; }
        public string Vendasta_CompanyId { get; set; }
        public string Latitude { get; set; }
        public string Longitude { get; set; }
        public int CustomerGroupsCount { get; set; }
        public int CustomerMaxMiles { get; set; }
      //  public string WS_Freight { get; set; }//no need
     //   public string WS_AssemblySetup { get; set; }//no need
        public Boolean SalesWorkSheetActive { get; set; }
        public string LeadMagnetTYPage { get; set; }
        public int DoNotEmailAfterReviewDays { get; set; }
        public int DoNotEmailAfterFeedbackDays { get; set; }
        public bool IncludeReviewSiteOnPDL { get; set; }//important column
        public int LightSpeedDelay { get; set; }
        public string SideLink1ImageURL { get; set; }
        public string SideLink2ImageURL { get; set; }
        public Boolean WrapReviewHeader { get; set; }
        public string SharpshooterUpdateEmailText { get; set; }
        public string SharpshooterWrapUpEmailText { get; set; }
        public string AOContactName { get; set; }
        public string AOContactEmail { get; set; }
        public string AOContactPhone { get; set; }
        public string SSEmailAddress { get; set; }
        public string BlogURL { get; set; }
        public string DealerLogoURL { get; set; }
        public string DealerSignature { get; set; }
        public string DMSReviewText { get; set; }
        public string DMSReviewSubject { get; set; }
        public string InstagramURL { get; set; }

        public Boolean ExportLeadsToDominion { get; set; }
        public string DominionDealerId { get; set; }
        public string TagManagerId { get; set; }
        public int MinReviewLevelToSticky { get; set; }
        public string HoursText { get; set; }
        public string HogURL { get; set; }
        public string ReviewRequestLandingText { get; set; }
        public Boolean DisplayEmployeeDropDownOnReviewSite { get; set; }
        public string SideLinkReviewURL { get; set; }
        public string ReviewBarBackColor { get; set; }
        public string ReviewBarTextColor { get; set; }
        public Boolean ReviewBarShowNewsletterSignup { get; set; }
        public string FacebookAdAccountId { get; set; }
        public string DirectionsURL { get; set; }
        public string ContactUsURL { get; set; }
       // public string AccountExecutive { get; set; }//no need

        public Boolean SendOnboardingEmails { get; set; }
        public Boolean SendOnboardingSummaryEmails { get; set; }
        public int DeptResetInDays { get; set; }
        public Boolean AutoPostSalesToFacebook { get; set; }
        public Boolean AutoSendSalesReviewRequest { get; set; }
        public Boolean AutoSendSalesThankYouEmail { get; set; }
        public string GooglePremium { get; set; }
        public string ThanksForYourPurchaseText { get; set; }
        public string ThanksForYourPurchaseSubject { get; set; }
        public string NewPurchaseReviewRequestText { get; set; }
        public string NewPurchaseReviewRequestSubject { get; set; }
        public string NewPurchaseFacebook { get; set; }
        public int NutureExpireyInDays { get; set; }

        public Decimal RS_Score2 { get; set; }
        public Boolean Active { get; set; }
        public Boolean HasWebsite { get; set; }
        public DateTime LastScriptFireDate { get; set; }
        public string DX1Id { get; set; }
        public DateTime LastDMSInventoryDate { get; set; }
        public string ThanksForYourPurchasePreviewText { get; set; }
        public string NewPurchaseReviewRequestPreviewText { get; set; }
        public int ReviewRequestEmailLimit { get; set; }
        public int ReviewInvitationGoal { get; set; }
        public decimal ReviewInvitationConversionRate { get; set; }
        public string GoogleAnalyticsViewId { get; set; }
        public string LotVantageDealerId { get; set; }
        public string AODealerSignature { get; set; }
        public DateTime LastNonEmptyCustomerFileDate { get; set; }
        public DateTime LastNonEmptyInventoryFileDate { get; set; }
        public string PublicEmailAddress { get; set; }
        public string ReviewTextMessage { get; set; }
        public string SendgridApiKey { get; set; }
        public string SendgridUsername { get; set; }
        public string SendgridPassword { get; set; }
        public string SendgridIPPool { get; set; }
        public Boolean SendgridSubuserActive { get; set; }
       // public string SendgridWarmupCount { get; set; }//no need

        public string Auction123DealerId { get; set; }
        public string HDDealerCode { get; set; }
        public string ServiceOpenSunday { get; set; }
        public string ServiceCloseSunday { get; set; }
        public string ServiceOpenMonday { get; set; }
        public string ServiceCloseMonday { get; set; }
        public string ServiceOpenTuesday { get; set; }
        public string ServiceCloseTuesday { get; set; }
        public string ServiceOpenWednesday { get; set; }
        public string ServiceCloseWednesday { get; set; }
        public string ServiceOpenThursday { get; set; }
        public string ServiceCloseThursday { get; set; }
        public string ServiceOpenFriday { get; set; }
        public string ServiceCloseFriday { get; set; }
        public string ServiceOpenSaturday { get; set; }
        public string ServiceCloseSaturday { get; set; }
        public string ServiceURL { get; set; }
        public string SalesPhone { get; set; }
        public string ServicePhone { get; set; }
        public string PartsPhone { get; set; }
        public string CPOURL { get; set; }
        public string AlternateURL { get; set; }
        public string FirestormFromName { get; set; }
        public string FirestormFromEmail { get; set; }
        public string PhoneExtension { get; set; }
        public Boolean EnableCopyTo250OK { get; set; }
        public Boolean SendEmailFromCustomDomain { get; set; }
        public string NewsletterSignupLink { get; set; }
        public DateTime LastScriptFireDateReviewSite { get; set; }
        public Boolean BullseyeEnabled { get; set; }
        public string PolarisDealerCode { get; set; }
        public string ClosedHoursOverrideText { get; set; }
        public string ClosedHoursOverrideServiceText { get; set; }
        public string FBPostCustomerEmailBody { get; set; }
        public string FBPostCustomerEmailSubject { get; set; }
        public Boolean EnableChatBubble { get; set; }
        public string ChatBubbleHexColor { get; set; }
        public string ChatBubbleTextColor { get; set; }
        public int TextBubbleBottomPos { get; set; }
        public int TextBubbleRightPos { get; set; }
        public int ChatBubblePosition { get; set; }
        public Boolean EnableChatBubbleFirstName { get; set; }
        public Boolean EnableChatBubbleLastName { get; set; }
        public Boolean EnableChatBubbleDepartments { get; set; }
        public int TextMessageDelayMinutes { get; set; }
        public Boolean DMSIntegrationActive { get; set; }
        public string CustomHoursTextMonday { get; set; }
        public string CustomHoursTextTuesday { get; set; }
        public string CustomHoursTextWednesday { get; set; }
        public string CustomHoursTextThursday { get; set; }
        public string CustomHoursTextFriday { get; set; }
        public string CustomHoursTextSaturday { get; set; }
        public string CustomHoursTextSunday { get; set; }
        public string CustomServiceHoursTextMonday { get; set; }
        public string CustomServiceHoursTextTuesday { get; set; }
        public string CustomServiceHoursTextWednesday { get; set; }
        public string CustomServiceHoursTextThursday { get; set; }
        public string CustomServiceHoursTextFriday { get; set; }
        public string CustomServiceHoursTextSaturday { get; set; }
        public string CustomServiceHoursTextSunday { get; set; }
        public Boolean DealerVueCustomerIntegrationActive { get; set; }
        public string FacebookPixelId { get; set; }
        public string GoogleAnalyticsPhoneGoalTag { get; set; }
        public Boolean VDPEmailRemarketingActive { get; set; }
        public int MobileChatBubblePosition { get; set; }
        public Boolean ReviewRequestEmailEnabled { get; set; }
        public Boolean DMSReviewEmailEnabled { get; set; }
        public Boolean ReviewLandingPageEnabled { get; set; }
        public Boolean FeedbackLandingPageEnabled { get; set; }
        public Boolean ReviewTYPageEnabled { get; set; }
        public Boolean FeedbackTYPageEnabled { get; set; }
        public Boolean ReviewReferralEmailEnabled { get; set; }
        public Boolean ReviewReferralLandingEnabled { get; set; }
        public Boolean LeadMagnetTYEmailEnabled { get; set; }
        public Boolean ReviewRequestPageEnabled { get; set; }
        public Boolean MANewSaleEmailEnabled { get; set; }
        public Boolean MANewPurchaseReviewRequestEnabled { get; set; }
        public Boolean MANewPurchaseFacebookEnabled { get; set; }
        public Boolean MAReviewTextMessageEnabled { get; set; }
        public Boolean FacebookPostEmailEnabled { get; set; }
        public Boolean LinkToLWDSite { get; set; }
        public string CustomCCButtonText { get; set; }
        public Boolean ImportThirdPartyInventory { get; set; }
       // public string ThirdPartyWebsiteTypeId { get; set; }//no need
        public string TextNumber { get; set; }
        public string BAInitialReviewRequest { get; set; }
        public string BASocial { get; set; }
      //  public string GoogleAnalyticsVersionId { get; set; }//no need
        public string FacebookToken { get; set; }
        public Boolean FacebookTokenOverride { get; set; }
        public string MotilityUsername { get; set; }
        public string MotilityPassword { get; set; }
        public string MotilityAccountId { get; set; }
        public int AEMLevelId { get; set; }
        public string RimmsId { get; set; }
        public string MotilityIntegrationId { get; set; }


        public Boolean LoadWelcomeBackBox { get; set; }
        public int WelcomeBackBoxLocation { get; set; }
        public string WelcomeBackBoxButtonText { get; set; }
        public int WelcomeBackBoxDefaultState { get; set; }
        public string PrivacyPolicyURL { get; set; }
        public int AEMReportBrandId { get; set; }
        public string LVCRMGUID { get; set; }
       // public string TextingNumberOption { get; set; }//no need
        public int AEMRepId { get; set; }
        public DateTime AEMActiveDate { get; set; }
        public DateTime AEMInactiveDate { get; set; }
        public Boolean EnableFacebookReviewsOnLandingPage { get; set; }
        public Boolean EnableGoogleReviewsOnLandingPage { get; set; }
        public int WelcomeBackBoxMobileLocation { get; set; }
        public string WelcomeBackBoxDesktopAdjustment { get; set; }
        public string WelcomeBackBoxMobileAdjustment { get; set; }
        public Boolean DMSTextingEnabled { get; set; }


    }
}
