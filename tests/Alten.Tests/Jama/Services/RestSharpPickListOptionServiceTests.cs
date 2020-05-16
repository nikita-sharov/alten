using Alten.Jama.Models;
using Alten.Jama.Tests.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Threading.Tasks;

namespace Alten.Jama.Services
{
    [TestClass]
    public sealed class RestSharpPickListOptionServiceTests
    {
        private const int PickListOptionId = 905;

        private readonly IPickListOptionService _service = 
            RestSharpServiceFactory.Create<RestSharpPickListOptionService>();

        [TestMethod]
        public async Task GetAsync()
        {
            DataResponse<PickListOption> response = await _service.GetAsync(PickListOptionId);
            Assert.IsNotNull(response);
        }

        [TestMethod]
        public async Task PutAsync()
        {
            var body = new PickListOptionRequest
            {
                SortOrder = 1,
                Name = "Mr.",
                Default = true
            };

            MetaResponse response = await _service.PutAsync(PickListOptionId, body);
            Assert.IsNotNull(response);
        }
    }
}
