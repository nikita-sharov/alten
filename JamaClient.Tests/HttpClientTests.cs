using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Mime;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;
using JamaClient.Services;
using JamaClient.Models;

namespace JamaClient.Tests
{
    [TestClass]
    public class HttpClientTests
    {
        private const string Username = "";
        private const string Password = "";
        
        [TestMethod]
        public async Task Test()
        {
            using var client = new HttpClient();

            string scheme = AuthenticationSchemes.Basic.ToString();
            byte[] bytes = Encoding.UTF8.GetBytes($"{Username}:{Password}");
            string credentials = Convert.ToBase64String(bytes);
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(scheme, credentials);

            ////var mediaType = new MediaTypeWithQualityHeaderValue(MediaTypeNames.Application.Json);
            ////client.DefaultRequestHeaders.Accept.Add(mediaType);
           
            ////client.BaseAddress = new Uri(string.Empty);

            string route = string.Empty + "/picklists/-1";

            HttpResponseMessage response = await client.DeleteAsync(route);

            ////string json = await client.GetStringAsync(route);
            ////JsonSerializerOptions options = RestClientFactory.CreateJsonSerializerOptions();
            ////var result = JsonSerializer.Deserialize<DataResponse<User>>(json, options);
        }

        [TestMethod]
        public async Task TestServer()
        {
            using var client = new HttpClient();
            var uri = new Uri(string.Empty);
            HttpResponseMessage response = await client.GetAsync(uri);
        }

        [TestMethod]
        public void TestUriBuilder()
        {
            var builder = new UriBuilder(string.Empty);
            builder.Path += "/users";
            int maxResults = 50;
            builder.Query = $"{nameof(maxResults)}={maxResults}";
        }

        [TestMethod]
        public void TestQueryCollection()
        {
            
        }

        [TestMethod]
        public async Task TestDelete()
        {
            ////HttpResponseMessage response = await _client.DeleteAsync(uri);
            ////if (response.StatusCode != System.Net.HttpStatusCode.NoContent)
            ////{
            ////    string json = await response.Content.ReadAsStringAsync();
            ////    if (!string.IsNullOrEmpty(json))
            ////    {
            ////        var metaResponse = JsonSerializer.Deserialize<MetaResponse>(json);
            ////    }

            ////}
        }
    }
}
