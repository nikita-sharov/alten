using Microsoft.VisualStudio.TestTools.UnitTesting;
using ServiceStack;
using System;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace GosuClient.Models
{
    [TestClass]
    public class PickListTests
    {
        private readonly JsonHttpClient _client = 
            new JsonHttpClient(string.Empty)
            {
                UserName = string.Empty,
                Password = string.Empty
            };

        [TestMethod]
        public async Task GetAsync()
        {
            var request = new GetPickList
            {
                Id = 136
            };

            var response = await _client.GetAsync(request);
        }

        [TestMethod]
        public async Task GetAsync_InvalidId()
        {
            var request = new GetPickList
            {
                Id = -1
            };

            var ex = await Assert.ThrowsExceptionAsync<WebServiceException>(() => _client.GetAsync(request));            
            Assert.AreEqual((int)HttpStatusCode.NotFound, ex.StatusCode);
        }

        [TestMethod]
        public async Task TestPagination()
        {
            var firstRequest = new GetPickLists
            {
                MaxResults = 2
            };
            
            var firstResponse = await _client.GetAsync(firstRequest);
            var secondRequest = new GetPickLists
            {
                StartAt = firstResponse.Meta.PageInfo.ResultCount
            };

            var secondResponse = await _client.GetAsync(secondRequest);
        }

        [TestMethod]
        public async Task TestCrud()
        {
            CreateResponse createResponse = await _client.PostAsync(
                new CreatePickList
                {
                    Name = Guid.NewGuid().ToString(),
                    Description = "Just a test"
                });

            int pickListId = createResponse.Meta.Id;
            GetDataResponse<PickList> dataResponse = await _client.GetAsync(
                new GetPickList
                {
                    Id = pickListId
                });

            GetDataListResponse<PickListOption> dataListResponse = await _client.GetAsync(
                new GetPickListOptions 
                { 
                    PickListId = pickListId
                });

            // one option at least
            int pickListOptionId = dataListResponse.Data.Single().Id;
            
            //await _client.PostBodyAsync(
            //    new UpdatePickListOption
            //    {
            //        Id = pickListOptionId,
            //        Description = "Just a test"
            //    });

            GetDataResponse<PickListOption> pickList = await _client.GetAsync(
                new GetPickListOption
                {
                    Id = pickListOptionId
                });

            await _client.DeleteAsync(
                new DeletePickList
                {
                    Id = pickListId
                });
        }
    }
}
