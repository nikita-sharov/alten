using JamaClient.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace JamaClient.Services
{
    /// <summary>
    /// 'Users' endpoint (https://your-tenant.jamacloud.com/rest/latest/users).
    /// </summary>
    /// <remarks>
    /// Actually, there is no possiblity to delete a user ("soft deletion" via user's deactivation).
    /// </remarks>
    /// <seealso href="https://rest.jamasoftware.com/#endpoint_users"/>
    /// <seealso href="https://help.jamasoftware.com/ah/en/administration/organization-administrator/manage-users.html"/>
    /// <seealso href="https://help.jamasoftware.com/ah/en/administration/project-administrator/manage-project-users.html"/>
    public interface IUserService
    {       
        Task<DataResponse<User>> GetAsync(int id, List<string> include = null);

        Task<DataListResponse<User>> GetAsync(
            string username = null,
            string email = null,
            string firstName = null,
            string lastName = null,
            LicenseType? licenseType = null,
            bool? includeInactive = null,
            int? startAt = null,
            int? maxResults = null,
            List<string> include = null);

        Task<DataResponse<User>> GetCurrentAsync(List<string> include = null);

        Task<FilterDataListWrapper> GetCurrentFavoriteFiltersAsync(
            int? startAt = null, int? maxResults = null, List<string> include = null);

        Task<MetaResponse> CreateAsync(UserRequest body);

        /// <summary>
        /// Updates the specified user ignoring <see cref="UserRequest"/>'s properties having null values.
        /// </summary>
        Task<MetaResponse> UpdateAsync(int id, UserRequest body);

        Task<MetaResponse> SetActiveStatusAsync(int id, ActiveStatusRequest body);
    }
}
