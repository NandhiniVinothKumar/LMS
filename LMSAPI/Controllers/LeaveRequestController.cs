using BusinessLayer;
using DataLayer.Interface;
using DataLayer.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
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



        public LeaveRequestController(LeaveRequestService leaveRequestService)
        {
            _leaveRequestService = leaveRequestService;

        }


        [HttpPost("CreateLeaveRequest")]
        public async Task<Object> CreateLeaveRequest([FromBody] LeaveRequest leaveRequest)
        {
            try
            {
                await _leaveRequestService.CreateLeaveRequest(leaveRequest);
                return true;
            }
            catch (Exception ex)
            {

                return false;
            }
        }

        [HttpDelete("DeleteRequest")]
        public bool DeletePerson(int Id)
        {
            try
            {
                _leaveRequestService.DeleteRequest(Id);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        [HttpPut("UpdateLeaveRequest")]
        public bool UpdatePerson(LeaveRequest leaveRequest)
        {
            try
            {
                _leaveRequestService.UpdateRequest(leaveRequest);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }



        [HttpGet("GetAllRequests")]
        public Object GetAllRequests()
        {
            var data = _leaveRequestService.GetAllRequests();
            var json = JsonConvert.SerializeObject(data, Formatting.Indented,
                new JsonSerializerSettings()
                {
                    ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
                }
            );
            return json;
        }

        [HttpGet("GetRequestByEmpId")]
        public Object GetRequestByEmpId(string empId)
        {
            var data = _leaveRequestService.GetRequeByEmployeeId(empId);
            var json = JsonConvert.SerializeObject(data, Formatting.Indented,
                new JsonSerializerSettings()
                {
                    ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
                }
            );
            return json;
        }
        [HttpGet("GetRequestById")]
        public Object GetRequestById(int Id)
        {
            var data = _leaveRequestService.GetRequeById(Id);
            var json = JsonConvert.SerializeObject(data, Formatting.Indented,
                new JsonSerializerSettings()
                {
                    ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
                }
            );
            return json;
        }
    }
}
