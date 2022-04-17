using BusinessLayer;
using DataLayer.Interface;
using DataLayer.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace LMSAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LeaveRequestController : ControllerBase
    {
        private readonly LeaveRequestService _leaveRequestService;
        private readonly ILogger<LeaveRequestController> _logger;
        private readonly IMailRepository _mailService;


        public LeaveRequestController(LeaveRequestService leaveRequestService, ILogger<LeaveRequestController> logger, IMailRepository mailService)
        {
            _leaveRequestService = leaveRequestService;
            _logger = logger;
            _mailService = mailService;

        }


        [HttpPost("CreateLeaveRequest")]
        public async Task<Object> CreateLeaveRequest([FromBody] EmployeeLeave leaveRequest)
        {
            _logger.LogInformation("CreateLeaveRequest Api is started");
            try
            {
                await _leaveRequestService.CreateLeaveRequest(leaveRequest);
                _logger.LogInformation("CreateLeaveRequest Api is Ended Successfully by creating a New Leave Request");
                return true;
              
            }
            catch (Exception ex)
            {
                _logger.LogInformation("Error Occurred in CreateLeaveRequest");
                _logger.LogError(ex.InnerException.ToString());
                return false;
            }
        }

        [HttpDelete("DeleteRequest")]
        public bool DeleteRequest(int Id)
        {
            _logger.LogInformation("DeleteRequest Api is started");
            try
            {
                _leaveRequestService.DeleteRequest(Id);
                _logger.LogInformation("DeleteRequest Api is Ended Successfully by deleting leaverequest for the Id :  " + Id);
                return true;
            }
            catch (Exception ex)
            {
                _logger.LogInformation("Error Occurred in DeleteRequest");
                _logger.LogError(ex.InnerException.ToString());
                return false;
            }
        }

        [HttpPost("UpdateLeaveRequest")]
        public bool UpdateLeaveRequest(EmployeeLeave leaveRequest)
        {
            _logger.LogInformation("UpdateLeaveRequest Api is started");
            try
            {
                _leaveRequestService.UpdateRequest(leaveRequest);
                _logger.LogInformation("UpdateLeaveRequest Api is Ended Successfully by updating leaverequest of Employee :  " + leaveRequest.EmployeeName);
                return true;
            }
            catch (Exception ex)
            {
                _logger.LogInformation("Error Occurred in UpdateLeaveRequest");
                _logger.LogError(ex.InnerException.ToString());
                return false;
            }
        }



        [HttpGet("GetAllRequests")]
        public Object GetAllRequests()
        {
            try
            {
                _logger.LogInformation("GetAllRequests Api is started");
                var data = _leaveRequestService.GetAllRequests();

                var json = JsonConvert.SerializeObject(data, Formatting.Indented,
                    new JsonSerializerSettings()
                    {
                        ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
                    }
                );
                if(json != "null")
                    _logger.LogInformation("GetAllRequests Api is Ended Successfully by returning all the leave requests");
                else
                    _logger.LogInformation("GetAllRequests Api is Ended Successfully and No requests ");
                return json;
            }
            catch(Exception ex)
            {
                _logger.LogInformation("Error Occurred in GetAllRequests");
                _logger.LogError(ex.InnerException.ToString());
                return null;
            }
        }

        [HttpGet("GetRequestByEmpId")]
        public Object GetRequestByEmpId(int empId)
        {
            try
            {
                _logger.LogInformation("GetRequestByEmpId Api is started");
                var data = _leaveRequestService.GetRequeByEmployeeId(empId);
                var json = JsonConvert.SerializeObject(data, Formatting.Indented,
                    new JsonSerializerSettings()
                    {
                        ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
                    }
                );
                if (json!= "null")
                    _logger.LogInformation("GetRequestByEmpId Api is Ended Successfully by returning leave request of employee ID : " +  empId);
                else
                    _logger.LogInformation("GetRequestByEmpId Api is Ended Successfully and no employee of the Employee ID  : " + empId);

                return json;
               
            }
            catch(Exception ex)
            {
                _logger.LogInformation("Error Occurred in GetRequestByEmpId");
                _logger.LogError(ex.InnerException.ToString());
                return null;
            }
        }
        [HttpGet("GetRequestById")]
        public Object GetRequestById(int Id)
        {
            try
            {
                _logger.LogInformation("GetRequestById Api is started");
                var data = _leaveRequestService.GetRequeById(Id);
                var json = JsonConvert.SerializeObject(data, Formatting.Indented,
                    new JsonSerializerSettings()
                    {
                        ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
                    }
                );
                if(json!="null")
                  _logger.LogInformation("GetRequestById Api is Ended Successfully by returning leave request of : "  +  Id);
                else
                    _logger.LogInformation("GetRequestById Api is Ended Successfully and no request for the Id :  " + Id);
                return json;
            }
            catch(Exception ex)
            {
                _logger.LogInformation("Error Occurred in GetRequestById");
                _logger.LogError(ex.InnerException.ToString());
                return null;
            }
        }
        [HttpPost("Send")]
        public async Task<Object> Send([FromForm] MailRequest request)
        {
            _logger.LogInformation("Send Mail Api is started");
            try
            {
                await _mailService.SendEmailAsync(request);
                _logger.LogInformation("Send Mail Api is ended Successfully");
                return Ok();
            }
            catch (Exception ex)
            {
                _logger.LogInformation("Send Mail Api failed!",ex.Message.ToString());
                return false;
            }

        }

    }
}
