using System.Text.Json.Serialization;

namespace Alten.Jama.Models
{
    // See: https://rest.jamasoftware.com/#datatype_RequestGroupUser
    public sealed class GroupUserRequest
    {
        [JsonPropertyName("user")]
        public int UserId { get; set; }
    }
}
