using System.Text.Json.Serialization;

// TODO: Rename
namespace Alten.Jama.Models
{    
    // See: https://rest.jamasoftware.com/#datatype_RequestGroupUser
    public sealed class GroupUserRequest
    {
        [JsonPropertyName("user")]
        public int UserId { get; set; }
    }
}
