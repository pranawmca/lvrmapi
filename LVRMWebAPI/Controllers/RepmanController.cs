using LVRMWebAPI.Models;
using LVRMWebAPI.Repository;
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
    public class RepmanController : ControllerBase
    {
        private readonly IUserRepository userRepository;
        public RepmanController(IUserRepository _userRepository)
        {
            userRepository = _userRepository;
        }
        [HttpGet]
        [Route("GetAllData")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> GetAllData()
        {
            List<MyCustomResponse> objResponse = new List<MyCustomResponse>()
            {

                new MyCustomResponse(){ID=1, Name="Tasauar" },
                 new MyCustomResponse(){ID=1, Name="Tasauar" }
            };

            return Ok(objResponse);

            
        }



        [HttpPost]
        [Route("GetUsers")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> GetUsers(UserReqField _objUserUser)
        {
            Response _objResponse = new Response();
            if (_objUserUser == null)
            {
                return BadRequest("Invalid payload");
                //return Request.CreateResponse(HttpStatusCode.BadRequest, "Invalid payload");
            }

            if (!ModelState.IsValid)
            { 
            
            }


            var data =  userRepository.GetUserList(_objUserUser);
            return Ok(data);

            //RepManSSOAPIDAL _objRepManSSOAPIDAL = new RepManSSOAPIDAL();

            //List<UserField> userFieldsList = new List<UserField>();
            //if (result.IsValid)
            //{
            //    try
            //    {
            //        userFieldsList = _objRepManSSOAPIDAL.GetUserList(_objUserUser);
            //        if (userFieldsList.Count > 0)
            //        {
            //            _objResponse.Data = userFieldsList;
            //            _objResponse.Message = "";
            //            _objResponse.Status = true;
            //            _objResponse.StatusCode = HttpStatusCode.OK;
            //            return Request.CreateResponse(HttpStatusCode.OK, _objResponse);
            //        }
            //        else
            //        {
            //            _objResponse.Data = "";
            //            _objResponse.Message = "Failed!Try again";
            //            _objResponse.Status = true;
            //            _objResponse.StatusCode = HttpStatusCode.InternalServerError;
            //            return Request.CreateResponse(HttpStatusCode.InternalServerError, _objResponse);
            //        }
            //    }
            //    catch (Exception ex)
            //    {
            //        _objResponse.Data = "";
            //        _objResponse.Message = ex.Message;
            //        _objResponse.Status = false;
            //        _objResponse.StatusCode = HttpStatusCode.InternalServerError;
            //        return Request.CreateResponse(HttpStatusCode.InternalServerError, _objResponse);
            //    }
            //}
            //else
            //{
            //    InvalidResponse objResponse = new InvalidResponse();
            //    objResponse.Message = "Invalid payload";
            //    objResponse.Code = "404";
            //    List<Details> objDetails = new List<Details>();
            //    foreach (var err in result.Errors)
            //    {
            //        objDetails.Add(new Details
            //        {
            //            AttributeName = err.PropertyName.ToString(),
            //            Reason = err.ErrorMessage.ToString(),
            //        });
            //    }
            //    objResponse.details = objDetails;
            //    return BadRequest(objResponse);
            //}
           // return Ok();
        }


    }

    
}
