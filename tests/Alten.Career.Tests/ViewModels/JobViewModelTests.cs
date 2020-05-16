using Alten.Career.Models;
using Alten.Jama;
using Alten.Jama.Models;
using Alten.Jama.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Alten.Career.ViewModels
{
    [TestClass]
    public class JobViewModelTests
    {
        [TestMethod]
        public async Task RealTest()
        {
            ////IUserService _usersApi = null;

            Job job = null;

            User contactPersonUser = await GetJamaUserAsync(job.ContactPerson);
            Project jamaProject = await GetJamaProjectAsync();


        }

        private async Task<User> GetJamaUserAsync(Employee contactPerson)
        {
            IUserService _usersApi = null;

            ////DataListResponse<User> userDataListWrapper = await _usersApi.GetListAsync(username: contactPerson.Email);
            DataListResponse<User> userDataListWrapper = null;
            if (userDataListWrapper.Meta.PageInfo.ResultCount == 0)
            {
                var request = new UserRequest
                {
                    Username = contactPerson.Email,
                    Password = "123456",
                    Title = Salutation.Mrs.ToString(),
                    FirstName = contactPerson.FirstName,
                    LastName = contactPerson.LastName,
                    Phone = contactPerson.Phone,
                    Email = contactPerson.Email
                };

                MetaResponse createdResponse = await _usersApi.PostAsync(request);
                DataResponse<User> userDataWrapper = await _usersApi.GetAsync(createdResponse.Meta.Id.Value);
                return userDataWrapper.Data;
            }

            return userDataListWrapper.Data.Single();
        }

        private async Task<Project> GetJamaProjectAsync()
        {
            IProjectService _projectsApi = null;

            Project project = null;
            PageInfo pageInfo = null;

            do
            {
                int startAt = pageInfo?.ResultCount ?? 0;
                DataListResponse<Project> projectDataListWrapper = await _projectsApi.GetListAsync(
                    startAt, JamaOptions.MaxResultsMax);

                pageInfo = projectDataListWrapper.Meta.PageInfo;
                project = projectDataListWrapper.Data.SingleOrDefault(p => p.ProjectKey == "HR");
                if (project != null)
                {
                    return project;
                }
            }
            while ((pageInfo.StartIndex + pageInfo.ResultCount) < pageInfo.TotalResults);

            if (project == null)
            {
                var request = new ProjectRequest
                {
                    ProjectKey = "HR",
                    Fields = new Dictionary<string, object>
                    {
                        [EntityField.Name] = "Recruiting Management"
                    }
                };

                MetaResponse createdResponse = await _projectsApi.PostAsync(request);
                DataResponse<Project> projectDataWrapper = await _projectsApi.GetAsync(createdResponse.Meta.Id.Value);
                project = projectDataWrapper.Data;
            }

            return project;
        }
    }
}
