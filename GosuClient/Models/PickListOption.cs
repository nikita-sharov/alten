using GosuClient.Models;
using ServiceStack;
using ServiceStack.Web;

namespace GosuClient.Models
{
    public sealed class PickListOption
    {
        public int Id { get; set; }

        public int PickList { get; set; }

        public int SortOrder { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public string Value { get; set; }

        public string Color { get; set; }

        public bool Default { get; set; }

        public bool Active { get; set; }
    }

    [Route("/picklists/{PickListId}/options", "GET")]
    public sealed class GetPickListOptions : IReturn<GetDataListResponse<PickListOption>>
    {
        public int PickListId { get; set; }

        public int StartAt { get; set; }

        public int MaxResults { get; set; } = 50;

        public string[] Include { get; } = new string[] { "data.pickList" };
    }

    [Route("/picklists/{PickListId}/options", "POST")]
    public sealed class CreatePickListOption : IRequiresRequest, IReturn<CreateResponse>
    {
        public int PickListId { get; set; }

        public int SortOrder { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public string Value { get; set; }

        public string Color { get; set; }

        public bool Default { get; set; }
        public IRequest Request { get; set; }
    }

    [Route("/picklistoptions/{Id}", "GET")]
    public sealed class GetPickListOption : IReturn<GetDataResponse<PickListOption>>
    {
        public int Id { get; set; }

        public string[] Include { get; } = new string[] { "data.pickList" };
    }

    [Route("/picklistoptions/{Id}", "PUT")]
    public sealed class UpdatePickListOption : IReturn<MetaResponse>
    {
        public int Id { get; set; }

        public int SortOrder { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public string Value { get; set; }

        public string Color { get; set; }

        public bool Default { get; set; }
    }
}
