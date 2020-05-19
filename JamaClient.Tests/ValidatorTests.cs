using JamaClient.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Security;

namespace JamaClient.Tests
{
    [TestClass]
    public class ValidatorTests
    {
        [TestMethod]
        public void Test()
        {
            var request = new DataListRequest
            {
                StartAt = -1,
                MaxResults = 100
            };

            var context = new ValidationContext(request);
            ////var results = new List<ValidationResult>();
            Validator.ValidateObject(request, context, true);
        }

        [TestMethod]
        public void ValidateUserRequest()
        {
            var request = new UserRequest
            {
                Password = "oO"
            };

            var context = new ValidationContext(request);
            ////var results = new List<ValidationResult>();
            Validator.ValidateObject(request, context, true);
        }

        [TestMethod]
        public void TestUsername()
        {
            var request = new UserRequest
            {
                Username = string.Empty
            };

            var context = new ValidationContext(request);
            Validator.ValidateObject(request, context, true);
        }

        [TestMethod]
        public void TestCreateUserRequest()
        {
            var request = new CreateUserRequest
            {
                FirstName = string.Empty,
                LastName = string.Empty
            };

            var context = new ValidationContext(request);
            Validator.ValidateObject(request, context, true);
        }

        [TestMethod]
        public void TestUpdateUserRequest()
        {
            var request = new UpdateUserRequest
            {
                Username = string.Empty,
                FirstName = string.Empty,
                LastName = string.Empty
            };

            var context = new ValidationContext(request);
            Validator.ValidateObject(request, context, true);
        }
    }
}
