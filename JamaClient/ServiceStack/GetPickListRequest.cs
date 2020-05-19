namespace JamaClient.ServiceStack
{
    [Route("/picklists/{Id}")]
    public sealed class GetPickListRequest : IReturn<GetPickListResponse>
    {
        public int Id { get; set; }
    }
}
