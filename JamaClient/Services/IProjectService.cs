using JamaClient.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace JamaClient.Services
{
    /// <summary>
    /// 'Projects' endpoint (https://your-tenant.jamacloud.com/rest/v1/projects).
    /// </summary>
    /// <seealso href="https://rest.jamasoftware.com/#endpoint_projects"/>
    public interface IProjectService
    {
        Task<DataResponse<Project>> GetAsync(int id, List<string> include = null);

        Task<DataListResponse<Project>> GetAsync(
            int? startAt = null, int? maxResults = null, List<string> include = null);

        ////ItemTypeDataListWrapper GetItemTypesInProject(int? projectId, int? startAt = null, int? maxResults = null, List<string> include = null);

        ////TagDataListWrapper GetTagsInProject(int? projectId, int? startAt = null, int? maxResults = null, List<string> include = null);

        Task<MetaResponse> CreateAsync(ProjectRequest body);

        Task<MetaResponse> UpdateAsync(int id, ProjectRequest body);

        ////CreatedResponse PostAttachment(RequestAttachment body, int? projectId);

        Task<MetaResponse> AddItemTypeAsync(int projectId, int itemTypeId);                
        
        Task<MetaResponse> RemoveItemTypeAsync(int projectId, int itemTypeId);
    }
}
