using JamaClient.Serialization;
using RestSharp;
using RestSharp.Authenticators;
using RestSharp.Serializers.SystemTextJson;
using System.Text.Json;

namespace JamaClient.Services
{
    public static partial class RestClientFactory
    {
        // See: https://community.jamasoftware.com/blogs/jason/2019/11/22/sunset-of-rest-api-latest-coming-in-may-2020
        private const string BaseUrl = "";
        private const string Username = "";
        private const string Password = "";

        public static RestClient Create(string resource)
        {
            var client = new RestClient($"{BaseUrl}/{resource}")
            {
                Authenticator = new HttpBasicAuthenticator(Username, Password)
            };
            
            JsonSerializerOptions options = CreateJsonSerializerOptions();
            client.UseSystemTextJson(options);
            return client;
        }

        public static JsonSerializerOptions CreateJsonSerializerOptions()
        {
            var options = new JsonSerializerOptions()
            {
                
                PropertyNameCaseInsensitive = true,
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase
            };

            options.Converters.Add(new DateTimeOffsetConverter());
            options.Converters.Add(new EnumConverterFactory());
            return options;
        }
    }
}
