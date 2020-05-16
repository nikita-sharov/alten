using Alten.Jama.Models;
using System.Threading.Tasks;

namespace Alten.Jama.Services
{
    // See: https://rest.jamasoftware.com/#endpoint_usergroups
    public interface IUserGroupService
    {
        Task<MetaResponse> CreateAsync(UserGroupRequest body);

        Task<DataResponse<UserGroup>> GetAsync(int userGroupId);

        Task<DataListResponse<UserGroup>> GetListAsync(int? projectId, int startAt, int maxResults);

        Task<MetaResponse> AddUserAsync(int userGroupId, int userId);

        Task<DataListResponse<User>> GetUserListAsync(int userGroupId, int startAt, int maxResults);

        Task RemoveUserAsync(int userGroupId, int userId);

        Task<MetaResponse> UpdateAsync(int userGroupId, UserGroupRequest body);

        Task DeleteAsync(int userGroupId);
    }
}
