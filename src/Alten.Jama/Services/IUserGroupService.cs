using Alten.Jama.Models;
using System.Threading.Tasks;

namespace Alten.Jama.Services
{
    // See: https://rest.jamasoftware.com/#endpoint_usergroups
    public interface IUserGroupService
    {
        Task DeleteAsync(int userGroupId);

        Task DeleteUserAsync(int userGroupId, int userId);

        Task<DataResponse<UserGroup>> GetAsync(int userGroupId);

        Task<DataListResponse<UserGroup>> GetListAsync(int? projectId, int startAt, int maxResults);

        Task<DataListResponse<User>> GetUserListAsync(int userGroupId, int startAt, int maxResults);

        Task<MetaResponse> PostAsync(UserGroupRequest body);

        Task<MetaResponse> PostUserAsync(int userGroupId, GroupUserRequest body);

        Task<MetaResponse> PutAsync(int userGroupId, UserGroupRequest body);
    }
}
