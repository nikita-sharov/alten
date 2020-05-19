using ServiceStack;
using System;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Reflection;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace JamaClient.ServiceStack
{
    public sealed class JamaClient
    {
        private readonly HttpClient _client;

        public JamaClient(string baseUrl, string username, string password)
        {
            _client = new HttpClient
            {
                BaseAddress = new Uri(baseUrl)
            };

            string scheme = AuthenticationSchemes.Basic.ToString();
            byte[] bytes = Encoding.UTF8.GetBytes($"{username}:{password}");
            string credentials = Convert.ToBase64String(bytes);
            _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(scheme, credentials);
        }

        public async Task<TResponse> GetAsync<TResponse>(IReturn<TResponse> request)
        {
            Type requestType = request.GetType();
            var route = requestType.GetCustomAttribute<RouteAttribute>();



            string relativeUrl = string.Empty;
            string json = await _client.GetStringAsync(relativeUrl);

            return default(TResponse);
        }
    }
}
