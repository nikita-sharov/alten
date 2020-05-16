using System.Text.Json.Serialization;

namespace Alten.Jama.Models
{
    // See: https://rest.jamasoftware.com/#datatype_Tag
    // See: https://help.jamasoftware.com/ah/en/create-content/tags.html
    public sealed class Tag
    {
        public int Id { get; set; }

        public string Name { get; set; }

        [JsonPropertyName("project")]
        public int ProjectId { get; set; }
    }
}
