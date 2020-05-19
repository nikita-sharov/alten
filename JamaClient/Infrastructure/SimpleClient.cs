using JamaClient.Models;
using JamaClient.Serialization;
using System;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Mime;
using System.Text;
using System.Threading.Tasks;

namespace JamaClient.Services
{
    public sealed class SimpleClient : IRestService
    {
        private readonly ISerializationService _serializationService;

        public SimpleClient(ISerializationService serializationService)
        {
            _serializationService = serializationService;
        }

        private static HttpClient CreateHttpClient()
        {
            var client = new HttpClient
            {
                BaseAddress = new Uri(string.Empty)
            };

            client.DefaultRequestHeaders.Authorization = CreateAuthorizationHeader();
            return client;
        }

        private static AuthenticationHeaderValue CreateAuthorizationHeader()
        {
            const string Username = "";
            const string Password = "";

            string scheme = AuthenticationSchemes.Basic.ToString();
            byte[] bytes = Encoding.UTF8.GetBytes($"{Username}:{Password}");
            string credentials = Convert.ToBase64String(bytes);
            return new AuthenticationHeaderValue(scheme, credentials);
        }

        public async Task<TResponse> GetAsync<TResponse>(Uri uri) where TResponse : new()
        {
            using var client = CreateHttpClient();
            HttpResponseMessage response = await client.GetAsync(uri);
            string json = await response.Content.ReadAsStringAsync();
            return _serializationService.Deserialize<TResponse>(json);
        }

        public async Task<TResponse> PostAsync<TResponse>(Uri uri, object body) where TResponse : new()
        {
            using var client = CreateHttpClient();
            string json = _serializationService.Serialize(body);
            var content = new StringContent(json, Encoding.UTF8, MediaTypeNames.Application.Json);
            HttpResponseMessage response = await client.PostAsync(uri, content);
            json = await response.Content.ReadAsStringAsync();
            return _serializationService.Deserialize<TResponse>(json);
        }

        public async Task<TResponse> PutAsync<TResponse>(Uri uri, object body) where TResponse : new()
        {
            using var client = CreateHttpClient();
            string json = _serializationService.Serialize(body);
            var content = new StringContent(json, Encoding.UTF8, MediaTypeNames.Application.Json);
            HttpResponseMessage response = await client.PutAsync(uri, content);
            json = await response.Content.ReadAsStringAsync();
            return _serializationService.Deserialize<TResponse>(json);
        }

        public async Task DeleteAsync(Uri uri)
        {
            using var client = CreateHttpClient();
            HttpResponseMessage response = await client.DeleteAsync(uri);
            if (response.StatusCode != System.Net.HttpStatusCode.NoContent)
            {
                string json = await response.Content.ReadAsStringAsync();
                if (!string.IsNullOrEmpty(json))
                {
                    var metaResponse = _serializationService.Deserialize<MetaResponse>(json);
                }
            }
        }
    }
}
