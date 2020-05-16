using Alten.Jama.Models;
using System.Threading.Tasks;

namespace Alten.Jama.Services
{
    // See: https://rest.jamasoftware.com/#endpoint_picklistoptions
    public interface IPickListOptionService
    {
        Task<DataResponse<PickListOption>> GetAsync(int pickListOptionId);

        Task<MetaResponse> UpdateAsync(int pickListOptionId, PickListOptionRequest body);
    }
}
