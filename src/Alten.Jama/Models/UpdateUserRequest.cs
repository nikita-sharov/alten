using System.ComponentModel.DataAnnotations;

namespace Alten.Jama.Models
{
    // See: // See: https://help.jamasoftware.com/ah/en/administration/organization-administrator/manage-users/edit-user-details.html
    public sealed class UpdateUserRequest : UserRequest
    {
        [Required]
        public override string Username { get; set; }

        [Required]
        public override string Password { get; set; }

        [Required]
        public override string FirstName { get; set; }

        [Required]
        public override string LastName { get; set; }
    }
}
