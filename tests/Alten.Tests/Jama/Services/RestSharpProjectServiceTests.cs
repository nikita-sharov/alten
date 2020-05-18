using Alten.Jama.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Alten.Jama.Services
{
    [TestClass]
    public sealed class RestSharpProjectServiceTests
    {
        private readonly IProjectService _service = RestSharpServiceFactory.Create<RestSharpProjectService>();

        [TestMethod]
        public async Task EnsureCreatedAsync()
        {
            Project project = await GetOrCreateAsync();
            Assert.IsNotNull(project);
        }

        private async Task<Project> GetOrCreateAsync()
        {
            Project project = await FindProject(key: "HR");
            if (project == null)
            {
                var request = new ProjectRequest
                {
                    ProjectKey = "HR",
                    Fields = new Dictionary<string, object>
                    {
                        [EntityField.Name] = "Recruiting"
                    }
                };

                MetaResponse createdResponse = await _service.CreateAsync(request);
                DataResponse<Project> dataResponse = await _service.GetAsync(createdResponse.Meta.Id.Value);
                project = dataResponse.Data;
            }

            return project;
        }

        private async Task<Project> FindProject(string key)
        {
            Project project = null;
            int startAt = 0;
            PageInfo pageInfo = null;
            do
            {
                DataListResponse<Project> dataListResponse = await _service.GetListAsync(
                    startAt, JamaOptions.MaxResultsMax);
                project = dataListResponse.Data
                    .SingleOrDefault(p => p.ProjectKey.Equals(key, StringComparison.InvariantCultureIgnoreCase));
                if (project != null)
                {
                    break;
                }

                pageInfo = dataListResponse.Meta.PageInfo;
                startAt = pageInfo.StartIndex + pageInfo.ResultCount;
            }
            while (startAt < pageInfo.TotalResults);
            return project;
        }
    }
}
