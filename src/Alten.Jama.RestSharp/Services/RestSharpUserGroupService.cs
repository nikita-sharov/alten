using Alten.Jama.Models;
using RestSharp;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Alten.Jama.Services
{
    public sealed class RestSharpUserGroupService : IUserGroupService
    {
        private readonly IRestClient _client;

        public RestSharpUserGroupService(IRestClient client) => _client = client;

        public Task DeleteAsync(int userGroupId)
        {
            IRestRequest request = RestRequestFactory.Create($"/usergroups/{userGroupId}");
            return _client.ExecuteAsync(request, Method.DELETE);
        }

        public Task RemoveUserAsync(int userGroupId, int userId)
        {
            IRestRequest request = RestRequestFactory.Create($"/usergroups/{userGroupId}/users/{userId}");
            return _client.ExecuteAsync(request, Method.DELETE);
        }

        public Task<DataResponse<UserGroup>> GetAsync(int userGroupId)
        {
            IRestRequest request = RestRequestFactory.Create($"/usergroups/{userGroupId}");
            return _client.GetAsync<DataResponse<UserGroup>>(request);
        }

        public Task<DataListResponse<UserGroup>> GetListAsync(
            int? projectId = null, int startAt = 0, int maxResults = 50)
        {
            IRestRequest request = RestRequestFactory.Create("/usergroups", startAt, maxResults);
            
            if (projectId.HasValue)
            {
                request.AddParameter("project", projectId);
            }

            return _client.GetAsync<DataListResponse<UserGroup>>(request);
        }

        public Task<DataListResponse<User>> GetUserListAsync(int userGroupId, int startAt, int maxResults)
        {
            IRestRequest request = RestRequestFactory.Create($"/usergroups/{userGroupId}/users", startAt, maxResults);
            return _client.GetAsync<DataListResponse<User>>(request);
        }

        public Task<MetaResponse> CreateAsync(UserGroupRequest body)
        {
            IRestRequest request = RestRequestFactory.Create("/usergroups");
            request.AddJsonBody(body);
            return _client.PostAsync<MetaResponse>(request);
        }

        public Task<MetaResponse> AddUserAsync(int userGroupId, int userId)
        {
            IRestRequest request = RestRequestFactory.Create($"/usergroups/{userGroupId}/users");
            var body = new GroupUserRequest
            {
                UserId = userId
            };

            request.AddJsonBody(body);
            return _client.PostAsync<MetaResponse>(request);
        }

        public Task<MetaResponse> UpdateAsync(int userGroupId, UserGroupRequest body)
        {
            IRestRequest request = RestRequestFactory.Create($"/usergroups/{userGroupId}");
            request.AddJsonBody(body);
            return _client.PutAsync<MetaResponse>(request);
        }

        // See: https://rest.jamasoftware.com/#datatype_RequestGroupUser
        private sealed class GroupUserRequest
        {
            [JsonPropertyName("user")]
            public int UserId { get; set; }
        }
    }
}
