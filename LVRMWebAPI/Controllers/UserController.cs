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
        [HttpGet]
        [Route("getUser/{userId}")]
        [ProducesResponseType(typeof(UserDeatails), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
       // [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetUserById(int userId)
        {
            Response _objResponse = new Response();
            try
            {
               
                if (userId == 0)
                {
                    return BadRequest("Invalid payload");
                }
                if (!ModelState.IsValid)
                {

                }
                UserDeatails _objUserDetail = new UserDeatails();
                _objUserDetail = userRepository.GetUserDetail(userId);
                if (_objUserDetail != null && _objUserDetail.FirstName != null && _objUserDetail.FirstName != "")
                    return Ok(_objUserDetail);
                else
                {
                    _objResponse.Data = "";
                    _objResponse.Message = "User does not exists.";
                    _objResponse.Status = false;
                    // _objResponse.StatusCode =HttpStatusCode.BadRequest;
                    return BadRequest(_objResponse);
                }
            }
            catch (Exception ex)
            {

                _objResponse.Data = "";
                _objResponse.Message = ex.Message;
                _objResponse.Status = false;
                // _objResponse.StatusCode =HttpStatusCode.BadRequest;
                return StatusCode((int) HttpStatusCode.InternalServerError, _objResponse);
            }

        }


        //[HttpPost]
        //[Route("getUser")]
        //[ProducesResponseType(StatusCodes.Status200OK)]
        //[ProducesResponseType(StatusCodes.Status400BadRequest)]
        //public async Task<IActionResult> GetUsers(UserReqField _objUserUser)
        //{
        //    Response _objResponse = new Response();
        //    if (_objUserUser.UserID == 0 && string.IsNullOrEmpty(_objUserUser.FirstName) && string.IsNullOrEmpty(_objUserUser.LastName) && string.IsNullOrEmpty(_objUserUser.Email))
        //    {
        //        return BadRequest("Invalid payload");
        //    }
        //    List<UserDeatails> _objUserList = new List<UserDeatails>();
        //    _objUserList = userRepository.GetUserList(_objUserUser);
        //    if (_objUserList.Count > 0)
        //        return Ok(_objUserList);
        //    else
        //    {
        //        _objResponse.Data = "";
        //        _objResponse.Message = "User does not exists.";
        //        _objResponse.Status = false;
        //        _objResponse.StatusCode = HttpStatusCode.BadRequest;
        //        return BadRequest(_objResponse);
        //    }            
        //}

        [HttpPost]
        [Route("addUser")]
        [ProducesResponseType(typeof(Response), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status409Conflict)]
     
        public async Task<IActionResult> AddUser(UserRequest _objUserFields)
        {
            Response _objResponse = new Response();
            try
            {
                UserResponse _objAddUserResp = new UserResponse();

                UserDeatails _objUserResponse = new UserDeatails();
                if (_objUserFields == null)
                {
                    return BadRequest("Invalid payload");
                }
                if (string.IsNullOrEmpty(_objUserFields.Password))
                {
                    Random r = new Random(4);
                    int number = r.Next();
                    string pass = "psm" + number.ToString();
                    _objUserFields.Password = pass;
                }
                int resultResponse = userRepository.AddUser(_objUserFields);
                if (resultResponse > 0)
                {
                    //_objAddUserResp.UserId = resultResponse.ToString();
                    //_objAddUserResp.DealerId = _objUserFields.DealerId;
                    //_objAddUserResp.FirstName = _objUserFields.FirstName;
                    //_objAddUserResp.LastName = _objUserFields.LastName;
                    //_objAddUserResp.UserName = _objUserFields.Email;
                    //_objAddUserResp.Email = _objUserFields.Email;
                    //_objAddUserResp.Password = _objUserFields.Password;
                    //_objAddUserResp.Admin = _objUserFields.Admin;
                    //_objAddUserResp.PhoneNumber = _objUserFields.PhoneNumber;
                    //_objAddUserResp.Department = _objUserFields.Department;    



                    _objUserResponse = userRepository.GetUserDetail(resultResponse);
                    _objUserResponse.Password = _objUserFields.Password;
                    _objResponse.Data = _objUserResponse;
                    _objResponse.Message = "User Created Successfully.";
                    _objResponse.Status = true;
                    //_objResponse.StatusCode = System.Net.HttpStatusCode.OK;
                    return Ok(_objResponse);
                }
                else
                {
                    if (resultResponse.ToString() == "-2001")
                    {
                        _objResponse.Data = "";
                        _objResponse.Message = "Email ID already exists.";
                        _objResponse.Status = false;
                        //_objResponse.StatusCode = (System.Net.HttpStatusCode)409;
                        return StatusCode((int)HttpStatusCode.Conflict, _objResponse);

                    }
                    else
                    {
                        _objResponse.Data = "";
                        _objResponse.Message = "Failed! Please try later.";
                        _objResponse.Status = false;
                        //_objResponse.StatusCode = System.Net.HttpStatusCode.InternalServerError;
                        return BadRequest(_objResponse);
                    }
                }
            }
            catch (Exception ex)
            {

                _objResponse.Data = "";
                _objResponse.Message = ex.Message;
                _objResponse.Status = false;
                // _objResponse.StatusCode =HttpStatusCode.BadRequest;
                return StatusCode((int)HttpStatusCode.InternalServerError, _objResponse);
            }

        }

        [HttpPut]
        [Route("updateUser")]
        [ProducesResponseType(typeof(Response), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> UpdateUser(UpdateUserRequest _objUserFields)
        {
            Response _objResponse = new Response();
            try
            {
                UpdateUserResponse _objUpdateUserResponse = new UpdateUserResponse();
                if (_objUserFields == null)
                {
                    return BadRequest("Invalid payload");
                }
                //if (!ModelState.IsValid)
                //{

                //}
                int resultResponse = userRepository.UpdateUser(_objUserFields);
                if (resultResponse == 2000)
                {
                    _objUpdateUserResponse.UserId = _objUserFields.UserID;
                    _objResponse.Data = _objUpdateUserResponse;
                    _objResponse.Message = "User Updated Successfully.";
                    _objResponse.Status = true;
                    //_objResponse.StatusCode = System.Net.HttpStatusCode.OK;
                    return Ok(_objResponse);
                }
                else if (resultResponse == -2005)
                {
                    _objUpdateUserResponse.UserId = _objUserFields.UserID;
                    _objResponse.Data = _objUpdateUserResponse;
                    _objResponse.Message = "User does not exists.";
                    _objResponse.Status = true;
                    //_objResponse.StatusCode = System.Net.HttpStatusCode.OK;
                    return Ok(_objResponse);
                }
                else
                {
                    _objResponse.Data = "";
                    _objResponse.Message = "Failed! Please try later.";
                    _objResponse.Status = false;
                    // _objResponse.StatusCode = System.Net.HttpStatusCode.InternalServerError;
                    //return BadRequest(_objResponse);
                    return StatusCode((int)HttpStatusCode.InternalServerError, _objResponse);

                }
            }
            catch(Exception ex)
            {

                _objResponse.Data = "";
                _objResponse.Message = ex.Message;
                _objResponse.Status = false;
                // _objResponse.StatusCode = System.Net.HttpStatusCode.InternalServerError;
                return StatusCode((int)HttpStatusCode.InternalServerError, _objResponse);
            }


        }

        [HttpDelete]
        [Route("deleteUser")]
        [ProducesResponseType(typeof(Response), StatusCodes.Status200OK)]
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
                //_objResponse.StatusCode = System.Net.HttpStatusCode.OK;
                return Ok(_objResponse);
            }
            else if (resultResponse == -2005)
            {
                _objDeleteUserResponse.UserId = _objDeleteUserRequest.UserID;
                _objResponse.Data = _objDeleteUserResponse;
                _objResponse.Message = "User does not exists.";
                _objResponse.Status = true;
               // _objResponse.StatusCode = System.Net.HttpStatusCode.OK;
                return Ok(_objResponse);
            }

            else
            {
                _objResponse.Data = "";
                _objResponse.Message = "Failed! Please try later.";
                _objResponse.Status = false;
               // _objResponse.StatusCode = System.Net.HttpStatusCode.InternalServerError;
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
