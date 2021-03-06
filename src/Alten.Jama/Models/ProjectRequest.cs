using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Alten.Jama.Models
{
    // See: https://rest.jamasoftware.com/#datatype_RequestProject
    public class ProjectRequest : IValidatableObject
    {
        /// <summary>
        /// The project key is an unique ID, that makes up the first part of each item's unique ID.
        /// </summary>
        /// <value>Is <c>null</c> if <see cref="IsFolder"/> is <c>true</c>.</value>
        /// <seealso href="https://help.jamasoftware.com/ah/en/administration/project-administrator/manage-projects/project-key.html"/>
        public string ProjectKey { get; set; }

        public bool IsFolder { get; set; }

        [JsonPropertyName("parent")]
        public int? ParentProjectId { get; set; }

        public Dictionary<string, object> Fields { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if ((ProjectKey != null) && IsFolder)
            {
                yield return new ValidationResult(
                    "Project folders must not include a project key.", new[] { nameof(ProjectKey) });
            }
        }
    }
}
