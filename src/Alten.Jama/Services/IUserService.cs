using Alten.Jama.Models;
using System.Threading.Tasks;

namespace Alten.Jama.Services
{
    // See: https://rest.jamasoftware.com/#endpoint_users
    public interface IUserService
    {
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

        Task<MetaResponse> PostAsync(UserRequest body);

        Task<MetaResponse> PutActiveAsync(int userId, ActiveStatusRequest body);

        /// <summary>
        /// Updates the specified user ignoring <see cref="UserRequest"/>'s properties having null values.
        /// </summary>
        Task<MetaResponse> PutAsync(int userId, UserRequest body);
    }
}
