using Microsoft.Extensions.Configuration;

namespace Alten.Jama
{
    internal static class JamaOptionsFactory
    {
        // See: https://docs.microsoft.com/en-us/aspnet/core/security/app-secrets
        public static JamaOptions Create()
        {
            var builder = new ConfigurationBuilder();
            IConfiguration configuration = builder.AddUserSecrets<JamaOptionsFactoryCreate>().Build();

            // See: https://docs.microsoft.com/en-us/aspnet/core/security/app-secrets#map-secrets-to-a-poco
            return configuration.GetSection(nameof(JamaOptions)).Get<JamaOptions>();
        }
    }
}
