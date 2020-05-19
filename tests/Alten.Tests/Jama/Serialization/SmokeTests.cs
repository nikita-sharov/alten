using Alten.Jama.Models;
using Alten.Jama.Serialization;
using Humanizer;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Text.Json;

namespace Alten.Jama.Tests.Serialization
{
    [TestClass]
    public static class SmokeTests
    {
        [TestMethod]
        public static void SerializeItemTypeImage()
        {
            JsonSerializerOptions options = JsonSerializerOptionsFactory.Create();
            string json = JsonSerializer.Serialize(ItemTypeImage.Book2, options);
            Assert.AreEqual("\"BOOK2\"", json);
        }
    }
}
