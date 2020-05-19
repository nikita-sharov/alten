using System;
using System.Threading.Tasks;

namespace JamaClient.Services
{
    public interface IRestService
    {
        Task<TResponse> GetAsync<TResponse>(Uri uri) where TResponse : new();

        Task<TResponse> PostAsync<TResponse>(Uri uri, object body) where TResponse : new();

        Task<TResponse> PutAsync<TResponse>(Uri uri, object body) where TResponse : new();

        Task DeleteAsync(Uri uri);
    }
}
