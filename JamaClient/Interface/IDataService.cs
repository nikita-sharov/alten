using JamaClient.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace JamaClient.Interface
{
    public interface IDataService
    {
        Task<User> GetUserAsync(int id);

        Task<IList<User>> GetUsersAsync();

        Task<int> UpdateUserAsync(User user);
    }
}
