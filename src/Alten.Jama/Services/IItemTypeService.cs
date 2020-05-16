using Alten.Jama.Models;
using System.Threading.Tasks;

namespace Alten.Jama.Services
{
    // See: https://rest.jamasoftware.com/#endpoint_itemtypes
    public interface IItemTypeService
    {
        Task<DataListResponse<ItemType>> GetListAsync(int startAt, int maxResults);

        Task<MetaResponse> PostAsync(ItemTypeRequest body);

        Task<DataResponse<ItemType>> GetAsync(int itemTypeId);

        Task<MetaResponse> PostFieldAsync(int itemTypeId, RequestItemTypeField body);
    }
}
