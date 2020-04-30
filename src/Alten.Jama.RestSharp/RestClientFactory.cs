using RestSharp;
using RestSharp.Authenticators;
using RestSharp.Serializers.SystemTextJson;
using System.Text.Json;

namespace Alten.Jama
{
    public static class RestClientFactory
    {
        public static IRestClient Create(JamaOptions jamaOptions, JsonSerializerOptions serializerOptions)
        {
            var client = new RestClient(jamaOptions.BaseUrl)
            {
                Authenticator = new HttpBasicAuthenticator(jamaOptions.Username, jamaOptions.Password)
            };

            return client.UseSystemTextJson(serializerOptions);           
        }
    }
}
