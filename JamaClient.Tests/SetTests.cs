using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace JamaClient.Tests
{
    [TestClass]
    public class SetTests
    {
        [TestMethod]
        public void Test()
        {
            ISet<string> set = new HashSet<string>
            {
                "a",
                "a"
            };
        }
    }
}
