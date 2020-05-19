using JamaClient.Models;

namespace JamaClient.ServiceStack
{
    public sealed class GetPickListResponse
    {
        public Meta Meta { get; set; }

        public PickList Data { get; set; }
    }
}
