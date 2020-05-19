using JamaClient.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace JamaClient.Tests.Services
{
    [TestClass]
    public class RestSharpClientTests
    {
        public async Task DeleteAsync()
        {
            var client = new RestSharpClient("picklists");            
        }
    }
}
