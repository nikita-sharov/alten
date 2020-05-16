using Alten.Jama.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Alten.Jama.Services
{
    [TestClass]
    public sealed class RestSharpProjectServiceTests
    {
        private readonly IProjectService _service = RestSharpServiceFactory.Create<RestSharpProjectService>();

        [TestMethod]        
        public async Task CreateAsync()
        {
            var body = new ProjectRequest
            {
                ProjectKey = "HR",
                Fields = new Dictionary<string, object>
                {
                    [EntityField.Name] = "Recruiting"
                }
            };

            MetaResponse response = await _service.CreateAsync(body);
            Assert.IsNotNull(response);
        }

        [TestMethod]
        [DataRow(125)]
        public async Task GetAsync(int projectId)
        {
            DataResponse<Project> response = await _service.GetAsync(projectId);
            Assert.IsNotNull(response);
        }
    }
}
