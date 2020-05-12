using Alten.Career.Models;
using Alten.Career.Tests;
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
        public static readonly JobViewModel YourJob = new JobViewModel
        {
            ReferenceNumber = 3461,
            Title = "Software Developer (m/f/d) C#",
            Location = "Graz",
            ApplicationAreas = ApplicationAreas.SoftwareDevelopment,
            BusinessBranches = BusinessBranches.SemiconductorTechnology,
            EntryLevels = EntryLevels.ExperiencedProfessionals,
            Tasks = new List<string>
            {
                @"As a Software Developer (m/f/d) C# you are responsible for programming software using C# and .NET in 
the semiconductor industry",
                "In the course of this you stabilize the TCE architecture and you provide the connection to JAMA",
                "You are responsible for providing advanced functions collecting within user surveys"
            },
            Profile = new List<string>
            {
                @"You have a completed technical education (University/University of Applied Sciences) in software 
development, computer science or equivalent",
                @"Relevant professional experience with C#, preferably with v7+, as well as solid knowledge in DI and 
IoC and NuGet package management are required for this position",
                @"You also have Git experience (at least all basic operations) and understand the importance of feature 
branches",
                @"Moreover, you have a solid WPF knowledge (control- & data templates, styles, trigger, bindings) as 
well as experience with MVVM pattern",
                "Fluent English and basic German skills complete your profile"
            },
            MonthlySalaryInEuros = 3_400,
            ContactPerson = new EmployeeViewModel
            {
                FirstName = "Barbara",
                LastName = "Stankovic",
                JobTitle = "Recruiting Manager",
                Phone = "+43 664 39 85 200",
                Email = "+43 664 39 85 200"
            }
        };

        [TestMethod]
        public void Validate()
        {
            Assert.That.IsValid(YourJob);
        }

        [TestMethod]
        public async Task RealTest()
        {
            IUserService _usersApi = null;

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

        private async Task<Item> GetJobJamaItemAsync(Job job)
        {
            return null;
        }

        private async Task<Item> GetJobApplicationJamaItem(JobApplication application)
        {
            return null;
        }
    }
}
