using JamaClient.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace JamaClient.Services
{
    public interface IPickListOptionService
    {
        Task<DataResponse<PickListOption>> GetAsync(int id, IEnumerable<string> include = null);

        Task<MetaResponse> UpdateAsync(int id, PickListOptionRequest body);
    }
}
