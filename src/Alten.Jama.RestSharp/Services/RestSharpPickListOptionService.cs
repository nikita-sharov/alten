using Alten.Jama.Models;
using RestSharp;
using System.Threading.Tasks;

namespace Alten.Jama.Services
{
    // See: https://rest.jamasoftware.com/#datatype_RequestPickListOption
    public sealed class RestSharpPickListOptionService : IPickListOptionService
    {
        private readonly IRestClient _client;

        public RestSharpPickListOptionService(IRestClient client) => _client = client;

        public Task<DataResponse<PickListOption>> GetAsync(int pickListOptionId)
        {
            IRestRequest request = RestRequestFactory.Create($"/picklistoptions/{pickListOptionId}", "data.pickList");
            return _client.GetAsync<DataResponse<PickListOption>>(request);
        }

        public Task<MetaResponse> PutAsync(int pickListOptionId, PickListOptionRequest body)
        {
            IRestRequest request = RestRequestFactory.Create($"/picklistoptions/{pickListOptionId}");
            request.AddJsonBody(body);
            return _client.PutAsync<MetaResponse>(request);
        }
    }
}
