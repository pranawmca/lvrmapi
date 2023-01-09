using LVRMWebAPI.Models;
using LVRMWebAPI.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace LVRMWebAPI.Controllers
{
    [Authorize]
    [Route("api/user-service")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserRepository userRepository;
        public UserController(IUserRepository _userRepository)
        {
            userRepository = _userRepository;
        }
        [HttpPost]
        [Route("getUser")]
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


            var data = userRepository.GetUserList(_objUserUser);
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


        [HttpPost]
        [Route("addUser")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> AddUser(UserRequest _objUserFields)
        {
            Response _objResponse = new Response();
            UserResponse _objAddUserResp = new UserResponse();
            if (_objUserFields == null)
            {
                return BadRequest("Invalid payload");
            }
            Random r = new Random(4);
            int number = r.Next();
            string pass = "psm" + number.ToString();
            _objUserFields.Password = pass;
            if (!ModelState.IsValid)
            {

            }

            int resultResponse = userRepository.AddUser(_objUserFields);
            if (resultResponse > 0)
            {
                _objAddUserResp.UserId = resultResponse.ToString();
                _objAddUserResp.FirstName = _objUserFields.FirstName;
                _objAddUserResp.LastName = _objUserFields.LastName;
                _objAddUserResp.UserName = _objUserFields.Email;
                _objAddUserResp.Password = pass;
                _objResponse.Data = _objAddUserResp;
                _objResponse.Message = "User Created Successfully.";
                _objResponse.Status = true;
                _objResponse.StatusCode = System.Net.HttpStatusCode.Created;
                return Ok(_objResponse);
            }
            else
            {
                if (resultResponse.ToString() == "-2001")
                {
                    _objResponse.Data = "";
                    _objResponse.Message = "Email ID already exists.";
                    _objResponse.Status = false;
                    //_objResponse.StatusCode = HttpStatusCode.InternalServerError;
                    _objResponse.StatusCode = (System.Net.HttpStatusCode)409;
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

        [HttpPut]
        [Route("updateUser")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> UpdateUser(UpdateUserRequest _objUserFields)
        {
            Response _objResponse = new Response();
            UpdateUserResponse _objUpdateUserResponse = new UpdateUserResponse();
            if (_objUserFields == null)
            {
                return BadRequest("Invalid payload");
            }
            //Random r = new Random(4);
            //int number = r.Next();
            //string pass = "psm" + number.ToString();
            //_objUserFields.Password = pass;
            if (!ModelState.IsValid)
            {

            }
            int resultResponse = userRepository.UpdateUser(_objUserFields);
            if (resultResponse == 2000)
            {
                _objUpdateUserResponse.UserId = _objUserFields.UserID;
                _objResponse.Data = _objUpdateUserResponse;
                _objResponse.Message = "User Updated Successfully.";
                _objResponse.Status = true;
                _objResponse.StatusCode = System.Net.HttpStatusCode.OK;
                return Ok(_objResponse);
            }
            else if (resultResponse == -2005)
            {
                _objUpdateUserResponse.UserId = _objUserFields.UserID;
                _objResponse.Data = _objUpdateUserResponse;
                _objResponse.Message = "User does not exists.";
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
        [Route("deleteUser")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> DeleteUser(DeleteUserRequest _objDeleteUserRequest)
        {

            Response _objResponse = new Response();
            DeleteUserResponse _objDeleteUserResponse = new DeleteUserResponse();
            if (_objDeleteUserResponse == null)
            {
                return BadRequest("Invalid payload");
            }
            if (!ModelState.IsValid)
            {

            }
            int resultResponse = userRepository.DeleteUser(_objDeleteUserRequest);
            if (resultResponse == 2000)
            {
                _objDeleteUserResponse.UserId = _objDeleteUserRequest.UserID;
                _objResponse.Data = _objDeleteUserResponse;
                _objResponse.Message = "User Deleted Successfully.";
                _objResponse.Status = true;
                _objResponse.StatusCode = System.Net.HttpStatusCode.OK;
                return Ok(_objResponse);
            }
            else if (resultResponse == -2005)
            {
                _objDeleteUserResponse.UserId = _objDeleteUserRequest.UserID;
                _objResponse.Data = _objDeleteUserResponse;
                _objResponse.Message = "User does not exists.";
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

    class MyCustomResponse
    {
        public int ID { get; set; }
        public string Name { get; set; }
    }
}
