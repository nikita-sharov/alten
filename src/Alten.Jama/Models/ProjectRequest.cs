using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Alten.Jama.Models
{
    public class ProjectRequest : IValidatableObject
    {
        /// <summary>
        /// The project key is a unique identifier, automatically created with each project, that makes up the first part of each item's Unique ID.
        /// </summary>
        /// <value>Is <c>null</c> if <see cref="IsFolder"/> is <c>true</c>.</value>
        /// <seealso href="https://help.jamasoftware.com/ah/en/administration/project-administrator/manage-projects/project-key.html"/>
        public string ProjectKey { get; set; }

        public bool IsFolder { get; set; }

        /// <summary>
        /// Parent project ID.
        /// </summary>
        /// <value>Is <c>null</c> if <see cref="IsFolder"/> is <c>true</c>.</value>
        public int? Parent { get; set; }

        public Dictionary<string, object> Fields { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            throw new System.NotImplementedException();
        }
    }
}
