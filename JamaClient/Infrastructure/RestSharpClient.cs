using JamaClient.Models;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Data;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace JamaClient.Services
{
    public sealed class RestSharpClient : IRestService
    {
        private readonly RestClient _client;

        public RestSharpClient(string resource) => _client = RestClientFactory.Create(resource);

        public Task<TResponse> GetAsync<TResponse>(Uri uri) where TResponse : new()
        {
            var request = new RestRequest(uri);
            return _client.GetAsync<TResponse>(request);
        }

        public Task<TResponse> PostAsync<TResponse>(Uri uri, object body) where TResponse : new()
        {
            var request = new RestRequest(uri);
            request.AddJsonBody(body);
            return _client.PostAsync<TResponse>(request);
        }

        public Task<TResponse> PutAsync<TResponse>(Uri uri, object body) where TResponse : new()
        {
            var request = new RestRequest(uri);
            request.AddJsonBody(body);
            return _client.PutAsync<TResponse>(request);
        }

        public async Task DeleteAsync(Uri uri)
        {
            var request = new RestRequest(uri, Method.DELETE);
            IRestResponse response = await _client.ExecuteAsync(request);
            if (response.StatusCode != HttpStatusCode.NoContent)
            {
                var result = _client.Deserialize<MetaResponse>(response).Data;
            }
        }
    }
}
