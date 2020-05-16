using Alten.Jama.Models;
using System.Threading.Tasks;

namespace Alten.Jama.Services
{
    // See: https://rest.jamasoftware.com/#endpoint_itemtypes
    public interface IItemTypeService
    {        
        Task<MetaResponse> CreateAsync(ItemTypeRequest body);

        Task<MetaResponse> CreateFieldAsync(int itemTypeId, ItemTypeFieldRequest body);

        Task<DataResponse<ItemType>> GetAsync(int itemTypeId);

        Task<DataListResponse<ItemType>> GetListAsync(int startAt, int maxResults);
    }
}
