using Alten.Jama.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Threading.Tasks;

namespace Alten.Jama.Services
{
    [TestClass]
    public sealed class RestSharpPickListServiceTests
    {
        public const int PickListId = 623;

        private readonly IPickListService _service = RestSharpServiceFactory.Create<RestSharpPickListService>();

        [TestMethod]        
        public async Task CreateAsync()
        {
            var body = new PickListRequest
            {
                Name = "HR - Salutation",
                Description = "Only for addressing properly and personally."
            };

            MetaResponse response = await _service.CreateAsync(body);
            Assert.IsNotNull(response);
        }

        [TestMethod]
        public async Task GetAsync()
        {
            DataResponse<PickList> response = await _service.GetAsync(PickListId);
            Assert.IsNotNull(response);
        }

        [TestMethod]
        [DataRow(PickListId, "Ms.")]
        [DataRow(PickListId, "Mx.")]
        public async Task CreateOptionAsync(int pickListId, string name)
        {
            var body = new PickListOptionRequest
            {
                Name = name
            };

            MetaResponse response = await _service.CreateOptionAsync(pickListId, body);
            Assert.IsNotNull(response);
        }

        [TestMethod]
        public async Task GetOptionListAsync()
        {
            DataListResponse<PickListOption> response = await _service.GetOptionListAsync(
                PickListId, 0, JamaOptions.MaxResultsMax);
            Assert.IsNotNull(response);
        }
    }
}
