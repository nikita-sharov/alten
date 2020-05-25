using Alten.Career.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace Alten.Career.ViewModels
{
    internal static class JobViewModelPool
    {
        public static readonly JobViewModel YourJob = new JobViewModel
        {
            Id = 3461,
            Title = "Software Developer (m/f/d) C#",
            Location = "Graz",
            ApplicationAreas = ApplicationAreas.SoftwareDevelopment,
            BusinessBranches = BusinessBranches.SemiconductorTechnology,
            EntryLevels = EntryLevels.ExperiencedProfessionals,
            Tasks = new List<string>
            {
                "As a Software Developer (m/f/d) C# you are responsible for programming software using C# and .NET",
                "In the course of this you stabilize the TCE architecture and you provide the connection to JAMA",
                "You are responsible for providing advanced functions collecting within user surveys"
            },
            Profile = new List<string>
            {
                "You have a completed technical education in software development, computer science or equivalent",
                "Relevant professional experience with C# are required for this position",
                "You also have Git experience (at least all basic operations)",
                "Moreover, you have a solid WPF knowledge as well as experience with MVVM pattern",
                "Fluent English and basic German skills complete your profile"
            },
            MonthlySalaryInEuros = 3_400,
            ContactPerson = new EmployeeViewModel
            {
                FirstName = "Barbara",
                LastName = "Stankovic",
                JobTitle = "Recruiting Manager",
                Phone = "+43 664 39 85 200",
                Email = "career@alten.at"
            }
        };

        static JobViewModelPool() => Assert.That.IsValid(YourJob);
    }
}
