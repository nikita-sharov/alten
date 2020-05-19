using JamaClient.Models;
using JamaClient.Serialization;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace JamaClient.Services
{
    [TestClass]
    public class PickListServiceTests
    {
        private static readonly IPickListService Api;

        static PickListServiceTests()
        {
            var serializationService = new SerializationService();
            var restService = new SimpleClient(serializationService);
            Api = new PickListService(restService);
        }

        public static async Task<int> CreateAsync()
        {
            var body = new PickListRequest
            {
                Name = Guid.NewGuid().ToString(),
                Description = "Just a test"
            };

            MetaResponse metaResponse = await Api.CreateAsync(body);
            Assert.That.IsCreated(metaResponse.Meta);

            DataResponse<PickList> response = await Api.GetAsync(metaResponse.Meta.Id.Value);
            Assert.That.IsOK(response.Meta);
            CollectionAssert.That.IsEmpty(response.Links);
            Assert.IsNull(response.Linked);

            PickList pickList = response.Data;

            Assert.IsNotNull(pickList);
            Assert.AreEqual(metaResponse.Meta.Id.Value, pickList.Id);
            Assert.AreEqual(body.Name, pickList.Name);
            Assert.AreEqual(body.Description, pickList.Description);

            return pickList.Id;
        }

        public static async Task<int> CreateOptionAsync(int pickListId)
        {
            var body = new PickListOptionRequest
            {
                Name = "Display name",
                Description = "Just a test",
                Color = ColorPalette.HexCodes.First()
            };

            MetaResponse metaResponse = await Api.CreateOptionAsync(pickListId, body);
            Assert.That.IsCreated(metaResponse.Meta);

            DataListResponse<PickListOption> response = await Api.GetOptionsAsync(pickListId);

            Assert.IsNotNull(response);
            Assert.That.IsOK(response.Meta);
            CollectionAssert.That.IsNotEmpty(response.Links);
            Assert.IsNull(response.Linked);

            PageInfo pageInfo = response.Meta.PageInfo;

            Assert.IsNotNull(pageInfo);
            Assert.AreEqual(0, pageInfo.StartIndex);
            Assert.AreEqual(2, pageInfo.ResultCount);
            Assert.AreEqual(2, pageInfo.TotalResults);

            PickListOption defaultOption = response.Data?.Single(option => option.Default);

            Assert.IsNotNull(defaultOption);
            Assert.AreEqual(pickListId, defaultOption.PickList);
            Assert.IsTrue(defaultOption.Id > 0);
            Assert.AreEqual(1, defaultOption.SortOrder);
            Assert.AreEqual("Unassigned", defaultOption.Name);
            Assert.AreEqual(string.Empty, defaultOption.Description);
            Assert.IsNull(defaultOption.Value);
            Assert.IsNull(defaultOption.Color);
            Assert.IsTrue(defaultOption.Default);
            Assert.IsTrue(defaultOption.Active);

            PickListOption newlyCreatedOption = response.Data?.Single(option => option.Id == metaResponse.Meta.Id);

            Assert.IsNotNull(newlyCreatedOption);
            Assert.AreEqual(pickListId, newlyCreatedOption.PickList);
            Assert.AreEqual(metaResponse.Meta.Id, newlyCreatedOption.Id);
            Assert.AreEqual(2, newlyCreatedOption.SortOrder);
            Assert.AreEqual(body.Name, newlyCreatedOption.Name);
            Assert.AreEqual(body.Description, newlyCreatedOption.Description);
            Assert.IsNull(newlyCreatedOption.Value);
            Assert.AreEqual(body.Color, newlyCreatedOption.Color);
            Assert.IsFalse(newlyCreatedOption.Default);
            Assert.IsTrue(newlyCreatedOption.Active);

            return newlyCreatedOption.Id;
        }

        public static async Task DeleteAsync(int pickListId)
        {
            MetaResponse metaResponse = await Api.DeleteAsync(pickListId);
            Assert.IsNull(metaResponse);

            DataResponse<PickList> dataResponse = await Api.GetAsync(pickListId);
            Assert.That.IsNotFound(dataResponse.Meta);
        }

        [TestMethod]
        public async Task GetAsync()
        {
            DataListResponse<PickList> response = await Api.GetAsync(maxResults: 50);

            Assert.That.IsOK(response.Meta);

            PageInfo pageInfo = response.Meta.PageInfo;

            Assert.AreEqual(0, pageInfo.StartIndex);
            Assert.IsTrue(pageInfo.ResultCount > 0);
            Assert.IsTrue(pageInfo.ResultCount <= pageInfo.TotalResults);

            CollectionAssert.That.IsEmpty(response.Links);
            Assert.IsNull(response.Linked);

            Assert.IsTrue(response.Data.All(picklist => picklist.Id > 0));
            Assert.IsFalse(response.Data.Any(picklist => string.IsNullOrWhiteSpace(picklist.Name)));
            Assert.IsFalse(response.Data.Any(picklist => picklist.Description == null));
        }

        [DataTestMethod]
        [DataRow(31)]
        public async Task GetAsync(int pickListId)
        {
            DataResponse<PickList> response = await Api.GetAsync(pickListId);
            Assert.That.IsOK(response.Meta);
            CollectionAssert.That.IsEmpty(response.Links);
            Assert.IsNull(response.Linked);
            Assert.IsNotNull(response.Data);
        }

        [TestMethod]
        public async Task CreatePopulateDeleteAsync()
        {
            int pickListId = await CreateAsync();
            _ = await CreateOptionAsync(pickListId);
            await DeleteAsync(pickListId);
        }

        [TestMethod]
        public async Task DeleteAsync_InvalidId()
        {
            MetaResponse response = await Api.DeleteAsync(id: -1);
            ////Assert.That.IsNotFound(response.Meta);
            Assert.IsNull(response);
        }
    }
}
