using Alten.Jama.Models;
using Alten.Jama.Serialization;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Text.Json;

namespace Alten.Jama.Tests.Serialization
{
    [TestClass]
    public class SmokeTests
    {
        [TestMethod]
        public void SerializeItemTypeImage()
        {
            JsonSerializerOptions options = JsonSerializerOptionsFactory.Create();
            string json = JsonSerializer.Serialize(ItemTypeImage.Book2, options);
            Assert.AreEqual("\"BOOK2\"", json);
        }
    }
}
