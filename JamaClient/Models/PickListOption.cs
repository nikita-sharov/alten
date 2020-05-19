namespace JamaClient.Models
{
    public sealed class PickListOption : PickListOptionRequest
    {
        public int Id { get; set; }

        /// <summary>
        /// Pick list ID.
        /// </summary>
        public int PickList { get; set; }
    }
}
