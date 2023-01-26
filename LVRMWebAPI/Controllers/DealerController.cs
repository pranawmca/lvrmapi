using LVRMWebAPI.Models;
using LVRMWebAPI.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using System;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;
using Microsoft.AspNetCore.Authorization;
using System.Net;

namespace LVRMWebAPI.Controllers
{
    [Authorize]
    [Route("api/dealer-service")]
    [ApiController]
    public class DealerController : ControllerBase
    {

       private readonly IDealerRepository dealerRepository;
       
        public DealerController(IDealerRepository _dealerRepository)
        {
            dealerRepository = _dealerRepository;
        }

        [HttpGet]
        [Route("getDealer/{dealerID}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> getDealerByID(int dealerID)
        {
            Response _objResponse = new Response();
            DealerResponses _objResp = new DealerResponses();
            _objResp = dealerRepository.GetDealerById(dealerID);
            if (_objResp!=null && _objResp.DealerName != null && _objResp.DealerName != "")
                return Ok(_objResp);
            else
            {
                _objResponse.Data = "";
                _objResponse.Message = "Dealer does not exists.";
                _objResponse.Status = false;
                _objResponse.StatusCode = HttpStatusCode.BadRequest;
                return BadRequest(_objResponse);
            }
        }

        //[HttpPost]
        //[Route("getDealer")]
        //[ProducesResponseType(StatusCodes.Status200OK)]
        //[ProducesResponseType(StatusCodes.Status400BadRequest)]
        //public async Task<IActionResult> getDealer(DealerSearch _objDealerSearch)
        //{
        //    Response _objResponse = new Response();
        //    if (_objDealerSearch == null)
        //    {
        //        return BadRequest("Invalid payload");
        //    }
        //    if (!ModelState.IsValid)
        //    {

        //    }
        //    var data = dealerRepository.GetDealer(_objDealerSearch);
        //    return Ok(data);
        //}


        [HttpPost]
        [Route("addDealer")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> addDealer(DealerRequest _objDealerFields)
        {
            Response _objResponse = new Response();
            // DealerResponse _dealerResponse = new DealerResponse();
            DealerResponses _dealerResponse = new DealerResponses();
              
            if (_objDealerFields == null)
            {
                return BadRequest("Invalid payload");
            }
            if (!ModelState.IsValid)
            {

            }
            //_objDealerFields.BadgeGUID = guid;
            _dealerResponse = dealerRepository.AddDealer(_objDealerFields);
            if (_dealerResponse.SourceDealerId > 0)
            {
                //_dealerResponse.DealerId = resultResponse;
                //_dealerResponse.DealerName = _objDealerFields.DealerName;
                //_dealerResponse.PhoneNumber = _objDealerFields.PhoneNumber;
                //_dealerResponse.TimeZone = _objDealerFields.TimeZone;
                //_dealerResponse.DealerHomePageURL = _objDealerFields.DealerHomePageURL;
                //_dealerResponse.ThirdPartySite = _objDealerFields.ThirdPartySite;
                //_dealerResponse.LVSuiteID = _objDealerFields.LVSuiteID;
                //_dealerResponse.ReviewInvitationEmail = _objDealerFields.ReviewInvitationEmail;
                //_dealerResponse.RMEnabled = _objDealerFields.RMEnabled;
                //_dealerResponse.ReviewWidgetSite = _objDealerFields.ReviewWidgetSite;
                ////_dealerResponse.TrackingScript = _objDealerFields.TrackingScript;
                //_dealerResponse.ReviewWidgetContainerTag = _objDealerFields.ReviewWidgetContainerTag;
                //_dealerResponse.Industry = _objDealerFields.Industry;
                //_dealerResponse.FacebookURL = _objDealerFields.FacebookURL;
                //_dealerResponse.FacebookEnabled = _objDealerFields.FacebookEnabled;
                //_dealerResponse.GooglePlaceID = _objDealerFields.GoogleLocationID;
                //_dealerResponse.FacebookReviewURL = _objDealerFields.FacebookReviewURL;
                //_dealerResponse.GoogleReviewURL = _objDealerFields.GoogleReviewURL;
                //_dealerResponse.GUID = guid;
                _objResponse.Data = _dealerResponse;
                _objResponse.Message = "Dealer Created Successfully";
                _objResponse.Status = true;
               _objResponse.StatusCode = System.Net.HttpStatusCode.OK;
                return Ok(_objResponse);
            }
            else
            {
                _objResponse.Data = "";
                _objResponse.Message = "Failed! Please try later.";
                _objResponse.Status = false;
                _objResponse.StatusCode = System.Net.HttpStatusCode.InternalServerError;
                return BadRequest(_objResponse);
            }
            //if (resultResponse > 0)
            //{
            //    _dealerResponse.DealerId = resultResponse;
            //    _dealerResponse.DealerName = _objDealerFields.DealerName;
            //    _dealerResponse.PhoneNumber = _objDealerFields.PhoneNumber;
            //    _dealerResponse.TimeZone = _objDealerFields.TimeZone;
            //    _dealerResponse.DealerHomePageURL = _objDealerFields.DealerHomePageURL;
            //    _dealerResponse.ThirdPartySite = _objDealerFields.ThirdPartySite;
            //    _dealerResponse.LVSuiteID = _objDealerFields.LVSuiteID;
            //    _dealerResponse.ReviewInvitationEmail = _objDealerFields.ReviewInvitationEmail;
            //    _dealerResponse.RMEnabled = _objDealerFields.RMEnabled;
            //    _dealerResponse.ReviewWidgetSite = _objDealerFields.ReviewWidgetSite;
            //    //_dealerResponse.TrackingScript = _objDealerFields.TrackingScript;
            //    _dealerResponse.ReviewWidgetContainerTag = _objDealerFields.ReviewWidgetContainerTag;
            //    _dealerResponse.Industry = _objDealerFields.Industry;
            //    _dealerResponse.FacebookURL = _objDealerFields.FacebookURL;
            //    _dealerResponse.FacebookEnabled = _objDealerFields.FacebookEnabled;
            //    _dealerResponse.GooglePlaceID = _objDealerFields.GoogleLocationID;
            //    _dealerResponse.FacebookReviewURL = _objDealerFields.FacebookReviewURL;
            //    _dealerResponse.GoogleReviewURL = _objDealerFields.GoogleReviewURL;
            //    _dealerResponse.GUID = guid;
            //    _objResponse.Data = _dealerResponse;
            //    _objResponse.Message = "Dealer Created Successfully";
            //    _objResponse.Status = true;
            //    _objResponse.StatusCode = System.Net.HttpStatusCode.OK;
            //    return Ok(_objResponse);
            //}
            //else
            //{
            //    _objResponse.Data = "";
            //    _objResponse.Message = "Failed! Please try later.";
            //    _objResponse.Status = false;
            //    _objResponse.StatusCode = System.Net.HttpStatusCode.InternalServerError;
            //    return BadRequest(_objResponse);
            //}
        }

        [HttpPut]
        [Route("updateDealer")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> updateDealer(UpdateDealerRequest _objUpdateDealerFields)
        {
            Response _objResponse = new Response();
            UpdateDealerResponse _objUpdateDealerResponse = new UpdateDealerResponse();
            if (_objUpdateDealerFields == null)
            {
                return BadRequest("Invalid payload");
            }
            if (!ModelState.IsValid)
            {

            }
            int resultResponse = dealerRepository.UpdateDealer(_objUpdateDealerFields);
            if (resultResponse == 2000)
            {
                _objUpdateDealerResponse.KeyDealershipId = _objUpdateDealerFields.SourceDealerId;
                _objResponse.Data = _objUpdateDealerResponse;
                _objResponse.Message = "Dealer Updated Successfully";
                _objResponse.Status = true;
                _objResponse.StatusCode = System.Net.HttpStatusCode.OK;
                return Ok(_objResponse);
            }
            else
            {
                _objResponse.Data = "";
                _objResponse.Message = "Failed! Please try later.";
                _objResponse.Status = false;
                _objResponse.StatusCode = System.Net.HttpStatusCode.InternalServerError;
                return BadRequest(_objResponse);

            }
        }
        [HttpDelete]
        [Route("deleteDealer")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> deleteDealer(DeleteDealerRequest _objDeleteDealerRequest)
        {

            Response _objResponse = new Response();
            UpdateDealerResponse _objDeleteUserResponse = new UpdateDealerResponse();
            if (_objDeleteUserResponse == null)
            {
                return BadRequest("Invalid payload");
            }
            if (!ModelState.IsValid)
            {

            }
            int resultResponse = dealerRepository.DeleteDealer(_objDeleteDealerRequest);
            if (resultResponse == 2000)
            {
                _objDeleteUserResponse.KeyDealershipId = _objDeleteDealerRequest.SourceDealerId;
                _objResponse.Data = _objDeleteUserResponse;
                _objResponse.Message = "Dealer Deleted Successfully.";
                _objResponse.Status = true;
                _objResponse.StatusCode = System.Net.HttpStatusCode.OK;
                return Ok(_objResponse);
            }
            else if (resultResponse == -2005)
            {
                _objResponse.Data = "";
                _objResponse.Message = "Dealer does not exist";
                _objResponse.Status = false;
                _objResponse.StatusCode = System.Net.HttpStatusCode.OK;
                return BadRequest(_objResponse);
            }
            else
            {
                _objResponse.Data = "";
                _objResponse.Message = "Failed! Please try later.";
                _objResponse.Status = false;
                _objResponse.StatusCode = System.Net.HttpStatusCode.InternalServerError;
                return BadRequest(_objResponse);

            }
        }
    }
}
