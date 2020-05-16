using Alten.Jama.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Threading.Tasks;

namespace Alten.Jama.Services
{
    [TestClass]
    public class RestSharpItemTypeServiceTests
    {
        private const int ItemTypeId = 143;

        private readonly IItemTypeService _service = RestSharpServiceFactory.Create<RestSharpItemTypeService>();

        [TestMethod]
        public async Task CreateAsync()
        {
            var body = new ItemTypeRequest
            {
                TypeKey = "JOB",
                Display = "Job",
                DisplayPlural = "Jobs",
                Description = "HR"
            };

            MetaResponse response = await _service.CreateAsync(body);
            Assert.IsNotNull(response);
        }

        [TestMethod]
        public async Task GetAsync()
        {
            DataResponse<ItemType> response = await _service.GetAsync(ItemTypeId);
            Assert.IsNotNull(response);
        }
    }
}
