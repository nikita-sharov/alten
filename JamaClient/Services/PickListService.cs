using JamaClient.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace JamaClient.Services
{
    public sealed class PickListService : ServiceBase, IPickListService
    {
        ////private readonly RestClient _client = RestClientFactory.Create("picklists");
        private readonly IRestService _restService;

        public PickListService(IRestService restService) : base("picklists") => _restService = restService;

        public Task<DataResponse<PickList>> GetAsync(int id) => GetAsync(id, Enumerable.Empty<string>());

        public Task<DataResponse<PickList>> GetAsync(int id, IEnumerable<string> include)
        {
            Uri requestUri = CreateRequestUri(id, include);
            return _restService.GetAsync<DataResponse<PickList>>(requestUri);
        }

        public Task<DataListResponse<PickList>> GetAsync(int? startAt = null, int? maxResults = null)
        {
            Uri requestUri = CreateRequestUri(startAt, maxResults);
            return _restService.GetAsync<DataListResponse<PickList>>(requestUri);
        }

        public Task<DataListResponse<PickListOption>> GetOptionsAsync(
            int id, int? startAt = null, int? maxResults = null)
        {
            Uri requestUri = CreateRequestUri($"{id}/options", startAt, maxResults);
            return _restService.GetAsync<DataListResponse<PickListOption>>(requestUri);
        }

        public Task<MetaResponse> CreateAsync(PickListRequest body)
        {
            Uri requestUri = CreateRequestUri();
            return _restService.PostAsync<MetaResponse>(requestUri, body);
        }

        public Task<MetaResponse> CreateOptionAsync(int id, PickListOptionRequest body)
        {
            Debug.Assert(body != null);
            Debug.Assert(body.IsValid());

            Uri requestUri = CreateRequestUri($"{id}/options");
            return _restService.PostAsync<MetaResponse>(requestUri, body);
        }

        public async Task<MetaResponse> DeleteAsync(int id)
        {
            ////var request = new RestRequest($"/{id}", Method.DELETE);
            ////IRestResponse response = await _client.ExecuteAsync(request);
            ////if (response.StatusCode == HttpStatusCode.NoContent)
            ////{
            ////    // TODO: Return something else?
            ////    return null;
            ////}
            ////else
            ////{
            ////    return _client.Deserialize<MetaResponse>(response).Data;
            ////}

            Uri requestUri = CreateRequestUri(id);
            await _restService.DeleteAsync(requestUri);
            return null;
        }
    }
}
