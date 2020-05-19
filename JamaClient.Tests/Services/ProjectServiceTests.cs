using JamaClient.Models;
using JamaClient.Serialization;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Threading.Tasks;

namespace JamaClient.Services
{
    [TestClass]
    public class ProjectServiceTests
    {
        private readonly ProjectService _api = new ProjectService();

        [TestMethod]
        public async Task GetAsync()
        {
            DataListResponse<Project> response = await _api.GetAsync();

            Assert.IsNotNull(response);
            Assert.That.IsOK(response.Meta);
            CollectionAssert.That.IsNotEmpty(response.Links);
            Assert.IsNull(response.Linked);
        }

        [TestMethod]
        public async Task GetAsync_IncludeLinks()
        {
            var links = new List<string>
            {
                "data.createdBy",
                "data.modifiedBy",
                "data.fields.projectGroup",
                "data.parent",
                "data.fields.statusId"
            };

            DataListResponse<Project> response = await _api.GetAsync(include: links);

            Assert.IsNotNull(response);
            Assert.That.IsOK(response.Meta);
            CollectionAssert.That.IsNotEmpty(response.Links);
            CollectionAssert.That.IsNotEmpty(response.Linked);
        }

        [TestMethod]
        ////[Ignore("Manual test as there is no (REST-API) way to delete newly created projects.")]
        public async Task CreateAsync()
        {
            var projectKey = Math.Abs(Guid.NewGuid().GetHashCode()).ToString();

            // Having a quirk whith the short date format (local time)?
            var startDate = DateTime.Today;
            var endDate = startDate.AddDays(1);

            var requestBody = new ProjectRequest()
            {
                ProjectKey = projectKey,
                Fields = new Dictionary<string, object>
                {
                    [EntityField.Name] = projectKey,
                    [EntityField.Description] = "Be descriptive",
                    [EntityField.ProjectManager] = 15,
                    [EntityField.Sponsor] = 18,
                    [EntityField.Objective] = "Dont be subjective",
                    [EntityField.StartDate] = DateTimeConverter.ToShortDateString(startDate),
                    [EntityField.EndDate] = DateTimeConverter.ToShortDateString(endDate),
                    [EntityField.Status] = 298,
                    [EntityField.Category] = 296
                }
            };

            Meta responseMeta = (await _api.CreateAsync(requestBody)).Meta;
           
            Assert.IsTrue(Uri.IsWellFormedUriString(responseMeta.Location, UriKind.Absolute));
            Assert.IsTrue(responseMeta.Id.HasValue);
            Assert.IsTrue(responseMeta.Id > 0);

            Project responseProject = (await _api.GetAsync(responseMeta.Id.Value)).Data;

            Assert.AreEqual(responseProject.CreatedDate.Date, DateTimeOffset.UtcNow.Date);
            Assert.AreEqual(responseProject.CreatedDate, responseProject.ModifiedDate);

            Dictionary<string, object> fields = responseProject.Fields;

            Assert.IsNotNull(fields);
            Assert.IsTrue(fields.ContainsKey(EntityField.Name));
            Assert.IsTrue(fields.ContainsKey(EntityField.Description));
            Assert.IsTrue(fields.ContainsKey(EntityField.ProjectManager));
            Assert.IsTrue(fields.ContainsKey(EntityField.Sponsor));
            Assert.IsTrue(fields.ContainsKey(EntityField.Objective));
            Assert.IsTrue(fields.ContainsKey(EntityField.StartDate));
            Assert.IsTrue(fields.ContainsKey(EntityField.EndDate));
            Assert.IsTrue(fields.ContainsKey(EntityField.Status));
            Assert.IsTrue(fields.ContainsKey(EntityField.Category));

            string startDateText = ((JsonElement)fields[EntityField.StartDate]).GetString();
            Assert.AreEqual(startDate, DateTimeConverter.FromShortDateString(startDateText));

            string endDateText = ((JsonElement)fields[EntityField.EndDate]).GetString();
            Assert.AreEqual(endDate, DateTimeConverter.FromShortDateString(endDateText));
        }

        [TestMethod]
        [Ignore("Manual test as there is no (REST-API) way to delete newly created projects.")]
        public async Task CreateAsync_Folder()
        {
            var requestBody = new ProjectRequest()
            {
                IsFolder = true,
                Fields = new Dictionary<string, object>
                {
                    [EntityField.Name] = Math.Abs(Guid.NewGuid().GetHashCode()).ToString()
                }
            };

            Meta responseMeta = (await _api.CreateAsync(requestBody)).Meta;

            Assert.IsTrue(Uri.IsWellFormedUriString(responseMeta.Location, UriKind.Absolute));
            Assert.IsTrue(responseMeta.Id.HasValue);
            Assert.IsTrue(responseMeta.Id > 0);

            Project project = (await _api.GetAsync(responseMeta.Id.Value)).Data;

            Assert.IsTrue(project.IsFolder);
            Assert.IsNull(project.ProjectKey);
        }
    }
}
