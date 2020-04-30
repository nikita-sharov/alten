using Alten.Jama.Models;
using RestSharp;
using System.Threading.Tasks;

namespace Alten.Jama.Services
{
    public sealed class RestSharpItemService : IItemService
    {
        private readonly IRestClient _client;

        public RestSharpItemService(IRestClient client) => _client = client;

        public Task DeleteAsync(int itemId)
        {
            IRestRequest request = RestRequestFactory.Create($"/items/{itemId}");
            return _client.ExecuteAsync(request, Method.DELETE);
        }

        public Task DeleteAttachmentAsync(int itemId, int attachmentId)
        {
            IRestRequest request = RestRequestFactory.Create($"/items/{itemId}/attachments/{attachmentId}");
            return _client.ExecuteAsync(request, Method.DELETE);
        }

        public Task<DataListResponse<Activity>> GetActivityListAsync(int itemId, int startAt, int maxResults)
        {
            IRestRequest request = RestRequestFactory.Create($"/items/{itemId}/activities", startAt, maxResults);
            return _client.GetAsync<DataListResponse<Activity>>(request);
        }

        public Task<DataListResponse<Item>> GetListAsync(
            int projectId, bool rootItemsOnly = false, int startAt = 0, int maxResults = JamaOptions.MaxResultsMax)
        {
            IRestRequest request = RestRequestFactory.Create("/items", startAt, maxResults);
            request.AddParameter("project", projectId);
            
            if (rootItemsOnly)
            {
                request.AddParameter("rootOnly", true);
            }

            return _client.GetAsync<DataListResponse<Item>>(request);
        }

        public Task<DataResponse<Item>> GetAsync(int itemId)
        {
            IRestRequest request = RestRequestFactory.Create($"/items/{itemId}");
            return _client.GetAsync<DataResponse<Item>>(request);
        }

        public Task<DataListResponse<Attachment>> GetAttachmentListAsync(int itemId, int startAt, int maxResults)
        {
            IRestRequest request = RestRequestFactory.Create($"/items/{itemId}/attachments", startAt, maxResults);
            return _client.GetAsync<DataListResponse<Attachment>>(request);
        }

        public Task<DataListResponse<Item>> GetChildListAsync(int itemId, int startAt, int maxResults)
        {
            IRestRequest request = RestRequestFactory.Create($"/items/{itemId}/children", startAt, maxResults);
            return _client.GetAsync<DataListResponse<Item>>(request);
        }

        public Task<DataListResponse<Comment>> GetCommentListAsync(
            int itemId, bool rootCommentsOnly = false, int startAt = 0, int maxResults = JamaOptions.MaxResultsMax)
        {
            IRestRequest request = RestRequestFactory.Create($"/items/{itemId}/comments", startAt, maxResults);

            if (rootCommentsOnly)
            {
                request.AddParameter(nameof(rootCommentsOnly), true);
            }

            return _client.GetAsync<DataListResponse<Comment>>(request);
        }

        public Task<MetaResponse> PatchAsync(int itemId, RequestPatchOperation body)
        {
            IRestRequest request = RestRequestFactory.Create($"/items/{itemId}");
            request.AddJsonBody(body);
            return _client.PatchAsync<MetaResponse>(request);
        }

        public Task<MetaResponse> PostAsync(RequestItem body)
        {
            IRestRequest request = RestRequestFactory.Create("/items");
            request.AddJsonBody(body);
            return _client.PostAsync<MetaResponse>(request);
        }

        public Task<MetaResponse> PostAttachmentAsync(int itemId, RequestItemAttachment body)
        {
            IRestRequest request = RestRequestFactory.Create($"/items/{itemId}/attachments");
            request.AddJsonBody(body);
            return _client.PostAsync<MetaResponse>(request);
        }

        public Task<MetaResponse> PutAsync(int itemId, RequestItem body)
        {
            IRestRequest request = RestRequestFactory.Create($"/items/{itemId}");
            request.AddJsonBody(body);
            return _client.PutAsync<MetaResponse>(request);
        }
    }
}
