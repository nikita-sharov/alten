using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Text.RegularExpressions;

namespace JamaClient.Tests
{
    [TestClass]
    public class RouteTests
    {
        [TestMethod]
        public void Test()
        {
            var format = "picklists/{Id}";
            var matches = Regex.Matches(format, @"{(\w+)}");

            var request = new Request
            {
                Id = 100
            };

            Type requestType = request.GetType();

            ////foreach (Match match in matches)
            ////{
            ////    if (match.Groups[0].Success)
            ////    {
            ////        var propertyName = match.Groups[1].Value;
            ////        var propertyValue = requestType.GetProperty(propertyName).GetValue(request);
            ////    }
            ////}

            string result = Regex.Replace(input: "picklists/{Id}", @"{(\w+)}", (match) =>
            {
                if (match.Groups[0].Success)
                {
                    var propertyName = match.Groups[1].Value;
                    object propertyValue = requestType.GetProperty(propertyName).GetValue(request);
                    return propertyValue?.ToString();
                }

                return match.Value;
            });
        }

        private class Request
        {
            public int Id { get; set; }
        }
    }
}
