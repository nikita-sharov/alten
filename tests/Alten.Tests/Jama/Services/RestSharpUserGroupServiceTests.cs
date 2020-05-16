using Alten.Jama.Models;
using Alten.Jama.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Threading.Tasks;

namespace Alten.Jama.Tests.Services
{
    [TestClass]
    public class RestSharpUserGroupServiceTests
    {
        private readonly IUserGroupService _service = RestSharpServiceFactory.Create<RestSharpUserGroupService>();

        [TestMethod]
        public async Task CreateAsync()
        {
            var body = new UserGroupRequest
            {
                Name = "Recruting Management"
            };

            MetaResponse response = await _service.CreateAsync(body);
            Assert.IsNotNull(response);
        }

        [TestMethod]
        public async Task GetAsync(int userGroupId)
        {
            DataResponse<UserGroup> response = await _service.GetAsync(userGroupId: 29);
            Assert.IsNotNull(response);
        }

        [TestMethod]
        public async Task AddUserAsync()
        {
            MetaResponse response = await _service.AddUserAsync(userGroupId: 29, userId: 44);
            Assert.IsNotNull(response);
        }
    }
}
