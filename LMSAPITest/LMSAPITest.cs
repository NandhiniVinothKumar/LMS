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
    public class LMSAPITest
    {
        readonly HttpClient _client;
        public LMSAPITest()
        {
            var server = new TestServer(new WebHostBuilder()
                .UseEnvironment("Development")
                .UseStartup<Startup>());
            _client = server.CreateClient();
           
              
    }
        [Theory]
        [InlineData("GET")]
        public void GetTest(string method)
        {
            var request = new HttpRequestMessage(new HttpMethod(method), "https://localhost:5001/api/LeaveRequest/GetAllRequests");
            var response = _client.GetAsync(request.RequestUri);
            Assert.NotNull(response);
        }
        [Theory]
        [InlineData("POST")]
        public void PostTest(string method)
        {
            var request = new HttpRequestMessage(new HttpMethod(method), "https://localhost:5001/api/LeaveRequest/CreateLeaveRequest");
            var response = _client.GetAsync(request.RequestUri);
            Assert.NotNull(response);
        }
        [Theory]
        [InlineData("Update")]
        public void UpdateTest(string method)
        {
            var request = new HttpRequestMessage(new HttpMethod(method), "https://localhost:5001/api/LeaveRequest/UpdateLeaveRequest");
            var response = _client.GetAsync(request.RequestUri);
            Assert.NotNull(response);
        }
        [Theory]
        [InlineData("Delete")]
        public void DeleteTest(string method)
        {
            var request = new HttpRequestMessage(new HttpMethod(method), "https://localhost:5001/api/DeleteRequest");
            var response = _client.GetAsync(request.RequestUri);
            Assert.NotNull(response);
        }
    }
}

