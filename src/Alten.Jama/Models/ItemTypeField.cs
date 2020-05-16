using System.Text.Json.Serialization;

namespace Alten.Jama.Models
{
    // See: https://rest.jamasoftware.com/#datatype_ItemTypeField
    public sealed class ItemTypeField : ItemTypeFieldRequest
    {
        public int Id { get; set; }

        [JsonPropertyName("itemType")]
        public int ItemTypeId { get; set; }
    }
}