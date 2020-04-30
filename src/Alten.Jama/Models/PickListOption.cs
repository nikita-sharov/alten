using System.Text.Json.Serialization;

namespace Alten.Jama.Models
{
    public sealed class PickListOption : PickListOptionRequest
    {
        public int Id { get; set; }

        [JsonPropertyName("pickList")]
        public int PickListId { get; set; }
    }
}
