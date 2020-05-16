using Alten.Jama.Serialization;
using RestSharp;
using System;
using System.Text.Json;

namespace Alten.Jama.Services
{
    public static class RestSharpServiceFactory
    {
        private static readonly IRestClient Client;

        static RestSharpServiceFactory()
        {
            JamaOptions jamaOptions = JamaOptionsFactory.Create();
            JsonSerializerOptions serializerOptions = JsonSerializerOptionsFactory.Create();
            Client = RestClientFactory.Create(jamaOptions, serializerOptions);
        }

        public static TService Create<TService>()
        {
            return (TService)Activator.CreateInstance(typeof(TService), Client);
        }
    }
}
