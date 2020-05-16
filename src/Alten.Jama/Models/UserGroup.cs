using System.Text.Json.Serialization;

namespace Alten.Jama.Models
{
    // See: https://rest.jamasoftware.com/#datatype_UserGroup
    public sealed class UserGroup
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        /// <summary>
        /// The project ID of a project-level group.
        /// </summary>
        /// <value><c>null</c> for organization-level groups.</value>
        /// <seealso href="https://help.jamasoftware.com/ah/en/administration/project-administrator/manage-project-users/manage-project-groups.html"/>
        [JsonPropertyName("project")]
        public int? ProjectId { get; set; }
    }
}
