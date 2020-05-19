using JamaClient.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace JamaClient.Services
{
    public interface IPickListService
    {
        Task<DataResponse<PickList>> GetAsync(int id, IEnumerable<string> include = null);

        Task<DataListResponse<PickList>> GetAsync(int? startAt = null, int? maxResults = null);

        Task<DataListResponse<PickListOption>> GetOptionsAsync(int id, int? startAt = null, int? maxResults = null);

        Task<MetaResponse> CreateAsync(PickListRequest body);

        Task<MetaResponse> CreateOptionAsync(int id, PickListOptionRequest body);

        Task<MetaResponse> DeleteAsync(int id);
    }
}
