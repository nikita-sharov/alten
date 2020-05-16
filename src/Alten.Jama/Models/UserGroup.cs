using System.Text.Json.Serialization;

namespace Alten.Jama.Models
{
    // See: https://rest.jamasoftware.com/#datatype_UserGroup
    public sealed class UserGroup : UserGroupRequest
    {
        public int Id { get; set; }
    }
}
