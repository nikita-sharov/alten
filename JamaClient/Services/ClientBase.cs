using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace JamaClient.Services
{
    public abstract class ClientBase : IRestService
    {
        public abstract Task<TResponse> DeleteAsync<TResponse>(Uri uri) where TResponse : new();

        public Task DeleteAsync(Uri uri)
        {
            throw new NotImplementedException();
        }



        public Task<TResponse> GetAsync<TResponse>(Uri uri) where TResponse : new()
        {
            throw new NotImplementedException();
        }

        public Task<TResponse> PostAsync<TResponse>(Uri uri, object body) where TResponse : new()
        {
            throw new NotImplementedException();
        }

        public Task<TResponse> PutAsync<TResponse>(Uri uri, object body) where TResponse : new()
        {
            throw new NotImplementedException();
        }
    }
}
