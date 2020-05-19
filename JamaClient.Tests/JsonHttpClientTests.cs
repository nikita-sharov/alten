using Microsoft.VisualStudio.TestTools.UnitTesting;
using ServiceStack;
using ServiceStack.Text;
using System;
using System.Collections.Generic;
using System.Net;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace JamaClient.Tests
{
    [TestClass]
    public class JsonHttpClientTests
    {
        [TestMethod]
        public async Task TestJama()
        {
            var client = new JsonHttpClient(baseUri: string.Empty);
            client.SetCredentials(string.Empty, string.Empty);

            var request = new GetPicklists();
            var response = await client.GetAsync(request);
        }

        [Route("/picklists")]
        private class GetPicklists : IReturn<GetPicklistsResponse> 
        {
            public int StartAt { get; set; }

            public int MaxResults { get; set; } = 20;

            public string[] Include { get; set; } = Array.Empty<string>();
        }

        private class GetPicklistsResponse
        {
            public Meta Meta { get; set; }

            public Dictionary<string, Link> Links { get; set; }

            public Dictionary<string, Dictionary<string, object>> Linked { get; set; }

            public List<PickList> Data { get; set; }
        }

        private class Meta
        {
            public HttpStatusCode Status { get; set; }

            public DateTimeOffset Timestamp { get; set; }

            public PageInfo PageInfo { get; set; }
        }

        private class PageInfo
        {
            public int StartIndex { get; set; }

            public int ResultCount { get; set; }

            public int TotalResults { get; set; }
        }

        private class Link
        {
            public string Type { get; set; }

            public string Href { get; set; }
        }

        private class PickList
        {
            public int Id { get; set; }

            public string Name { get; set; }

            public string Description { get; set; }
        }

        [TestMethod]
        public async Task TestGitHub()
        {
            ////JsConfig.Init(new Config { TextCase = TextCase.SnakeCase });

            var client = new JsonHttpClient();
            client.AddHeader("User-Agent", "ServiceStack Test");
            var result = await client.GetAsync<List<Repository>>("https://api.github.com/orgs/dotnet/repos");
        }

        private class Repository
        {
            public string Name { get; set; }

            ////[DataMember(Name = "full_name")]
            public string FullName { get; set; }
        }
    }
}
