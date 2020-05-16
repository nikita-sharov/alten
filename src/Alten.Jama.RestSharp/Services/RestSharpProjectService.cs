using Alten.Jama.Models;
using RestSharp;
using System.Diagnostics;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Alten.Jama.Services
{
    public class RestSharpProjectService : IProjectService
    {
        private static readonly string[] LinksToInclude = new string[]
        {
            "data.createdBy",
            "data.modifiedBy",
            "data.fields.projectGroup",
            "data.parent",
            "data.fields.statusId"
        };

        private readonly IRestClient _client;

        public RestSharpProjectService(IRestClient client) => _client = client;

        public Task RemoveItemTypeAsync(int projectId, int itemTypeId)
        {
            IRestRequest request = RestRequestFactory.Create($"/projects/{projectId}/itemtypes/{itemTypeId}");
            return _client.ExecuteAsync(request, Method.DELETE);
        }

        public Task<DataResponse<Project>> GetAsync(int projectId)
        {
            IRestRequest request = RestRequestFactory.Create($"/projects/{projectId}", LinksToInclude);
            return _client.GetAsync<DataResponse<Project>>(request);
        }

        public Task<DataListResponse<Project>> GetListAsync(int startAt, int maxResults)
        {
            IRestRequest request = RestRequestFactory.Create("/projects", startAt, maxResults, LinksToInclude);
            return _client.GetAsync<DataListResponse<Project>>(request);
        }

        public Task<DataListResponse<ItemType>> GetItemTypeListAsync(int projectId, int startAt, int maxResults)
        {
            IRestRequest request = RestRequestFactory.Create($"/projects/{projectId}/itemtypes", startAt, maxResults);
            return _client.GetAsync<DataListResponse<ItemType>>(request);
        }

        public Task<DataListResponse<Tag>> GetTagListAsync(int projectId, int startAt, int maxResults)
        {
            IRestRequest request = RestRequestFactory.Create($"/projects/{projectId}/tags", startAt, maxResults);
            return _client.GetAsync<DataListResponse<Tag>>(request);
        }

        public Task<MetaResponse> CreateAsync(ProjectRequest body)
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

            IRestRequest request = RestRequestFactory.Create("/projects");
            request.AddJsonBody(body);
            return _client.PostAsync<MetaResponse>(request);
        }

        public Task<MetaResponse> CreateAttachmentAsync(int projectId, AttachmentRequest body)
        {
            IRestRequest request = RestRequestFactory.Create($"/projects/{projectId}/attachments");
            request.AddJsonBody(body);
            return _client.PostAsync<MetaResponse>(request);
        }

        public Task<MetaResponse> UpdateAsync(int projectId, ProjectRequest body)
        {
            IRestRequest request = RestRequestFactory.Create($"/projects/{projectId}");
            request.AddJsonBody(body);
            return _client.PutAsync<MetaResponse>(request);
        }

        public Task<MetaResponse> AddItemTypeAsync(int projectId, int itemTypeId)
        {
            IRestRequest request = RestRequestFactory.Create($"/projects/{projectId}/itemtypes/{itemTypeId}");
            return _client.PutAsync<MetaResponse>(request);
        }
    }
}
