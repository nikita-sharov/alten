using Alten.Jama.Models;
using System.Threading.Tasks;

namespace Alten.Jama.Services
{
    // See: https://rest.jamasoftware.com/#endpoint_picklists
    public interface IPickListService
    {
        Task<MetaResponse> CreateAsync(PickListRequest body);

        Task<MetaResponse> CreateOptionAsync(int pickListId, PickListOptionRequest body);

        Task<DataResponse<PickList>> GetAsync(int pickListId);

        Task<DataListResponse<PickList>> GetListAsync(int startAt, int maxResults);        

        Task<DataListResponse<PickListOption>> GetOptionListAsync(int pickListId, int startAt, int maxResults);                

        Task DeleteAsync(int pickListId);
    }
}
