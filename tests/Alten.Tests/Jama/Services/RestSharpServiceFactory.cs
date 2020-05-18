using Alten.Jama.Serialization;
using RestSharp;
using System;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;

namespace Alten.Jama.Services
{
    public static class RestSharpServiceFactory
    {
        private static readonly IRestClient Client;

        [SuppressMessage(
            "Performance", "CA1810:Initialize reference type static fields inline", Justification = "Readability")]
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
