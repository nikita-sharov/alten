using Alten.Jama.Models;
using System.Threading.Tasks;

namespace Alten.Jama.Services
{
    // See: https://rest.jamasoftware.com/#endpoint_picklists
    public interface IPickListService
    {
        Task<DataResponse<PickList>> GetAsync(int pickListId);

        Task<DataListResponse<PickList>> GetListAsync(int startAt, int maxResults);

        Task<DataListResponse<PickListOption>> GetOptionListAsync(int pickListId, int startAt, int maxResults);

        Task<MetaResponse> PostAsync(PickListRequest body);

        Task<MetaResponse> PostOptionAsync(int pickListId, PickListOptionRequest body);

        Task DeleteAsync(int pickListId);
    }
}
