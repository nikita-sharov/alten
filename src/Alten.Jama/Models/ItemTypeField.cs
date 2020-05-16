using System.Text.Json.Serialization;

namespace Alten.Jama.Models
{
    // See: https://rest.jamasoftware.com/#datatype_ItemTypeField
    public sealed class ItemTypeField
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Label { get; set; }

        public FieldType FieldType { get; set; }

        public bool ReadOnly { get; set; }

        public bool? ReadOnlyAllowApiOverwrite { get; set; }

        public bool Required { get; set; }

        public bool TriggerSuspect { get; set; }

        public bool Synchronize { get; set; }

        [JsonPropertyName("pickList")]
        public int? PickListId { get; set; }

        public TextType? TextType { get; set; }

        [JsonPropertyName("itemType")]
        public int ItemTypeId { get; set; }
    }
}