using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Alten.Jama.Models
{
    [TestClass]
    public sealed class CreateUserRequestTests
    {
        [TestMethod]
        public void Test()
        {
            var request = new CreateUserRequest
            {
                Username = "a b"
            };

            Assert.That.IsValid(request);
        }
    }
}
