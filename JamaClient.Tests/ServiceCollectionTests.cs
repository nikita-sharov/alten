using Microsoft.Extensions.DependencyInjection;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace JamaClient.Tests
{
    [TestClass]
    public class ServiceCollectionTests
    {
        [TestMethod]
        public void Test()
        {
            IServiceCollection services = new ServiceCollection();
            services.AddTransient<ISerializer, Serializer>();
            services.AddTransient<IClient, Client>();

            IServiceProvider provider = services.BuildServiceProvider();
            
            IClient client = provider.GetRequiredService<IClient>();
            client.Send();
        }
    }

    public interface ISerializer
    {
        void Serialize();
    }

    public class Serializer : ISerializer
    {
        public void Serialize()
        {
        }
    }

    public interface IClient
    {
        void Send();
    }

    public class Client : IClient
    {
        private readonly ISerializer _serializer;

        public Client(ISerializer serializer)
        {
            _serializer = serializer;
        }

        public void Send()
        {
            _serializer.Serialize();
        }
    }
}
