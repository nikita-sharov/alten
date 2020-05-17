using Alten.Jama.Models;
using RestSharp;
using System.Diagnostics;
using System.Net;
using System.Threading.Tasks;

namespace Alten.Jama.Services
{
    public sealed class RestSharpPickListService : IPickListService
    {
        private readonly IRestClient _client;

        public RestSharpPickListService(IRestClient client) => _client = client;

        public async Task DeleteAsync(int pickListId)
        {
            IRestRequest request = RestRequestFactory.Create($"/picklists/{pickListId}");
            IRestResponse response = await _client.ExecuteAsync(request, Method.DELETE);
            Debug.Assert(response.StatusCode == HttpStatusCode.NoContent);
        }

        public Task<DataResponse<PickList>> GetAsync(int pickListId)
        {
            IRestRequest request = RestRequestFactory.Create($"/picklists/{pickListId}");
            return _client.GetAsync<DataResponse<PickList>>(request);
        }

        public Task<DataListResponse<PickList>> GetListAsync(int startAt, int maxResults)
        {
            IRestRequest request = RestRequestFactory.Create($"/picklists", startAt, maxResults);
            return _client.GetAsync<DataListResponse<PickList>>(request);
        }

        public Task<DataListResponse<PickListOption>> GetOptionListAsync(int pickListId, int startAt, int maxResults)
        {
            IRestRequest request = RestRequestFactory.Create(
                $"/picklists/{pickListId}/options", startAt, maxResults, "data.pickList");
            return _client.GetAsync<DataListResponse<PickListOption>>(request);
        }

        public Task<MetaResponse> CreateAsync(PickListRequest body)
        {
            IRestRequest request = RestRequestFactory.Create("/picklists");
            request.AddJsonBody(body);
            return _client.PostAsync<MetaResponse>(request);
        }

        public Task<MetaResponse> CreateOptionAsync(int pickListId, PickListOptionRequest body)
        {
            IRestRequest request = RestRequestFactory.Create($"/picklists/{pickListId}/options");
            request.AddJsonBody(body);
            return _client.PostAsync<MetaResponse>(request);
        }
    }
}
