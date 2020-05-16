using Alten.Jama.Tests;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Alten.Jama
{
    [TestClass]
    public class JamaOptionsFactoryCreate
    {
        [TestMethod]
        public void Create()
        {
            JamaOptions options = JamaOptionsFactory.Create();

            Assert.IsNotNull(options);
            Assert.IsFalse(string.IsNullOrWhiteSpace(options.BaseUrl));
            Assert.IsFalse(string.IsNullOrWhiteSpace(options.Username));
            Assert.IsFalse(string.IsNullOrWhiteSpace(options.Password));
        }
    }
}
