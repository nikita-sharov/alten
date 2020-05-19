using Alten.Career.ViewModels;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Net.Mime;
using System.Text;

namespace Alten.Career.Models
{
    internal static class JobApplicationPool
    {
        public static readonly JobApplication MyJobApplication = new JobApplication
        {
            JobId = JobViewModelPool.YourJob.Id,
            Salutation = Salutation.Mr,
            FirstName = "Nikita",
            LastName = "Sharov",
            Citizenship = "Russian Federation",
            Address = "Mariatroster Straße 172/4",
            PostalCode = "8044",
            Location = "Graz",
            DateOfBirth = DateTime.Parse("14.09.1982", FormatProvider),
            Email = "nikita.sharov@235u.net",
            PrimaryPhone = "+43 664 182 22 83",
            StartingDate = DateTime.Parse("01.06.2020", FormatProvider),
            YearlySalaryInEuros = JobViewModelPool.YourJob.MonthlySalaryInEuros * 14,
            RegisteredAsUnemployed = false,
            Attachments = new List<JobApplicationAttachment>
            {
                new JobApplicationAttachment
                {
                    Content = Encoding.UTF8.GetBytes("..."),
                    ContentType = MediaTypeNames.Text.Plain,
                    FileName = "README.md"
                }
            }
        };

        private static readonly IFormatProvider FormatProvider = new CultureInfo("de");

        static JobApplicationPool()
        {
            Assert.That.IsValid(MyJobApplication);
        }
    }
}
