using Alten.Jama.Models;
using System.Threading.Tasks;

namespace Alten.Jama.Services
{
    // See: https://rest.jamasoftware.com/#endpoint_items
    public interface IItemService
    {
        Task DeleteAsync(int itemId);

        Task DeleteAttachmentAsync(int itemId, int attachmentId);

        Task<DataListResponse<Activity>> GetActivityListAsync(int itemId, int startAt, int maxResults);

        Task<DataListResponse<Item>> GetListAsync(int projectId, bool rootItemsOnly, int startAt, int maxResults);

        Task<DataResponse<Item>> GetAsync(int itemId);

        Task<DataListResponse<Attachment>> GetAttachmentListAsync(int itemId, int startAt, int maxResults);

        Task<DataListResponse<Item>> GetChildListAsync(int itemId, int startAt, int maxResults);

        Task<DataListResponse<Comment>> GetCommentListAsync(
            int itemId, bool rootCommentsOnly, int startAt, int maxResults);

        Task<MetaResponse> PatchAsync(int itemId, RequestPatchOperation body);

        Task<MetaResponse> PostAsync(RequestItem body);

        Task<MetaResponse> PostAttachmentAsync(int itemId, RequestItemAttachment body);

        Task<MetaResponse> PutAsync(int itemId, RequestItem body);
    }
}
