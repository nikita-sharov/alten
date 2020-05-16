using Alten.Jama.Models;
using System.Threading.Tasks;

namespace Alten.Jama.Services
{
    // See: https://rest.jamasoftware.com/#endpoint_projects
    public interface IProjectService
    {
        Task<MetaResponse> CreateAsync(ProjectRequest body);

        Task<MetaResponse> CreateAttachmentAsync(int projectId, AttachmentRequest body);

        Task<DataResponse<Project>> GetAsync(int projectId);

        Task<DataListResponse<Project>> GetListAsync(int startAt, int maxResults);

        Task<MetaResponse> AddItemTypeAsync(int projectId, int itemTypeId);

        Task<DataListResponse<ItemType>> GetItemTypeListAsync(int projectId, int startAt, int maxResults);

        Task RemoveItemTypeAsync(int projectId, int itemTypeId);

        Task<DataListResponse<Tag>> GetTagListAsync(int projectId, int startAt, int maxResults);

        Task<MetaResponse> UpdateAsync(int projectId, ProjectRequest body);
    }
}
