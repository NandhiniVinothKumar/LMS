using BusinessLayer;
using DataLayer.Interface;
using DataLayer.Model;
using LMSAPI;
using LMSAPI.Controllers;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Microsoft.EntityFrameworkCore;
using Moq;
using System;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Xunit;

namespace LMSAPITest
{
    public class UnitTest1
    {
        private readonly LeaveRequestController _controller;
        private readonly LeaveRequestService _service;
        private readonly IRepository<LeaveRequest> _leaverequest;
        readonly HttpClient _client;
        public UnitTest1()
        {
            var server = new TestServer(new WebHostBuilder()
                .UseEnvironment("Development")
                .UseStartup<Startup>());
            _client = server.CreateClient();
           
              
    }
        [Theory]
        [InlineData("GET")]
        public void Test1(string method)
        {
            var request = new HttpRequestMessage(new HttpMethod(method), "api/LeaveRequest/GetAllRequests");
            var response = _client.GetAsync(request.RequestUri);
            // response.EnsureSuccessStatusCode();
            Assert.NotNull(response);
          

        }
    }
}

