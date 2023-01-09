using LVRMWebAPI.Models;
using LVRMWebAPI.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using System;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;
using Microsoft.AspNetCore.Authorization;

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
        [HttpPost]
        [Route("getDealer")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> getDealer(DealerSearch _objDealerSearch)
        {
            Response _objResponse = new Response();
            if (_objDealerSearch == null)
            {
                return BadRequest("Invalid payload");
            }

            if (!ModelState.IsValid)
            {

            }
            var data = dealerRepository.GetDealer(_objDealerSearch);
            return Ok(data);
        }


        [HttpPost]
        [Route("addDealer")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> addDealer(DealerRequest _objDealerFields)
        {
            Response _objResponse = new Response();
            DealerResponse _dealerResponse = new DealerResponse();
            if (_objDealerFields == null)
            {
                return BadRequest("Invalid payload");
            }
            if (!ModelState.IsValid)
            {

            }

            int resultResponse = dealerRepository.AddDealer(_objDealerFields);
            if (resultResponse > 0)
            {
                _dealerResponse.DealerName = _objDealerFields.DealerName;
                _objResponse.Data = _dealerResponse;
                _objResponse.Message = "Dealer Created Successfully";
                _objResponse.Status = true;
                _objResponse.StatusCode = System.Net.HttpStatusCode.Created;
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
