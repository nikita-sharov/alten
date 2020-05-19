using ServiceStack;

namespace GosuClient.Models
{
    public sealed class PickList
    {
        public int Id { get; set; }
        
        public string Name { get; set; }

        public string Description { get; set; }
    }

    [Route("/picklists", "GET")]
    public class GetPickLists : IReturn<GetDataListResponse<PickList>>
    {
        public int StartAt { get; set; }

        public int MaxResults { get; set; } = 50;
    }

    [Route("/picklists", "POST")]
    public class CreatePickList : IReturn<CreateResponse>
    {
        public string Name { get; set; }

        public string Description { get; set; }
    }

    [Route("/picklists/{Id}", "GET")]
    public class GetPickList : IReturn<GetDataResponse<PickList>>
    {
        public int Id { get; set; }
    }

    [Route("picklists/{Id}", "DELETE")]
    public class DeletePickList : IReturnVoid
    {
        public int Id { get; set; }
    }
}
