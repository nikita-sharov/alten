using JamaClient.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Text.Json;

namespace JamaClient.Serialization
{
    [TestClass]
    public class SerializationServiceTests
    {
        [TestMethod]
        public void Test()
        {
            var request = new PickListRequest
            {
                Name = "Alpha",
                Description = "Bravo"
            };

            JsonSerializerOptions options = SerializationService.CreateOptions();
            string json = JsonSerializer.Serialize(request, options);
        }

        [TestMethod]
        public void TestInheritance()
        {
            var model = new Model();
            string json = JsonSerializer.Serialize<ModelBase>(model);
        }

        private abstract class ModelBase
        {
            public string Name { get; set; }
        }

        private class Model : ModelBase
        {
            public string Description { get; set; }
        }
    }
}
