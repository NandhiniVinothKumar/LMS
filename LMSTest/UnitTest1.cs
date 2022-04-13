using NUnit.Framework;
using LMSAPI;
using BusinessLayer;
using DataLayer.Interface;
using DataLayer.Model;
using System;
using System.Threading.Tasks;
using Moq;

namespace LMSTest
{
    public class Tests
    {
        private  LeaveRequestService _leaveRequestService;

        private  IRepository<LeaveRequest> _leaveRequest;

     
        [SetUp]
        public void Setup()
        {
            
            
        }

        [Test]
        public async Task Test_CreateLeaveRequest()
        {
            _leaveRequest = ;
            _leaveRequestService = new LeaveRequestService(_leaveRequest);
            LeaveRequest leaveRequest = new LeaveRequest() {
                Employee_Id="Emp004",
                Employee_Name="Emp4",
                Start_Date = Convert.ToDateTime("2022-04-13"),
                End_Date= Convert.ToDateTime("2022-04-13"),
                LeaveType="SickLeave",
                Requested_Date =DateTime.Now,
                Comments="Test"
            };
            var myResult = await _leaveRequestService.CreateLeaveRequest(leaveRequest);

            Assert.IsNotNull(myResult);
        }
    }
}