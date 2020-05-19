using Microsoft.AspNetCore.WebUtilities;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace JamaClient.Tests
{
    [TestClass]
    public class QueryStringHelpersTests
    {
        [TestMethod]
        public void Test()
        {
            string result = QueryHelpers.AddQueryString("https://abc.xyz", "bubu gaga", "bibi pipi");
        }
    }
}
