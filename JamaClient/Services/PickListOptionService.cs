using JamaClient.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace JamaClient.Services
{
    public sealed class PickListOptionService : ServiceBase, IPickListOptionService
    {
        private readonly IRestService _restService;

        public PickListOptionService(IRestService restService) : base("picklistoptions") => _restService = restService;

        public Task<DataResponse<PickListOption>> GetAsync(int id, IEnumerable<string> include = null)
        {
            ////var requestUri = new Uri($"picklistoptions/{id}", UriKind.Relative);

            ////var builder = new UriBuilder();

            ////var request = new DataRequest($"picklistoptions/{id}");

            Uri requestUri = CreateRequestUri(id, include);
            return _restService.GetAsync<DataResponse<PickListOption>>(requestUri);
        }

        public Task<MetaResponse> UpdateAsync(int id, PickListOptionRequest body)
        {
            Debug.Assert(body != null);
            Debug.Assert(body.IsValid());

            Uri requestUri = CreateRequestUri(id);
            return _restService.PutAsync<MetaResponse>(requestUri, body);
        }
    }
}
