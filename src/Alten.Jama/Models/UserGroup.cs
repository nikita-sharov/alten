namespace Alten.Jama.Models
{
    public sealed class UserGroup
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        /// <summary>
        /// The project ID of a project-level group.
        /// </summary>
        /// <value><c>null</c> for organization-level groups.</value>
        /// <seealso href="https://actin-trial.jamacloud.com/help/ah/en/administration/project-administrator/manage-project-users/manage-project-groups.html"/>
        public int? Project { get; set; }
    }
}
