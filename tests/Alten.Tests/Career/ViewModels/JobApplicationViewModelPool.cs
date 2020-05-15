using Alten.Career.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Net.Mime;
using System.Text;

namespace Alten.Career.ViewModels
{
    public static class JobApplicationViewModelPool
    {
        public static readonly JobApplicationViewModel MyJobApplication = new JobApplicationViewModel
        {
            Salutation = Salutation.Mr,
            FirstName = "Nikita",
            LastName = "Sharov",
            Citizenship = "Russian Federation",
            Address = "Mariatroster Straße 172/4",
            PostalCode = "8044",
            Location = "Graz",
            DateOfBirth = DateTime.Parse("14.09.1982"),
            Email = "nikita.sharov@235u.net",
            PrimaryPhone = "+43 664 182 22 83",
            StartingDate = DateTime.Parse("01.06.2020"),
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
            },
            PrivacyNoteAccepted = true
        };

        static JobApplicationViewModelPool()
        {
            Assert.That.IsValid(MyJobApplication);
        }
    }
}
