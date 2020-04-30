using Alten.Jama.Models;
using Alten.Jama.Tests.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Threading.Tasks;

namespace Alten.Jama.Services
{
    [TestClass]
    public sealed class RestSharpUserServiceTests
    {
        private readonly IUserService _service = RestSharpServiceFactory.Create<RestSharpUserService>();

        [TestMethod]
        public async Task PostAsync()
        {
            var body = new UserRequest
            {
                Email = "bstankovic@alten.at",
                FirstName = "Barbara",
                LastName = "Stankovic",
                Password = "123456",
                Phone = "+43 664 39 85 200",
                Title = "MA",
                Username = "bstankovic@alten.at"
            };

            MetaResponse response = await _service.PostAsync(body);
            Assert.IsNotNull(response);
        }

        [TestMethod]
        [DataRow(44)]
        public async Task GetAsync(int userId)
        {
            DataResponse<User> response = await _service.GetAsync(userId);
            Assert.IsNotNull(response);
        }

        [TestMethod]
        public async Task GetCurrentAsync()
        {
            DataResponse<User> response = await _service.GetCurrentAsync();
            Assert.IsNotNull(response);
        }
    }
}
