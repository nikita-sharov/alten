using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Alten.Jama.Models
{
    // See: https://rest.jamasoftware.com/#datatype_RequestUserGroup
    public sealed class UserGroupRequest
    {
        [Required]
        public string Name { get; set; }

        public string Description { get; set; }

        [JsonPropertyName("project")]
        public int? ProjectId { get; set; }
    }
}
