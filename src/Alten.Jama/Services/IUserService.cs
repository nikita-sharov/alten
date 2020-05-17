using Alten.Jama.Models;
using System.Threading.Tasks;

namespace Alten.Jama.Services
{
    // See: https://rest.jamasoftware.com/#endpoint_users
    public interface IUserService
    {
        Task<MetaResponse> CreateAsync(CreateUserRequest body);

        Task<DataResponse<User>> GetAsync(int userId);

        Task<DataListResponse<User>> GetListAsync(
            string username,
            string email,
            string firstName,
            string lastName,
            LicenseType? licenseType,
            bool includeInactive,
            int startAt,
            int maxResults);

        Task<DataResponse<User>> GetCurrentAsync();

        Task<DataListResponse<Filter>> GetCurrentFilterListAsync(int startAt, int maxResults);

        // See: https://rest.jamasoftware.com/#operation_setActiveStatus
        Task<MetaResponse> ActivateAsync(int userId);

        // See: https://rest.jamasoftware.com/#operation_setActiveStatus
        Task<MetaResponse> DeactivateAsync(int userId);

        /// <summary>
        /// Updates the specified user ignoring <see cref="UserRequest"/>'s properties having null values.
        /// </summary>
        Task<MetaResponse> UpdateAsync(int userId, UpdateUserRequest body);
    }
}
