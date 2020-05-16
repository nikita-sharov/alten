using Alten.Jama.Models;
using RestSharp;
using System.Threading.Tasks;

namespace Alten.Jama.Services
{
    public class RestSharpItemTypeService : IItemTypeService
    {
        private readonly IRestClient _client;

        public RestSharpItemTypeService(IRestClient client) => _client = client;

        public Task<DataListResponse<ItemType>> GetListAsync(int startAt, int maxResults)
        {
            IRestRequest request = RestRequestFactory.Create("/itemtypes", startAt, maxResults);
            return _client.GetAsync<DataListResponse<ItemType>>(request);
        }

        public Task<DataResponse<ItemType>> GetAsync(int itemTypeId)
        {
            IRestRequest request = RestRequestFactory.Create($"/itemtypes/{itemTypeId}");
            return _client.GetAsync<DataResponse<ItemType>>(request);
        }

        public Task<MetaResponse> PostAsync(ItemTypeRequest body)
        {
            IRestRequest request = RestRequestFactory.Create("/itemtypes");
            request.AddJsonBody(body);
            return _client.PostAsync<MetaResponse>(request);
        }

        public Task<MetaResponse> PostFieldAsync(int itemTypeId, ItemTypeFieldRequest body)
        {
            IRestRequest request = RestRequestFactory.Create($"/itemtypes/{itemTypeId}/fields");
            request.AddJsonBody(request);
            return _client.PostAsync<MetaResponse>(request);
        }
    }
}
