using Alten.Jama.Models;
using System.Threading.Tasks;

namespace Alten.Jama.Services
{
    // See: https://rest.jamasoftware.com/#endpoint_projects
    public interface IProjectService
    {
        Task<DataResponse<Project>> GetAsync(int projectId);

        Task<DataListResponse<Project>> GetListAsync(int startAt, int maxResults);

        Task<MetaResponse> PostAsync(ProjectRequest body);

        Task<MetaResponse> PutAsync(int projectId, ProjectRequest body);

        Task<MetaResponse> PostAttachment(int projectId, RequestAttachment body);

        Task<DataListResponse<ItemType>> GetItemTypeListAsync(int projectId, int startAt, int maxResults);

        Task<MetaResponse> PutItemTypeAsync(int projectId, int itemTypeId);

        Task DeleteItemTypeAsync(int projectId, int itemTypeId);

        Task<DataListResponse<Tag>> GetTagListAsync(int projectId, int startAt, int maxResults);
    }
}
