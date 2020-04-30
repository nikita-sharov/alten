using Alten.Career.Helpers;
using Alten.Career.Models;
using Alten.Career.ViewModels;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Net.Mime;
using System.Reflection;
using System.Text;

namespace Alten.Career.Tests.ViewModels
{
    [TestClass]
    public class JobApplicationViewModelTests
    {        
        public static JobApplicationViewModel MyJobApplication = new JobApplicationViewModel
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
            YearlySalaryInEuros = JobViewModelTests.YourJob.MonthlySalaryInEuros * 14,
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

        [TestMethod]
        public void Validate()
        {
            Assert.That.IsValid(MyJobApplication);
        }

        private static string GetDisplayName(Expression<Func<JobApplicationViewModel, object>> propertyExpression)
        {
            PropertyInfo property = PropertyInfoHelper.GetPropertyInfo(propertyExpression);
            return DisplayAttributeHelper.GetName(property);
        }

        [TestMethod]
        public void GetDisplayName()
        {
            Assert.AreEqual("Salutation", GetDisplayName(model => model.Salutation));
            Assert.AreEqual("Title", GetDisplayName(model => model.AcademicTitle));
            Assert.AreEqual("First name*", GetDisplayName(model => model.FirstName));
            Assert.AreEqual("Surname*", GetDisplayName(model => model.LastName));
            Assert.AreEqual("Nationality", GetDisplayName(model => model.Citizenship));
            Assert.AreEqual("Address*", GetDisplayName(model => model.Address));
            Assert.AreEqual("Zip*", GetDisplayName(model => model.PostalCode));
            Assert.AreEqual("Place*", GetDisplayName(model => model.Location));
            Assert.AreEqual("Date of birth", GetDisplayName(model => model.DateOfBirth));
            Assert.AreEqual("E-mail*", GetDisplayName(model => model.Email));
            Assert.AreEqual("Telephone*", GetDisplayName(model => model.PrimaryPhone));
            Assert.AreEqual("Mobile", GetDisplayName(model => model.SecondaryPhone));
            Assert.AreEqual("Starting date*", GetDisplayName(model => model.StartingDate));
            Assert.AreEqual("Salary requirement in € per year", GetDisplayName(model => model.YearlySalaryInEuros));
            Assert.AreEqual(
                "Are you registered for job search by Public Employment Service Austria (AMS)?",
                GetDisplayName(model => model.RegisteredAsUnemployed));
            Assert.AreEqual("Short letter/Comments", GetDisplayName(model => model.ShortLetter));
            Assert.AreEqual("Upload application*", GetDisplayName(model => model.Attachments));
            Assert.AreEqual("I accept the privacy note.", GetDisplayName(model => model.PrivacyNoteAccepted));
        }
    }
}
