using JamaClient.Models;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace JamaClient.Services
{
    public sealed class ProjectService : IProjectService
    {
        private const int MaxResultsDefault = 20;
        private const int MaxResultsMax = 50;

        private RestClient _client = RestClientFactory.Create("projects");

        public async Task<DataResponse<Project>> GetAsync(int id, List<string> include = null)
        {
            var request = new RestRequest($"/{id}");
            include?.ForEach(value => request.AddParameter(nameof(include), value));
            return await _client.GetAsync<DataResponse<Project>>(request);
        }

        public async Task<DataListResponse<Project>> GetAsync(
            int? startAt = null, int? maxResults = null, List<string> include = null)
        {
            var request = new RestRequest();

            if (startAt.HasValue)
            {
                Debug.Assert((startAt >= 0) && (startAt < int.MaxValue));
                request.AddParameter(nameof(startAt), startAt);
            }

            if (maxResults.HasValue)
            {
                Debug.Assert((maxResults > 0) && (maxResults <= MaxResultsMax));
                if (maxResults != MaxResultsDefault)
                {
                    request.AddParameter(nameof(maxResults), maxResults);
                }
            }

            include?.ForEach(value => request.AddParameter(nameof(include), value));
            return await _client.GetAsync<DataListResponse<Project>>(request);
        }

        public async Task<MetaResponse> CreateAsync(ProjectRequest body)
        {
            if (body.IsFolder)
            {
                Debug.Assert(body.ProjectKey == null);
            }
            else
            {
                Debug.Assert(!string.IsNullOrEmpty(body.ProjectKey));
                Debug.Assert(body.ProjectKey.Length <= 16);

                // Letters, numbers, and underscores
                bool consistsOfWordCharacters = Regex.IsMatch(body.ProjectKey, pattern: @"^\w+$");
                Debug.Assert(consistsOfWordCharacters);
            }

            Debug.Assert(body.Fields.ContainsKey(EntityField.Name));
            Debug.Assert(!string.IsNullOrWhiteSpace(body.Fields[EntityField.Name] as string));

            var request = new RestRequest();
            request.AddJsonBody(body);
            return await _client.PostAsync<MetaResponse>(request);
        }

        public async Task<MetaResponse> UpdateAsync(int id, ProjectRequest body)
        {
            var request = new RestRequest($"/{id}");
            request.AddJsonBody(body);
            return await _client.PutAsync<MetaResponse>(request);
        }

        public async Task<MetaResponse> AddItemTypeAsync(int projectId, int itemTypeId)
        {
            throw new NotImplementedException();
        }

        public async Task<MetaResponse> RemoveItemTypeAsync(int projectId, int itemTypeId)
        {
            throw new NotImplementedException();
        }
    }
}
