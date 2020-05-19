using Microsoft.AspNetCore.WebUtilities;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace JamaClient.Tests
{
    [TestClass]
    public class ReasonPhraseseTests
    {
        [TestMethod]
        public void Test()
        {
            string phrase = ReasonPhrases.GetReasonPhrase((int)HttpStatusCode.Unauthorized);
        }
    }
}
