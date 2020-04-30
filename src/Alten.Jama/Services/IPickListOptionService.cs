using Alten.Jama.Models;
using System.Threading.Tasks;

namespace Alten.Jama.Services
{
    public interface IPickListOptionService
    {
        Task<DataResponse<PickListOption>> GetAsync(int pickListOptionId);

        Task<MetaResponse> PutAsync(int pickListOptionId, PickListOptionRequest body);
    }
}
