using LVRMWebAPI.CommonCronjob;
using LVRMWebAPI.Infrastructure;
using LVRMWebAPI.Models;
using LVRMWebAPI.Models.Datashake;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LVRMWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DatashakeCronJOBController : ControllerBase
    {
        private readonly ICronJobManualTriggerCLS cronJobManualTriggerCLS;
        public DatashakeCronJOBController(ICronJobManualTriggerCLS cronJobManualTriggerCLS)
        {
            this.cronJobManualTriggerCLS = cronJobManualTriggerCLS;
        }

        [HttpPost]
        [Route("addplaceiddetails")]
        [ApiExplorerSettings(IgnoreApi = true)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> addplaceiddetails([FromBody] PlaceIdDetailsRequest placeIdDetails)
        {
            Response _objResponse = new Response();
            if (placeIdDetails == null)
            {

                return BadRequest("Not a valid request.");
            }
            if (!ModelState.IsValid)
            {

            }

            try
            {
                List<PlaceIdDetailsModel> objList = cronJobManualTriggerCLS.GetPlaceIDDetails();
                List<PlaceIdDetailsModel> objListRequest = placeIdDetails.lstPlaceIDDetails;

                // var matchList = 
                var lstNotMatched = objListRequest .Except(objList, new DealerPlaceidComapereCLS()).ToList();
                var lstMatched = objList.Intersect(objListRequest, new DealerPlaceidComapereCLS()).ToList();

                if (lstNotMatched != null)
                {

                    if (lstNotMatched.Count > 0)
                    {

                        cronJobManualTriggerCLS.SaveDealerIDPlaceID(lstNotMatched);
                    }
                }
                if (lstNotMatched.Count>0 && lstMatched.Count>0)
                {
                    _objResponse.Data = lstMatched;
                    _objResponse.Message = "Save successfully! and these records already exist";
                    _objResponse.Status = true;
                   // _objResponse.StatusCode = System.Net.HttpStatusCode.OK;
                   // return BadRequest(_objResponse);

                }

               else if (lstNotMatched.Count==0 && lstMatched.Count>0)
                {
                    _objResponse.Data = lstMatched;
                    _objResponse.Message = "All data is exist in our records";
                    _objResponse.Status = true;
                   // _objResponse.StatusCode = System.Net.HttpStatusCode.OK;
                    // return BadRequest(_objResponse);

                }

                else
                {
                    _objResponse.Data = "";
                    _objResponse.Message = "Data save successfully";
                    _objResponse.Status = true;
                   // _objResponse.StatusCode = System.Net.HttpStatusCode.OK;
                    return BadRequest(_objResponse);
                }

                return Ok(_objResponse);

            }
            catch (Exception ex)
            {
                _objResponse.Data = "";
                _objResponse.Message = "Failed! Please try later.";
                _objResponse.Status = false;
                //_objResponse.StatusCode = System.Net.HttpStatusCode.InternalServerError;
                return BadRequest(_objResponse);

            }



        }
        [HttpPost]
        [Route("callscronjob")]
        [ApiExplorerSettings(IgnoreApi = true)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> CallCronJob()
        {
            Response _objResponse = new Response();

            try
            {
                cronJobManualTriggerCLS.CallCronJobManually();
                _objResponse.Data = "";
                _objResponse.Message = "Scron job called successfully";
                _objResponse.Status = true;
                //_objResponse.StatusCode = System.Net.HttpStatusCode.OK;
                return Ok(_objResponse);
            }
            catch (Exception ex)
            {
                _objResponse.Data = "";
                _objResponse.Message = "Failed! Please try later.";
                _objResponse.Status = false;
              //  _objResponse.StatusCode = System.Net.HttpStatusCode.InternalServerError;
                return BadRequest(_objResponse);

            }



        }

        [HttpPost]
        [Route("mergeDealer")]
        //[ApiExplorerSettings(IgnoreApi = true)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> MergeDealer()
        {
            Response _objResponse = new Response();

            try
            {
                cronJobManualTriggerCLS.MergeDealer();
                _objResponse.Data = "";
                _objResponse.Message = "Merge Dealer successfully";
                _objResponse.Status = true;
                //_objResponse.StatusCode = System.Net.HttpStatusCode.OK;
                return Ok(_objResponse);
            }
            catch (Exception ex)
            {
                _objResponse.Data = "";
                _objResponse.Message = "Failed! Please try later.";
                _objResponse.Status = false;   
                return BadRequest(_objResponse);

            }
        }

    }
}
