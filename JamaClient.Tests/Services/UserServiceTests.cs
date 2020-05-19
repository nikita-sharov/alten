using JamaClient.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace JamaClient.Services
{
    [TestClass]
    [DoNotParallelize]
    public class UserServiceTests
    {
        private const int TestUserId = 33;

        private readonly IUserService _api = new UserService();

        public static UserRequest CreateUniqueUserRequest()
        {
            var username = Guid.NewGuid().ToString();
            return new UserRequest
            {
                Username = username,
                Password = "123456",
                FirstName = "John",
                LastName = "Doe",
                Email = $"{username}@gmail.com"
            };
        }

        [TestMethod]
        public async Task GetAsync_CurrentUserId()
        {
            User currentUser = (await _api.GetCurrentAsync())?.Data;
            if (currentUser == null)
            {
                Assert.Inconclusive();
            }

            DataResponse<User> response = await _api.GetAsync(currentUser.Id);

            Assert.AreEqual(HttpStatusCode.OK, response.Meta.Status);
            Assert.AreEqual(DateTimeOffset.UtcNow.Date, response.Meta.Timestamp.Date);
            Assert.AreEqual(currentUser.Id, response.Data.Id);
        }

        [TestMethod]
        public async Task GetAsync()
        {
            DataListResponse<User> response = await _api.GetAsync();

            PageInfo pageInfo = response.Meta.PageInfo;

            Assert.AreEqual(0, pageInfo.StartIndex);
            Assert.IsTrue(pageInfo.ResultCount > 0);
            Assert.IsTrue(pageInfo.ResultCount <= pageInfo.TotalResults);

            List<User> users = response.Data;

            Assert.IsTrue(users.Count > 0);
            Assert.IsTrue(users.All(user => user.Active));
        }

        [TestMethod]
        public async Task GetAsync_IncludeInactive()
        {
            List<User> users = (await _api.GetAsync(includeInactive: true)).Data;

            Assert.IsTrue(users.All(user => !string.IsNullOrWhiteSpace(user.Username)));
            Assert.IsTrue(users.All(user => !string.IsNullOrWhiteSpace(user.FirstName)));
            Assert.IsTrue(users.All(user => !string.IsNullOrWhiteSpace(user.LastName)));
            Assert.IsTrue(users.All(user => !string.IsNullOrWhiteSpace(user.Email)));
        }

        [TestMethod]
        public async Task GetCurrentAsync()
        {
            DataResponse<User> response = await _api.GetCurrentAsync();

            Assert.AreEqual(HttpStatusCode.OK, response.Meta.Status);
            Assert.AreEqual(DateTimeOffset.UtcNow.Date, response.Meta.Timestamp.Date);
            Assert.IsTrue(response.Data.Active);
        }

        [TestMethod]
        public async Task GetCurrentFavoriteFiltersAsync()
        {
            await Assert.ThrowsExceptionAsync<NotImplementedException>(
                () => _api.GetCurrentFavoriteFiltersAsync());
        }

        [TestMethod]
        [Ignore("Manual test to minimize data pollution as there is no way to delete newly created users.")]
        public async Task CreateAsync()
        {
            UserRequest requestBody = CreateUniqueUserRequest();

            Meta responseMeta = (await _api.CreateAsync(requestBody)).Meta;

            Assert.AreEqual(HttpStatusCode.Created, responseMeta.Status);
            Assert.AreEqual(DateTimeOffset.UtcNow.Date, responseMeta.Timestamp.Date);
            Assert.IsTrue(Uri.IsWellFormedUriString(responseMeta.Location, UriKind.Absolute));
            Assert.IsTrue(responseMeta.Id.HasValue);
            Assert.IsTrue(responseMeta.Id > 0);
        }

        [TestMethod]
        public async Task UpdateAsync()
        {
            var requestBody = new UserRequest
            {
                Phone = "123abc",
                Title = " "
            };

            Meta responseMeta = (await _api.UpdateAsync(TestUserId, requestBody)).Meta;
            Assert.AreEqual(HttpStatusCode.OK, responseMeta.Status);
            Assert.AreEqual(DateTimeOffset.UtcNow.Date, responseMeta.Timestamp.Date);

            User testUser = (await _api.GetAsync(TestUserId)).Data;
            Assert.AreEqual(requestBody.Phone, testUser.Phone);
            Assert.AreEqual(requestBody.Title, testUser.Title);
        }

        [TestMethod]
        public async Task SetActiveStatusAsync()
        {
            User testUser = (await _api.GetAsync(TestUserId)).Data;
            if (testUser == null)
            {
                Assert.Inconclusive();
            }

            var requestBody = new ActiveStatusRequest
            {
                // Invert current status
                Active = !testUser.Active
            };

            // Having a side effect on the license type
            LicenseType expectedLicenseType = requestBody.Active ? LicenseType.Floating : LicenseType.Inactive;

            Meta responseMeta = (await _api.SetActiveStatusAsync(TestUserId, requestBody)).Meta;

            Assert.AreEqual(HttpStatusCode.OK, responseMeta.Status);
            Assert.AreEqual(DateTimeOffset.UtcNow.Date, responseMeta.Timestamp.Date);

            testUser = (await _api.GetAsync(TestUserId)).Data;

            Assert.AreEqual(requestBody.Active, testUser.Active);
            Assert.AreEqual(expectedLicenseType, testUser.LicenseType);            
        }

        [Obsolete("Actually, every test takes more then 100 ms to run (while being executed sequentially).")]
        public void CleanUp()
        {
            // 15 requests per second limit
            Task.Delay(100);
        }
    }
}
