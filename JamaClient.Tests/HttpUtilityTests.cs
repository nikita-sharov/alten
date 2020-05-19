using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Web;

namespace JamaClient.Tests
{
    [TestClass]
    public class HttpUtilityTests
    {
        [TestMethod]
        public void Test()
        {
            string result = HttpUtility.UrlEncode("name=bubu gaga");
        }
    }
}
