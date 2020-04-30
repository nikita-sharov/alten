using System.Text.Json.Serialization;

namespace Alten.Jama.Models
{
    public sealed class GroupUserRequest
    {
        [JsonPropertyName("user")]
        public int UserId { get; set; }
    }
}
