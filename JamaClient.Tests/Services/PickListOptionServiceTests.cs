using JamaClient.Models;
using JamaClient.Serialization;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace JamaClient.Services
{
    [TestClass]
    public class PickListOptionServiceTests
    {
        private const int InvalidId = -1;

        private static readonly IPickListOptionService Api;
        
        private static int PickListId = InvalidId;
        private static int PickListOptionId = InvalidId;
        private static TestContext Context;

        static PickListOptionServiceTests()
        {
            ISerializationService serializationService = new SerializationService();
            IRestService restService = new SimpleClient(serializationService);
            Api = new PickListOptionService(restService);
        }

        [ClassInitialize]
        public static async Task Initialize(TestContext context)
        {
            Context = context;
            try
            {
                PickListId = await PickListServiceTests.CreateAsync();
                PickListOptionId = await PickListServiceTests.CreateOptionAsync(PickListId);
            }
            catch (AssertFailedException)
            {
                Assert.Inconclusive();
            }
        }

        [ClassCleanup]
        public static async Task CleanUp()
        {
            try
            {
                await PickListServiceTests.DeleteAsync(PickListId);
            }
            catch (AssertFailedException)
            {
                Context.WriteLine($"Manually verify that the pick list with the id '{PickListId}' was deleted.");
            }            
        }

        [TestMethod]
        public async Task GetAsync()
        {
            DataResponse<PickListOption> response = await Api.GetAsync(PickListOptionId);                                    
            Assert.That.IsOK(response.Meta);
            CollectionAssert.That.IsNotEmpty(response.Links);
            Assert.IsNull(response.Linked);
            Assert.AreEqual(PickListId, response.Data.PickList);
            Assert.AreEqual(PickListOptionId, response.Data.Id);
        }

        [TestMethod]
        public async Task GetAsync_InvalidId()
        {
            MetaResponse response = await Api.GetAsync(InvalidId);
            Assert.That.IsNotFound(response.Meta);
        }

        [TestMethod]
        public async Task UpdateAsync()
        {
            var body = new PickListOptionRequest
            {
                SortOrder = 1,
                Name = "Alpha",
                Value = "Bravo",
                Color = ColorPalette.HexCodes.Last(),
                Default = true
            };

            MetaResponse updateResponse = await Api.UpdateAsync(PickListOptionId, body);
            Assert.That.IsOK(updateResponse.Meta);

            DataResponse<PickListOption> optionResponse = await Api.GetAsync(PickListOptionId);            
            Assert.That.IsOK(optionResponse.Meta);
            Assert.IsNotNull(optionResponse.Data);
            Assert.AreEqual(body.SortOrder, optionResponse.Data.SortOrder);
            Assert.AreEqual(body.Name, optionResponse.Data.Name);
            Assert.AreEqual(body.Value, optionResponse.Data.Value);
            Assert.AreEqual(body.Color, optionResponse.Data.Color);
            Assert.AreEqual(body.Default, optionResponse.Data.Default);
        }

        [TestMethod]
        public async Task UpdateAsync_InvalidId()
        {
            var body = new PickListOptionRequest();
            MetaResponse response = await Api.UpdateAsync(InvalidId, body);
            Assert.That.IsNotFound(response.Meta);
        }

        [TestMethod]
        public async Task UpdateAsync_InvalidBody()
        {
            // TODO: Kick?
            MetaResponse response = await Api.UpdateAsync(PickListId, body: null);
            Assert.That.IsBadRequest(response.Meta);
        }
    }
}