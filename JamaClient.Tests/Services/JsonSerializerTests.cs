using JamaClient.Models;
using JamaClient.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Text.Json;

namespace JamaClient.Services
{
    [TestClass]
    public class JsonSerializerTests
    {
        private static readonly UserRequest Request = UserServiceTests.CreateUniqueUserRequest();
        private static readonly JsonSerializerOptions Options = RestClientFactory.CreateJsonSerializerOptions();
        private static readonly string JsonString = JsonSerializer.Serialize(Request, Options);

        [TestMethod]
        public void Serialize()
        {
            JsonElement rootElement = JsonDocument.Parse(JsonString).RootElement;
            JsonElement licenseType = rootElement.GetProperty("licenseType");
            Assert.AreEqual("NAMED", licenseType.GetString());
        }

        [TestMethod]
        public void Deserialize()
        {
            UserRequest result = JsonSerializer.Deserialize<UserRequest>(JsonString, Options);
            Assert.AreEqual(LicenseType.Named, result.LicenseType);
        }
    }
}
