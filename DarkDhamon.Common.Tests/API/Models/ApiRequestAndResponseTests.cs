using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DarkDhamon.Common.API.Models;
using NUnit.Framework;

namespace DarkDhamon.Common.Tests.API.Models
{
    public class ApiRequestAndResponseTests
    {
        [Test]
        public void BasicApiResponseForTest()
        {
            ApiRequest<string> request = new()
            {
                RequestId = 1
            };
            var response = new ApiResponse();
            response.For(request);
            Assert.AreEqual(request.RequestId, response.RequestId);
        }

        [Test]
        public void BasicApiResponseCtorTest()
        {
            ApiRequest<string> request = new()
            {
                RequestId = 1
            };
            var response = new ApiResponse(request);
            Assert.AreEqual(request.RequestId, response.RequestId);
        }



        [Test]
        public void BasicApiResponseManualEntryTest()
        {
            ApiRequest<string> request = new()
            {
                RequestId = 1
            };
            var response = new ApiResponse();
            Assert.AreNotEqual(request.RequestId, response.RequestId);
            response.RequestId = request.RequestId;
            Assert.AreEqual(request.RequestId, response.RequestId);
        }
    }
}
