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
        public async Task PostAsync()
        {
            var body = new UserGroupRequest
            {
                Name = "Recruting Management"
            };

            MetaResponse response = await _service.PostAsync(body);
            Assert.IsNotNull(response);
        }

        [TestMethod]
        [DataRow(29)]
        public async Task GetAsync(int userGroupId)
        {
            DataResponse<UserGroup> response = await _service.GetAsync(userGroupId);
            Assert.IsNotNull(response);
        }

        [TestMethod]
        [DataRow(29, 44)]
        public async Task PostUserAsync(int userGroupId, int userId)
        {
            var body = new GroupUserRequest
            {
                UserId = userId
            };

            MetaResponse response = await _service.PostUserAsync(userGroupId, body);
            Assert.IsNotNull(response);
        }
    }
}
